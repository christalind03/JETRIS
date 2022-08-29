using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO.Compression;
using System.IO;
using System.Linq;
using TMPro;
using gtcp;

public class Multiplayer : MonoBehaviour
{
    public int resolution;
    public RawImage localout;
    public TextMeshProUGUI localName;
    public TextMeshProUGUI localELO;
    public RawImage remoteout;
    public TextMeshProUGUI remoteName;
    public TextMeshProUGUI remoteELO;
    public Camera gamecamera;
    GameObject manager;
    RenderTexture cameratexture;
    Texture2D outtex;
    [NonSerialized] public Texture2D intex;
    Action<byte[]> send;
    void Start()
    {
        manager = GameObject.Find("GameManagers");

        client theClient = manager.GetComponent<GameMaster>().theClient;
        theClient.emit("getuserinfo", PlayerPrefs.GetString("usertoken"), new Action<int, string>((int elo, string username) => 
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() => 
            {
                localName.text = username;
                localELO.text = $"{elo} ELO";
            });
        }), "elo", "username");

        theClient.emit("getuserinfo", manager.GetComponent<GameMaster>().opponentid, new Action<int, string>((int elo, string username) => 
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() => 
            {
                remoteName.text = username;
                remoteELO.text = $"{elo} ELO";
            });
        }), "elo", "username");

        resolution = 200;
        intex = new(resolution, resolution, TextureFormat.RGBA32, false);
        intex.filterMode = FilterMode.Point;
        cameratexture = new RenderTexture(resolution, resolution, 32);
        outtex = new(resolution, resolution, TextureFormat.RGBA32, false);
        gamecamera.aspect = 0.9f;
        gamecamera.targetTexture = cameratexture;
        localout.texture = cameratexture;
        
        Socket s = manager.GetComponent<GameMaster>().udps;
        string[] iparr = manager.GetComponent<GameMaster>().joinip.Split(":");
        byte[] encodeddata = new byte[65535];
        int byteLength;
        EndPoint server = new IPEndPoint(IPAddress.Parse(iparr[0]), ushort.Parse(iparr[1]));

        send = new Action<byte[]>((data) => 
        {
            s.SendTo(data, data.Length, SocketFlags.None, server);
        });

        new Thread(() => 
        {
            while(true)
            {
                byteLength = s.Receive(encodeddata);
                UnityMainThreadDispatcher.Instance().Enqueue(() => 
                {
                    intex.LoadRawTextureData(Qompress.Decompress(encodeddata.Take(byteLength).ToArray()));
                    intex.Apply();
                    remoteout.texture = intex;
                });
            }
        }).Start();
    }
    void Update()
    {
        RenderTexture.active = cameratexture;
        outtex.ReadPixels(new Rect(0, 0, cameratexture.width, cameratexture.height), 0, 0);
        outtex.Apply();
        send(Qompress.Compress(outtex.GetRawTextureData()));
    }
}

class Qompress
{
    
    public static byte[] Compress(byte[] data)
    {
        using (var compressedStream = new MemoryStream())
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
        {
            zipStream.Write(data, 0, data.Length);
            zipStream.Close();
            return compressedStream.ToArray();
        }
    }

    public static byte[] Decompress(byte[] data)
    {
        using (var compressedStream = new MemoryStream(data))
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        using (var resultStream = new MemoryStream())
        {
            zipStream.CopyTo(resultStream);
            return resultStream.ToArray();
        }
    }
}