using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class msgChat : MonoBehaviour
{
    public string datetime;
    public string msg;
    public Text datetimeText;
    public Text msgText;
    public RawImage Avatar;
    public int UserId;
    public Text username;
    private void Update()
    {
        datetimeText.text = datetime;
        msgText.text = msg;
        username.text = $"user_{UserId}";
    }
}
