using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using gtcp;

public class GameMaster : MonoBehaviour
{
    public client theClient;
    public Socket udps;
    public string udpip;
    public string joinip;
    public string opponentid;
    
    void Awake(){
        DontDestroyOnLoad(gameObject);
        try
        {
            theClient = new client("8.tcp.ngrok.io:12404");
        }
        catch(Exception e)
        {
            Debug.Log("Couldn't connect to server");
        }
        finally
        {
            new Thread(() => 
            {
                udps = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        
                byte[] encodeddata = new byte[2050];
                int byteLength;
                EndPoint holepunchingserver = new IPEndPoint(IPAddress.Parse("13.56.154.178"), 1234);

                udps.SendTo(new byte[0], 0, SocketFlags.None, holepunchingserver);
                byteLength = udps.ReceiveFrom(encodeddata, ref holepunchingserver);
                udpip = Encoding.ASCII.GetString(encodeddata.Skip(2).Take(byteLength - 2).ToArray()) + ":" + BitConverter.ToUInt16(encodeddata.Take(2).ToArray());
            }).Start();
        }
    }
}