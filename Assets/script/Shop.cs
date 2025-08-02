using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image Person;
    public Image Snarazhenie;
    public Image Predmet;
    public Image KlanShop;
    public GameObject ObjectKLanMoney;
    public Sprite Off;
    public Sprite On;
    public GameObject InfoPanelPersSnar;
    public int KlanMoney;
    public Text KlanMoneyText;
    public string steanica = "Person";

    public void SnarBtn()
    {
        while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchShopSnar();
        steanica = "Snar";
        ObjectKLanMoney.SetActive(false);

    }
    public void PersonBtn()
    {
        while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchShopPerson();
        steanica = "Person";
        ObjectKLanMoney.SetActive(false);
    }
    public void PredmetBtn()
    {
        while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchShopPredmet();
        steanica = "predmet";
        ObjectKLanMoney.SetActive(false);
    }

    public void KlanBtn()
    {
        while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchKlanShopMaterial();
        steanica = "KlanShop";
        ObjectKLanMoney.SetActive(true);
    }
    private void Start()
    {
        ObjectKLanMoney.SetActive(false);
    }
    private void Update()
    {
        GameControll.instance.ItemShopPersonFather.GetComponent<RectTransform>().sizeDelta = new Vector2(GameControll.instance.ItemShopPersonFather.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.ItemShopPersonFather.transform.childCount * 90.5f + 150);
        KlanMoneyText.text = KlanMoney.ToString();
        if (steanica == "Person")
        {
            Snarazhenie.sprite = Off;
            Person.sprite = On;
            Predmet.sprite = Off;
            KlanShop.sprite = Off;
        }
        else if (steanica == "Snar")
        {
            Snarazhenie.sprite = On;
            Person.sprite = Off;
            Predmet.sprite = Off;
            KlanShop.sprite = Off;

        }
        else if (steanica == "predmet")
        {
            Snarazhenie.sprite = Off;
            Person.sprite = Off;
            Predmet.sprite = On;
            KlanShop.sprite = Off;

        }
        else if (steanica == "KlanShop")
        {
            Snarazhenie.sprite = Off;
            Person.sprite = Off;
            Predmet.sprite = Off;
            KlanShop.sprite = On;

        }
    }
}
