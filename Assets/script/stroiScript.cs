using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class stroiScript : MonoBehaviour
{
    public List<GameObject> imgstroi = new List<GameObject>();
    public List<string> nameObj = new List<string>();
    public int Count;
    public Sprite off;
    public Sprite on;
    public string list = "pve";
    public Image pveimg;
    public Image pvpimg;
    public GameObject DownMenu;
    public GameObject BattleBtn;
    public int bs;
    public Text bsText;
    //bs = (int) ((Attack_info / 2) + (Hp_info / 2) + (Defens_info* 2.5f) + (Speed_info* 6.4f));


    public void UpdateBs()
    {
        bs = 0;
        foreach(var a in imgstroi)
        {
            if (a.gameObject.transform.childCount > 0)
            {
                bs = bs + (int)((a.gameObject.transform.GetChild(0).GetComponent<PersonPrefabScript>().Attack / 2) + (a.gameObject.transform.GetChild(0).GetComponent<PersonPrefabScript>().Hp / 2) + (a.gameObject.transform.GetChild(0).GetComponent<PersonPrefabScript>().Defens * 2.5f) + (a.gameObject.transform.GetChild(0).GetComponent<PersonPrefabScript>().Speed * 6.4f));   
            }
        }
    }
    public void BattleBtnVoid()
    {
        if (GameControll.instance.PvePanel.activeSelf == true)
        {
            if (imgstroi[0].transform.childCount > 0 || imgstroi[1].transform.childCount > 0 || imgstroi[2].transform.childCount > 0 || imgstroi[3].transform.childCount > 0 || imgstroi[4].transform.childCount > 0 || imgstroi[5].transform.childCount > 0 || imgstroi[6].transform.childCount > 0 || imgstroi[7].transform.childCount > 0 || imgstroi[8].transform.childCount > 0)
            {
                GameControll.instance.AudioSourceG.clip = GameControll.instance.BattleClip;
                GameControll.instance.AudioSourceG.Play();
                GameControll.instance.PvePanel.GetComponent<PvePanelScript>().BattleStart = true;
                if (GameControll.instance.PvePanel.activeSelf)
                {
                    ClientSend.AddPersonPve("pvp");
                }
                GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonidListSlot.Clear();

                //ClientSend.SearchLevelBatlePve();
                ClientSend.AddPersonEnemyPvp("pvp", GameControll.instance.PvePanel.GetComponent<PvePanelScript>().mail);
                ClientSend.PvpStart();
                GameControll.instance.PvePanel.GetComponent<PvePanelScript>().Battle.SetActive(true);
                this.gameObject.SetActive(false);
            }

        }
        else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {

            if (imgstroi[0].transform.childCount > 0 || imgstroi[1].transform.childCount > 0 || imgstroi[2].transform.childCount > 0 || imgstroi[3].transform.childCount > 0 || imgstroi[4].transform.childCount > 0 || imgstroi[5].transform.childCount > 0 || imgstroi[6].transform.childCount > 0 || imgstroi[7].transform.childCount > 0 || imgstroi[8].transform.childCount > 0)
            {
                GameControll.instance.AudioSourceG.clip = GameControll.instance.BattleClip;
                GameControll.instance.AudioSourceG.Play();
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.SetActive(true);
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().BattleStart = true;
                if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf)
                {
                    ClientSend.AddPersonPve("pve");
                }
                ClientSend.AddCvestKlanBoss();
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().EnemyPersonidListSlot.Clear();

                UpdateEnemyPerson();
                this.gameObject.SetActive(false);
            }


            

        }
        else
        {

            if (imgstroi[0].transform.childCount > 0 || imgstroi[1].transform.childCount > 0 || imgstroi[2].transform.childCount > 0 || imgstroi[3].transform.childCount > 0 || imgstroi[4].transform.childCount > 0 || imgstroi[5].transform.childCount > 0 || imgstroi[6].transform.childCount > 0 || imgstroi[7].transform.childCount > 0 || imgstroi[8].transform.childCount > 0)
            {
                GameControll.instance.AudioSourceG.clip = GameControll.instance.BattleClip;
                GameControll.instance.AudioSourceG.Play();
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().BattleStart = true;
                if (GameControll.instance.kvestPanel.activeSelf)
                {
                    ClientSend.AddPersonPve("pve");
                }
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Boss.SetActive(false);
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Vboi.SetActive(true);
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Vboi.GetComponent<Button>().interactable = false;
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Clear();

                ClientSend.SearchLevelBatlePve();
                UpdateEnemyPerson();
                this.gameObject.SetActive(false);
            }

            
        }
        
    }
    public void UpdateEnemyPerson()
    {
        foreach (var a in GameControll.instance.BattlePveInfoLevel)
        {
            
            string[] server_info = a.Split(',');
            if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Level == Convert.ToInt32(server_info[1]))
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().levelPerson = Convert.ToInt32(server_info[2]);
                if (server_info[3] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[3]);
                }
                if (server_info[4] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[4]);

                }
                if (server_info[5] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[5]);

                }
                if (server_info[6] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[6]);

                }
                if (server_info[7] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[7]);

                }
                if (server_info[8] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[8]);

                }
            }
            
            

        }
    }
    private void Update()
    {
        
        if (GameControll.instance.kvestPanel.activeSelf)
        {
            DownMenu.SetActive(false);
            BattleBtn.SetActive(true);
        }
        else if (GameControll.instance.PvePanel.activeSelf == true)
        {
            DownMenu.SetActive(false);
            BattleBtn.SetActive(true);
        }
        else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {
            DownMenu.SetActive(false);
            BattleBtn.SetActive(true);
        }
        else
        {
            DownMenu.SetActive(true);
            BattleBtn.SetActive(false);
        }
        bsText.text = bs.ToString();
        GameControll.instance.stroiFatherList.GetComponent<RectTransform>().sizeDelta = new Vector2(GameControll.instance.stroiFatherList.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.stroiFatherList.transform.childCount * 52);
        if (list == "pve")
        {
            pveimg.sprite = on;
            pvpimg.sprite = off;
        }
        else if (list == "pvp")
        {
            pveimg.sprite = off;
            pvpimg.sprite = on;
        }
    }
    public void pveBtn()
    {
        list = "pve";
        nameObj.Clear();
        while (imgstroi[0].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[0].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[0].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[0].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[0].transform.GetChild(0).gameObject;
            imgstroi[0].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }

        while (imgstroi[1].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[1].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[1].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[1].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[1].transform.GetChild(0).gameObject;
            imgstroi[1].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[2].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[2].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[2].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[2].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[2].transform.GetChild(0).gameObject;
            imgstroi[2].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[3].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[3].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[3].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[3].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[3].transform.GetChild(0).gameObject;
            imgstroi[3].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[4].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[4].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[4].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[4].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[4].transform.GetChild(0).gameObject;
            imgstroi[4].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[5].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[5].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[5].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[5].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[5].transform.GetChild(0).gameObject;
            imgstroi[5].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[6].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[6].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[6].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[6].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[6].transform.GetChild(0).gameObject;
            imgstroi[6].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[7].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[7].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[7].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[7].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[7].transform.GetChild(0).gameObject;
            imgstroi[7].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[8].transform.childCount > 0)
        {
            
            GameObject evo = imgstroi[8].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[8].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[8].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[8].transform.GetChild(0).gameObject;
            imgstroi[8].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        ClientSend.SearchStroiPerson(list);
    }
    public void pvpBtn()
    {
        list = "pvp";
        nameObj.Clear();
        while (imgstroi[0].transform.childCount > 0)
        {

            GameObject evo = imgstroi[0].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[0].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[0].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[0].transform.GetChild(0).gameObject;
            imgstroi[0].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }

        while (imgstroi[1].transform.childCount > 0)
        {

            GameObject evo = imgstroi[1].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[1].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[1].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[1].transform.GetChild(0).gameObject;
            imgstroi[1].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[2].transform.childCount > 0)
        {

            GameObject evo = imgstroi[2].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[2].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[2].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[2].transform.GetChild(0).gameObject;
            imgstroi[2].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[3].transform.childCount > 0)
        {

            GameObject evo = imgstroi[3].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[3].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[3].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[3].transform.GetChild(0).gameObject;
            imgstroi[3].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[4].transform.childCount > 0)
        {

            GameObject evo = imgstroi[4].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[4].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[4].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[4].transform.GetChild(0).gameObject;
            imgstroi[4].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[5].transform.childCount > 0)
        {

            GameObject evo = imgstroi[5].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[5].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[5].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[5].transform.GetChild(0).gameObject;
            imgstroi[5].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[6].transform.childCount > 0)
        {

            GameObject evo = imgstroi[6].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[6].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[6].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[6].transform.GetChild(0).gameObject;
            imgstroi[6].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[7].transform.childCount > 0)
        {

            GameObject evo = imgstroi[7].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[7].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[7].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[7].transform.GetChild(0).gameObject;
            imgstroi[7].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        while (imgstroi[8].transform.childCount > 0)
        {

            GameObject evo = imgstroi[8].transform.GetChild(0).gameObject.transform.Find("evo").gameObject;
            evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
            GameObject a = imgstroi[8].transform.GetChild(0).gameObject.transform.Find("Image").gameObject;
            a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
            imgstroi[8].GetComponent<stroiObj>().name = "";
            GameObject v = imgstroi[8].transform.GetChild(0).gameObject;
            imgstroi[8].transform.GetChild(0).transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
            v.transform.SetSiblingIndex(0);
        }
        ClientSend.SearchStroiPerson(list);
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
        GameControll.instance.PersonsButtonOn();
    }
}
