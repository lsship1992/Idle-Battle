using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KickUserYes : MonoBehaviour
{
    public string mail;    
    public string ipserver;    
    public int id;
    public Text userText;

    public void close()
    {
        gameObject.SetActive(false);
    }
    public void YesKick()
    {
        ClientSend.KickUserKlan(mail, ipserver);
    }
    private void Update()
    {
        userText.text = $"Вы действительно хотите выгнать игрока: user_{id} ?";
    }
}
