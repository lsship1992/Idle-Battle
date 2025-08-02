using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ServerSearchInfo : MonoBehaviour
{
    public string ip = "109.73.206.253";
    public string _nameserver;
    public int port = 26951;
    public int myId = 0;


    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    private void OnClick()
    {
        if (menu.instance.loginPanelSend.activeSelf == true)
        {
            menu.instance.ip = ip;
            menu.instance.nameserver = _nameserver;
            menu.instance.server.SetActive(false);
            PlayerPrefs.SetString("GameServerIp", ip);
            PlayerPrefs.SetString("mail", menu.instance.MailFieldLogin.text);
            ClientSend.LoginTo();
            
        }
        else if (menu.instance.IsGoust == true)
        {
            menu.instance.ip = ip;
            menu.instance.server.SetActive(false);
            ClientSend.GoustRegLog();
            Client.instance.Disconnect();
            PlayerPrefs.SetString("GameServerIp", ip);
            menu.instance.LoadSceneAsync("Game");


        }
        else if (menu.instance.IsGoogle == true)
        {
            menu.instance.ip = ip;
            menu.instance.server.SetActive(false);
            ClientSend.GoogleRegLog();
            Client.instance.Disconnect();
            PlayerPrefs.SetString("GameServerIp", ip);
            menu.instance.LoadSceneAsync("Game");

        }
        else
        {
            Debug.Log("≈банашка");
            menu.instance.ip = ip;
            menu.instance.nameserver = _nameserver;
            menu.instance.server.SetActive(false);
            ClientSend.Register();
            //Client.instance.Disconnect();
            PlayerPrefs.SetString("GameServerIp", ip);
            PlayerPrefs.SetString("mail", menu.instance.UsernameField.text);
            Debug.Log(PlayerPrefs.GetString("GameServerIp"));
            Debug.Log(PlayerPrefs.GetString("mail"));
            //menu.instance.LoadSceneAsync("Game");

        }



    }
}
