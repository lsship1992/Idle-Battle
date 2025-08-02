using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prizav : MonoBehaviour
{
    public Image back;
    public Image NamePersonImg;
    public Image PersonImg;
    public List<Sprite> PersonSprite = new List<Sprite>();
    public List<Sprite> PersonNameSprite = new List<Sprite>();
    public List<Sprite> backsprite = new List<Sprite>();
    public int list = 3;
    public GameObject Btn1Person;
    public GameObject Btn10Person;
    public GameObject PrefabWin;
    public GameObject PerentsWin;
    public GameObject WinPanel;
    public GameObject backByu;
    public int Svitok;
    public Sprite SvitokSprite;
    public Sprite GemSprite;
    public Image ValetImg1;
    public Image ValetImg10;
    public Text PriceText1;
    public Text PriceText10;
    public int idSvitok;
    private void Awake()
    {
        Btn1Person.GetComponent<Button>().onClick.AddListener(() => Person1());
        Btn10Person.GetComponent<Button>().onClick.AddListener(() => Person10());

    }
    public void WinPanelClose()
    {
        WinPanel.SetActive(false);
        backByu.SetActive(true);
        NamePersonImg.gameObject.SetActive(true);
        PersonImg.gameObject.SetActive(true);
    }
    public void Person1()
    {
        if (Svitok >= 1)
        {
            if (list == 3)
            {
                ClientSend.MaterialMinus(idSvitok, 1, "-");
                ClientSend.InventoryMaterialSearchUser();
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankA[Random.Range(0, GameControll.instance.VanpachRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankS[Random.Range(0, GameControll.instance.VanpachRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankSR[Random.Range(0, GameControll.instance.VanpachRankSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }

            else if (list == 7)
            {
                ClientSend.MaterialMinus(idSvitok, 1, "-");
                ClientSend.InventoryMaterialSearchUser();
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverRankA[Random.Range(0, GameControll.instance.BlackCleverRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverS[Random.Range(0, GameControll.instance.BlackCleverS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverSR[Random.Range(0, GameControll.instance.BlackCleverSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);
            }
        }
        else if (GameControll.instance.almazInt >= 300)
        {
            ClientSend.ValuteUpdate(300, "Almaz", "-");
            if (list == 3)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankA[Random.Range(0, GameControll.instance.VanpachRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankS[Random.Range(0, GameControll.instance.VanpachRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankSR[Random.Range(0, GameControll.instance.VanpachRankSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            if (list == 1)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokRankA[Random.Range(0, GameControll.instance.KlinokRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokS[Random.Range(0, GameControll.instance.KlinokS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokSR[Random.Range(0, GameControll.instance.KlinokSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            if (list == 2)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachRankA[Random.Range(0, GameControll.instance.BleachRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachS[Random.Range(0, GameControll.instance.BleachS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachSR[Random.Range(0, GameControll.instance.BleachSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            if (list == 4)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaRankA[Random.Range(0, GameControll.instance.MagichkaRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaS[Random.Range(0, GameControll.instance.MagichkaS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaSR[Random.Range(0, GameControll.instance.MagichkaSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            if (list == 5)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaRankA[Random.Range(0, GameControll.instance.AcademiaRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaS[Random.Range(0, GameControll.instance.AcademiaS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaSR[Random.Range(0, GameControll.instance.AcademiaSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            if (list == 6)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";
                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoRankA[Random.Range(0, GameControll.instance.NarutoRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoS[Random.Range(0, GameControll.instance.NarutoS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoSR[Random.Range(0, GameControll.instance.NarutoSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);

            }
            else if (list == 7)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                float rand = Random.Range(0f, 100f);
                if (rand >= 0 && rand <= 53)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "A";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 53.1f && rand <= 89)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Snar";
                    ButtonSearch.GetComponent<WinItem>().rank = "S";
                    if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                    {
                        ButtonSearch.GetComponent<WinItem>().Name = "Book";

                    }
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 89.1f && rand <= 98.1)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverRankA[Random.Range(0, GameControll.instance.BlackCleverRankA.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 98.2f && rand <= 99.6)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverS[Random.Range(0, GameControll.instance.BlackCleverS.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                else if (rand >= 99.7f && rand <= 100)
                {
                    GameObject ButtonSearch = Instantiate(PrefabWin);
                    ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                    ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverSR[Random.Range(0, GameControll.instance.BlackCleverSR.Count)];
                    ButtonSearch.GetComponent<WinItem>().type = "Person";
                    ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);
            }

        }
    }
    public void Person10()
    {
        if (Svitok >= 10)
        {
            if (list == 7)
            {
                Debug.Log("2");
                ClientSend.MaterialMinus(idSvitok, 10, "-");
                ClientSend.InventoryMaterialSearchUser();
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverRankA[Random.Range(0, GameControll.instance.BlackCleverRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverS[Random.Range(0, GameControll.instance.BlackCleverS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverSR[Random.Range(0, GameControll.instance.BlackCleverSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 3)
            {
                ClientSend.MaterialMinus(idSvitok, 10, "-");
                ClientSend.InventoryMaterialSearchUser();
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankA[Random.Range(0, GameControll.instance.VanpachRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankS[Random.Range(0, GameControll.instance.VanpachRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankSR[Random.Range(0, GameControll.instance.VanpachRankSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
        }
        else if (GameControll.instance.almazInt >= 2700)
        {
            ClientSend.ValuteUpdate(2700, "Almaz", "-");
            if (list == 7)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverRankA[Random.Range(0, GameControll.instance.BlackCleverRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverS[Random.Range(0, GameControll.instance.BlackCleverS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BlackCleverSR[Random.Range(0, GameControll.instance.BlackCleverSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 1)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokRankA[Random.Range(0, GameControll.instance.KlinokRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokS[Random.Range(0, GameControll.instance.KlinokS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.KlinokSR[Random.Range(0, GameControll.instance.KlinokSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 2)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachRankA[Random.Range(0, GameControll.instance.BleachRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachS[Random.Range(0, GameControll.instance.BleachS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.BleachSR[Random.Range(0, GameControll.instance.BleachSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 4)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaRankA[Random.Range(0, GameControll.instance.MagichkaRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaS[Random.Range(0, GameControll.instance.MagichkaS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.MagichkaSR[Random.Range(0, GameControll.instance.MagichkaSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 5)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaRankA[Random.Range(0, GameControll.instance.AcademiaRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaS[Random.Range(0, GameControll.instance.AcademiaS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.AcademiaSR[Random.Range(0, GameControll.instance.AcademiaSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 6)
            {
                Debug.Log("2");

                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    Debug.Log("3");

                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoRankA[Random.Range(0, GameControll.instance.NarutoRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoS[Random.Range(0, GameControll.instance.NarutoS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.NarutoSR[Random.Range(0, GameControll.instance.NarutoSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }
                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
            else if (list == 3)
            {
                while (PerentsWin.transform.childCount > 0)
                {
                    DestroyImmediate(PerentsWin.transform.GetChild(0).gameObject);
                }
                for (int i = 0; i != 10; i++)
                {
                    float rand = Random.Range(0f, 100f);
                    if (rand >= 0 && rand <= 53)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "A";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 53.1f && rand <= 89)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().name_ru = GameControll.instance.SnarRankS[Random.Range(0, GameControll.instance.SnarRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Snar";
                        ButtonSearch.GetComponent<WinItem>().rank = "S";
                        if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Speed ​​Spells")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        else if (GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Attack Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Health Spell Book 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Book of Spells of Protection 2" || GameControll.instance.SnarRankA[Random.Range(0, GameControll.instance.SnarRankA.Count)] == "Speed Spell Book 2")
                        {
                            ButtonSearch.GetComponent<WinItem>().Name = "Book";

                        }
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 89.1f && rand <= 98.1)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankA[Random.Range(0, GameControll.instance.VanpachRankA.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 98.2f && rand <= 99.6)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankS[Random.Range(0, GameControll.instance.VanpachRankS.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }
                    else if (rand >= 99.7f && rand <= 100)
                    {
                        GameObject ButtonSearch = Instantiate(PrefabWin);
                        ButtonSearch.transform.SetParent(PerentsWin.transform, false);
                        ButtonSearch.GetComponent<WinItem>().Name = GameControll.instance.VanpachRankSR[Random.Range(0, GameControll.instance.VanpachRankSR.Count)];
                        ButtonSearch.GetComponent<WinItem>().type = "Person";
                        ClientSend.PrizivAdd(ButtonSearch.GetComponent<WinItem>().rank, ButtonSearch.GetComponent<WinItem>().Name, ButtonSearch.GetComponent<WinItem>().name_ru, ButtonSearch.GetComponent<WinItem>().type);

                    }

                }

                backByu.SetActive(false);
                NamePersonImg.gameObject.SetActive(false);
                PersonImg.gameObject.SetActive(false);
                WinPanel.SetActive(true);


            }
        }
    }
    private void Update()
    {
        if (Svitok >= 1)
        {
            ValetImg1.sprite = SvitokSprite;
            ValetImg10.sprite = SvitokSprite;
            PriceText1.text = "1";
            PriceText10.text = "10";
            if (Svitok >= 10)
            {
                PriceText10.color = Color.black;
            }
            else
            {
                PriceText10.color = Color.red;

            }
        }
        else
        {
            ValetImg1.sprite = GemSprite;
            ValetImg10.sprite = GemSprite;
            PriceText1.text = "300";
            PriceText10.text = "2700";
            if (GameControll.instance.almazInt < 300)
            {
                PriceText1.color = Color.red;
            }
            if (GameControll.instance.almazInt < 2700)
            {
                PriceText10.color = Color.red;
            }
        }
        if (list == 1)
        {
            back.sprite = backsprite[0];
            NamePersonImg.sprite = PersonNameSprite[0];
            PersonImg.sprite = PersonSprite[0];
        }
        else if (list == 2)
        {
            back.sprite = backsprite[1];
            NamePersonImg.sprite = PersonNameSprite[1];
            PersonImg.sprite = PersonSprite[1];
        }
        else if (list == 3)
        {
            back.sprite = backsprite[2];
            NamePersonImg.sprite = PersonNameSprite[2];
            PersonImg.sprite = PersonSprite[2];
        }
        else if (list == 4)
        {
            back.sprite = backsprite[3];
            NamePersonImg.sprite = PersonNameSprite[3];
            PersonImg.sprite = PersonSprite[3];
        }
        else if (list == 5)
        {
            back.sprite = backsprite[4];
            NamePersonImg.sprite = PersonNameSprite[4];
            PersonImg.sprite = PersonSprite[4];
        }
        else if (list == 6)
        {
            back.sprite = backsprite[5];
            NamePersonImg.sprite = PersonNameSprite[5];
            PersonImg.sprite = PersonSprite[5];
        }
        else if (list == 7)
        {
            back.sprite = backsprite[6];
            NamePersonImg.sprite = PersonNameSprite[6];
            PersonImg.sprite = PersonSprite[6];
        }
    }

    public void vpered()
    {
        if (list == 3)
        {
            list = 7;
        }
        else if (list == 7)
        {
            list = 3;
        }
        /*
        if (list == 7)
        {
            list = 1;
        }
        else
        {
            list += 1;
        }*/
    }
    public void nazad()
    {
        if (list == 3)
        {
            list = 7;
        }
        else if (list == 7)
        {
            list = 3;
        }
        /*
        if (list == 1)
        {
            list = 7;
        }
        else
        {
            list -= 1;
        }
        */
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
