using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryControlScripts : MonoBehaviour
{
    public Image Snar;
    public Image material;
    public Sprite Off;
    public Sprite On;
    public string vkladka = "Snar";
    public void SnarBtn()
    {
        while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
        }
        ClientSend.InventorySearchUser();
        vkladka = "Snar";
    }
    public void MaterialBtn()
    {
        while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
        }
        ClientSend.InventoryMaterialSearchUser();
        vkladka = "Material";
    }
    private void Update()
    {
        if (vkladka == "Snar")
        {
            Snar.sprite = On;
            material.sprite = Off;
        }
        else if (vkladka == "Material")
        {
            Snar.sprite = Off;
            material.sprite = On;
        }
        GameControll.instance.InventoryItemFather.GetComponent<RectTransform>().sizeDelta = new Vector2(GameControll.instance.InventoryItemFather.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.InventoryItemFather.transform.childCount * 40.5f + 100);
    }
}
