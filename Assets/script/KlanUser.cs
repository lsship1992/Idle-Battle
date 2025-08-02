using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KlanUser : MonoBehaviour
{
    public string NameKlan;
    public Text NameKlanText;
    public GameObject QuitPanel;
    public GameObject kvestKlan;
    public GameObject KlanUserListPanel;
    public GameObject FatherListUser;
    public GameObject PrefabListUser;
    public GameObject YesKick;
    public void OpenAndCloseListUser()
    {
        if (KlanUserListPanel.activeSelf == true)
        {
            KlanUserListPanel.SetActive(false);
        }
        else
        {
            while (GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform.GetChild(0).gameObject);
            }
            ClientSend.ListUserKlan(NameKlan);
            KlanUserListPanel.SetActive(true);
        }
    }
    private void Update()
    {
        NameKlanText.text = NameKlan;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void QuitKlanV()
    {
        QuitPanel.SetActive(true);
    }
    public void KvestKlanOpen()
    {
        while (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().FatherReiting.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().FatherReiting.transform.GetChild(0).gameObject);
        }
        ClientSend.GlavReitingUserKvestKlan(NameKlan);
        kvestKlan.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ShopKlan()
    {
        ClientSend.SearchKlanMoney();
        while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchKlanShopMaterial();
        GameControll.instance.ShopPanel.GetComponent<Shop>().steanica = "KlanShop";
        GameControll.instance.ShopPanel.GetComponent<Shop>().ObjectKLanMoney.SetActive(true);
        GameControll.instance.ShopPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
