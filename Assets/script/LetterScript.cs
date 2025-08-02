using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LetterScript : MonoBehaviour
{
    public string NameMail;
    public string Date;
    public string Time;
    public string descripton;

    public Text NameMailText;
    public Text DateText;
    public Text TimeText;
    

    private void Update()
    {
        if (NameMail.Length > 25)
        {
            NameMailText.text = $"{NameMail.Substring(0, 25)}...";
        }
        else
        {
            NameMailText.text = $"{NameMail}";
        }
        DateText.text = Date;
        TimeText.text = Time;
    }

    public void Click()
    {
        GameControll.instance.MailOpenPanel.SetActive(true);
        GameControll.instance.MailOpenPanel.GetComponent<MailOpenPanel>().NameMail = NameMail;
        GameControll.instance.MailOpenPanel.GetComponent<MailOpenPanel>().Date = Date;
        GameControll.instance.MailOpenPanel.GetComponent<MailOpenPanel>().Time = Time;
        GameControll.instance.MailOpenPanel.GetComponent<MailOpenPanel>().descripton = descripton;
    }
}
