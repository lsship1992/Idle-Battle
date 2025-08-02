using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitKlan : MonoBehaviour
{
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
    public void YesQuit()
    {
        ClientSend.QuitKlanUser();
    }
}
