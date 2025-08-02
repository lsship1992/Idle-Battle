using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chat : MonoBehaviour
{
    public GameObject FatherChat;
    public GameObject PrefabMsgChat;
    public InputField msgUser;
    public GameObject InfoMsgChat;

    public void CloseInfoMsgChat()
    {
        InfoMsgChat.SetActive(!InfoMsgChat.activeSelf);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }  


    public void SendMsgChat()
    {
        if (msgUser.text.Length <= 0 ||  msgUser.text.Length >= 100)
        {
            CloseInfoMsgChat();
        }
        else
        {
            ClientSend.SendMsgChat(msgUser.text);
            msgUser.text = "";
        }
    }

    public IEnumerator UpdateChat()
    {
        ClientSend.UpdateChatMsg();
        yield return new WaitForSeconds(5f);

    }
}
