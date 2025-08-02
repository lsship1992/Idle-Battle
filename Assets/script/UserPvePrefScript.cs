using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserPvePrefScript : MonoBehaviour
{
    public Text NameText;
    public Text GlassesPveText;
    public Text bsText;
    public Text Mesto;

    public string Name;
    public int GlassesPve;
    public int bs;
    public int ID;
    public int mesto;
    public RawImage Avatar;
    public GameObject InBattleButton;

    private void Awake()
    {
        InBattleButton.GetComponent<Button>().onClick.AddListener(() => InBattle());
        if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ReitingActiv)
        {
            NameText.text = $"user_{ID}";
            GlassesPveText.text = GlassesPve.ToString();
            bsText.text = bs.ToString();
            InBattleButton.SetActive(false);
            Mesto.gameObject.SetActive(true);
            bsText.gameObject.SetActive(false);
            Mesto.text = $"#{mesto}";
        }
        else
        {
            NameText.text = $"user_{ID}";
            GlassesPveText.text = GlassesPve.ToString();
            bsText.text = bs.ToString();
            InBattleButton.SetActive(true);
            Mesto.gameObject.SetActive(false);
            bsText.gameObject.SetActive(true);
        }
    }
    public void InBattle()
    {
        GameControll.instance.PvePanel.GetComponent<PvePanelScript>().IDUserAttack = ID;
        GameControll.instance.PvePanel.GetComponent<PvePanelScript>().mail = Name;
        GameControll.instance.PvePanel.GetComponent<PvePanelScript>().scoreEnemy = GlassesPve;
        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.SetActive(false);
        while (GameControll.instance.stroiFatherList.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.stroiFatherList.transform.GetChild(0).gameObject);
        }
        GameControll.instance.persons.GetComponent<ControlPersonScreapt>().DestroyItemStroi();
        ClientSend.PersonSearchUser();
        ClientSend.InventorySearchUser();
        GameControll.instance.stroi.SetActive(true);
        GameControll.instance.stroi.GetComponent<stroiScript>().list = "pvp";
        ClientSend.SearchStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().list);
        
    }
    private void Update()
    {
        if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ReitingActiv)
        {
            NameText.text = $"user_{ID}";
            GlassesPveText.text = GlassesPve.ToString();
            bsText.text = bs.ToString();
            InBattleButton.SetActive(false);
            Mesto.gameObject.SetActive(true);
            Mesto.text = $"#{mesto}";
        }
        else
        {
            NameText.text = $"user_{ID}";
            GlassesPveText.text = GlassesPve.ToString();
            bsText.text = bs.ToString();
            InBattleButton.SetActive(true);
            Mesto.gameObject.SetActive(false);
        }
    }



}
