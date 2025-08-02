using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpisokUserKlan : MonoBehaviour
{
    public GameObject buttonKick;
    public string mail;
    public int ID;
    public string username;
    public Text UsernameText;
    public RawImage Avatar;

    private void Start()
    {
        if (mail == PlayerPrefs.GetString("mail"))
        {
            buttonKick.SetActive(false);
        }
    }
    private void Update()
    {
        UsernameText.text = $"user_{ID}";
    }

    public void Kick()
    {
        GameControll.instance.KlanUser.GetComponent<KlanUser>().YesKick.SetActive(true);
        GameControll.instance.KlanUser.GetComponent<KlanUser>().YesKick.GetComponent<KickUserYes>().id = ID;
        GameControll.instance.KlanUser.GetComponent<KlanUser>().YesKick.GetComponent<KickUserYes>().ipserver = PlayerPrefs.GetString("GameServerIp");
        GameControll.instance.KlanUser.GetComponent<KlanUser>().YesKick.GetComponent<KickUserYes>().mail = mail;
    }

}
