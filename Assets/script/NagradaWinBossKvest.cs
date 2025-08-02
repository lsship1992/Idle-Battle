using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NagradaWinBossKvest : MonoBehaviour
{
    public Image Image;
    public string type;
    public string Name;
    public int Count;
    public Text CountText;

    private void Start()
    {
        if (type == "UserSerebro")
        {
            ClientSend.ValuteUpdate(Count, "Gold", "+");
        }
        else if (type == "UserBriliant")
        {
            ClientSend.ValuteUpdate(Count, "Almaz", "+");

        }
        else if (type == "PersonExperience")
        {
            ClientSend.ValuteUpdate(Count, "OpitPerson", "+");

        }
        else if (type == "UserExperience")
        {

        }
        else if (type == "score")
        {

        }
    }
    private void Update()
    {
        CountText.text = Count.ToString();
        if (GameControll.instance.PvePanel.activeSelf)
        {
            if (type == "UserSerebro")
            {
                Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[0];
            }
            else if (type == "UserBriliant")
            {
                Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[1];
            }
            else if (type == "PersonExperience")
            {
                Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[2];
            }
            else if (type == "UserExperience")
            {

            }
            else if (type == "score")
            {
                Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[3];

            }
        }
        else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {
            if (type == "currency")
            {
                if (Name == "gold")
                {
                    Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[0];
                }
                else if (Name == "almaz")
                {
                    Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[1];
                }
                else if (Name == "exp")
                {
                    Image.sprite = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().SpriteNagrad[2];
                }
            }
            else if (type == "item")
            {
                if (Name == "Beginner boots")
                {
                    Image.sprite = GameControll.instance.SpriteItemSnar[0];
                }
            }
        }
        else
        {
            if (type == "UserSerebro")
            {
                Image.sprite = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().SpriteNagrad[0];
            }
            else if (type == "UserBriliant")
            {
                Image.sprite = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().SpriteNagrad[1];
            }
            else if (type == "PersonExperience")
            {
                Image.sprite = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().SpriteNagrad[2];
            }
            else if (type == "UserExperience")
            {

            }
            else if (type == "score")
            {

            }
        }
        
    }
}
