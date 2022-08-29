using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using gtcp;
using TMPro;

public class master : MonoBehaviour
{
    [NonSerialized] public string usertoken;
    private GameObject manager;
    public GameObject MainMenu;
    public GameObject LoginMenu;
    public GameObject QueueMenu;
    public GameObject MultiplayerMenu;
    public TextMeshProUGUI elotext;
    public TMP_InputField loginusername;
    public TMP_InputField loginpassword;
    public Button loginbutton;
    public TMP_InputField signupusername; 
    public TMP_InputField signuppassword;
    public Button signupbutton;
    public Button playbutton;
    public Button quitbutton;
    public Button multiplayerbutton;
    public Button logoutbutton;
    public Button rankedbutton;
    public Button unrankedbutton;
    public Button leavequeuebutton;
    public Button resetscorebutton;
    int searching;

    public IEnumerator setUsertoken()
    {
        PlayerPrefs.SetString("usertoken", usertoken);
        PlayerPrefs.Save();
        MultiplayerMenu.SetActive(true);
        LoginMenu.SetActive(false);
        yield return null;
    }

    void Start()
    {
        searching = 2;
        manager = GameObject.Find("GameManagers");
        client theClient = manager.GetComponent<GameMaster>().theClient;
        loginbutton.onClick.AddListener(() => {
            theClient.emit("login", loginusername.text, loginpassword.text, new Action<int, string>((int tf, string data) => 
            {
                if(tf == 1)
                {
                    usertoken = data;
                    UnityMainThreadDispatcher.Instance().Enqueue(setUsertoken());
                }
                else
                {
                    Debug.Log(data);
                }
            }));
        });

        signupbutton.onClick.AddListener(() => 
        {
            theClient.emit("signup", signupusername.text, signuppassword.text, new Action<int, string>((int tf, string data) => 
            {
                if(tf == 1)
                {
                    usertoken = data;
                    UnityMainThreadDispatcher.Instance().Enqueue(setUsertoken());
                }
                else
                {
                    Debug.Log(data);
                }
            }));
        });

        quitbutton.onClick.AddListener(() => 
        {
            Application.Quit();
        });

        playbutton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("Single Player");
        });

        resetscorebutton.onClick.AddListener(() => 
        {
            PlayerPrefs.DeleteKey("Highscore");
        });

        logoutbutton.onClick.AddListener(() => 
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() => 
            {
                PlayerPrefs.DeleteKey("usertoken");
            });
        });

        multiplayerbutton.onClick.AddListener(() => 
        {
            if(theClient != default(client))
            {
                MainMenu.SetActive(false);
                if(PlayerPrefs.HasKey("usertoken"))
                {
                    theClient.emit("getuserinfo", PlayerPrefs.GetString("usertoken"), new Action<int, string>((int elo, string username) => 
                    {
                        UnityMainThreadDispatcher.Instance().Enqueue(() => 
                        {
                            elotext.text = $"{username} - {elo} ELO";
                        });
                    }), "elo", "username");

                    MultiplayerMenu.SetActive(true);

                }
                else
                {
                    LoginMenu.SetActive(true);
                }

            }
            else
            {
                Debug.Log("multiplayer unavaliable");
            }
        });

        unrankedbutton.onClick.AddListener(() => 
        {
            searching = 0;
            QueueMenu.SetActive(true);
            MultiplayerMenu.SetActive(false);
            theClient.emit("unrankedqueue", PlayerPrefs.GetString("usertoken"), manager.GetComponent<GameMaster>().udpip, new Action<string, string>((string id, string ip) => 
            {
                UnityMainThreadDispatcher.Instance().Enqueue(() => 
                {
                    manager.GetComponent<GameMaster>().joinip = ip;
                    manager.GetComponent<GameMaster>().opponentid = id;
                    SceneManager.LoadScene("Multiplayer");
                });
            }));
        });

        rankedbutton.onClick.AddListener(() => 
        {
            searching = 1;
            QueueMenu.SetActive(true);
            MultiplayerMenu.SetActive(false);
            theClient.emit("rankedqueue", PlayerPrefs.GetString("usertoken"), manager.GetComponent<GameMaster>().udpip,new Action<string, string>((string id, string ip) => 
            {
                UnityMainThreadDispatcher.Instance().Enqueue(() => 
                {
                    manager.GetComponent<GameMaster>().joinip = ip;
                    manager.GetComponent<GameMaster>().opponentid = id;
                    SceneManager.LoadScene("Multiplayer");
                });
            }));
        });

        leavequeuebutton.onClick.AddListener(() => 
        {
            theClient.emit("leavequeue", searching, manager.GetComponent<GameMaster>().udpip);
            searching = 2;
            MultiplayerMenu.SetActive(true);
            QueueMenu.SetActive(false);
        });
    }
}
