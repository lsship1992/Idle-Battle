using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailOpenPanel : MonoBehaviour
{
    public string NameMail;
    public string Date;
    public string Time;
    public string descripton;

    public Text NameMailText;
    public Text DateText;
    public Text TimeText;
    public Text DescriptionText;


    private void Update()
    {
        NameMailText.text = NameMail;
        DateText.text = Date;
        TimeText.text = Time;
        DescriptionText.text = descripton;
    }

    public void close()
    {
        gameObject.SetActive(false);
    }
}
