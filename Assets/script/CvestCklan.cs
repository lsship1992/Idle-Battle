using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CvestCklan : MonoBehaviour
{
    public GameObject CvestKlanReiting;
    public GameObject CvestKlanPanel;
    public GameObject BattlePanel;
    public GameObject ReitingUser;
    public GameObject FatherReiting;
    public GameObject ReitingPrefab;
    public GameObject ReitingPanel;

    public void CloseAndOpenReitingPanel()
    {
        ReitingPanel.SetActive(!ReitingPanel.activeSelf);
    }
    public void CvestKlanClose()
    {
        GameControll.instance.KlanUser.SetActive(true);
        GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.SetActive(false);
    }

    public void BossBtn()
    {
        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.SetActive(false);
        while (GameControll.instance.stroiFatherList.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.stroiFatherList.transform.GetChild(0).gameObject);
        }
        GameControll.instance.persons.GetComponent<ControlPersonScreapt>().DestroyItemStroi();
        ClientSend.PersonSearchUser();
        ClientSend.InventorySearchUser();
        GameControll.instance.stroi.SetActive(true);
        ClientSend.SearchStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().list);
    }

}
