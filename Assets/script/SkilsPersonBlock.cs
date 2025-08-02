using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilsPersonBlock : MonoBehaviour
{
    public Text NameText;
    public Text DescriptionText;
    public string Name;
    public string Description;
    public Image Image;
    public int idBlock;

    public GameObject ButtonUp;
    public GameObject ButtonDown;

    private void Awake()
    {
        try
        {
            ButtonUp.GetComponent<Button>().onClick.AddListener(() => ButtonUpVoid());
        }
        catch
        {

        }
        try
        {
            ButtonDown.GetComponent<Button>().onClick.AddListener(() => ButtonDownVoid());
        }
        catch
        {

        }
    }

    public void ButtonUpVoid()
    {
        if (idBlock == 1)
        {

        }
        else if (idBlock == 2)
        {
            ClientSend.SkilSmen(Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill1), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2),Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().id),1);
        }
        else if (idBlock == 3)
        {
            ClientSend.SkilSmen(Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill3), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().id),2);
        }
    }

    public void ButtonDownVoid()
    {
        if (idBlock == 1)
        {
            ClientSend.SkilSmen(Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill1), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().id),1);

        }
        else if (idBlock == 2)
        {
            ClientSend.SkilSmen(Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill3), Convert.ToInt32(GameControll.instance.personPanel.GetComponent<PersControlScript>().id),2);
        }
        else if (idBlock == 3)
        {

        }
    }
    private void Update()
    {
        NameText.text = Name;
        DescriptionText.text = Description;


        //Изображения
        if (Name == "")
        {
            Image.sprite = GameControll.instance.SpriteSkill[0];
        }
        else
        {
            Image.gameObject.SetActive(false);
        }
    }

}
