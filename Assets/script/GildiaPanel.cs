using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GildiaPanel : MonoBehaviour
{
    public string list = "spisok";

    public GameObject spisokPanel;
    public GameObject createPanel;
    public GameObject PoiskPanel;

    public GameObject spisokButton;
    public GameObject createButton;
    public GameObject PoiskButton;
    public GameObject CreatGildia;
    public Sprite on;
    public Sprite off;

    public GameObject PrefabSpisokGildia;
    public GameObject FatherSpisokGildia;

    private void Awake()
    {
        if (list == "spisok")
        {
            spisokPanel.SetActive(true);
            spisokButton.GetComponent<Image>().sprite = on;
            createPanel.SetActive(false);
            createButton.GetComponent<Image>().sprite = off;
            PoiskPanel.SetActive(false);
            PoiskButton.GetComponent<Image>().sprite = off;

        }
        else if (list == "create")
        {
            spisokPanel.SetActive(false);
            spisokButton.GetComponent<Image>().sprite = off;
            createPanel.SetActive(true);
            createButton.GetComponent<Image>().sprite = on;
            PoiskPanel.SetActive(false);
            PoiskButton.GetComponent<Image>().sprite = off;

        }
        else if (list == "poisk")
        {
            spisokPanel.SetActive(false);
            spisokButton.GetComponent<Image>().sprite = off;
            createPanel.SetActive(false);
            createButton.GetComponent<Image>().sprite = off;
            PoiskPanel.SetActive(true);
            PoiskButton.GetComponent<Image>().sprite = on;
        }
    }

    private void Update()
    {
        if (list == "spisok")
        {
            spisokPanel.SetActive(true);
            spisokButton.GetComponent<Image>().sprite = on;
            createPanel.SetActive(false);
            createButton.GetComponent<Image>().sprite = off;
            PoiskPanel.SetActive(false);
            PoiskButton.GetComponent<Image>().sprite = off;

        }
        else if (list == "create")
        {
            spisokPanel.SetActive(false);
            spisokButton.GetComponent<Image>().sprite = off;
            createPanel.SetActive(true);
            createButton.GetComponent<Image>().sprite = on;
            PoiskPanel.SetActive(false);
            PoiskButton.GetComponent<Image>().sprite = off;

        }
        else if (list == "poisk")
        {
            spisokPanel.SetActive(false);
            spisokButton.GetComponent<Image>().sprite = off;
            createPanel.SetActive(false);
            createButton.GetComponent<Image>().sprite = off;
            PoiskPanel.SetActive(true);
            PoiskButton.GetComponent<Image>().sprite = on;
        }
    }

    public void SpisokVoid()
    {
        while (GameControll.instance.Gildia.GetComponent<GildiaPanel>().FatherSpisokGildia.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.Gildia.GetComponent<GildiaPanel>().FatherSpisokGildia.transform.GetChild(0).gameObject);
        }
        ClientSend.SearchGildia();
        list = "spisok";

    }

    public void CrreateVoid()
    {
        list = "create";
    }
    public void PoiskVoid()
    {
        list = "poisk";
    }

    public void CLose()
    {
        gameObject.SetActive(false);
    }
}
