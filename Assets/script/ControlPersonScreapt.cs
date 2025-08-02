using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlPersonScreapt : MonoBehaviour
{
    private GameControll _Control;
    public void ClickStoi()
    {
        this.gameObject.SetActive(false);
        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.SetActive(false);
        while (GameControll.instance.stroiFatherList.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.stroiFatherList.transform.GetChild(0).gameObject);
        }
        ClientSend.PersonSearchUser();
        ClientSend.InventorySearchUser();
        GameControll.instance.stroi.SetActive(true);
        DestroyItemStroi();
        ClientSend.SearchStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().list);
    }
    public void DestroyItemStroi()
    {
        foreach (string a in GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.ToList())
        {
            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Remove(a);
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].transform.childCount > 0)
        {
            try
            {
                Destroy(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].transform.GetChild(0).gameObject);
            }
            catch
            {

            }
        }
    }
    private void Awake()
    {
        _Control = GameObject.Find("Main Camera").GetComponent<GameControll>();
    }
    public void PersonsButtonOff()
    {
        _Control.persons.SetActive(false);
    }
    private void Update()
    {
        GameControll.instance.PersonsFather.GetComponent<RectTransform>().sizeDelta = new Vector2(GameControll.instance.PersonsFather.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.PersonsFather.transform.childCount * 51.25f + 100);
    }
}
