using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PersControlScript : MonoBehaviour
{
    [SerializeField] private Image Image;

    public string name;
    public int id;
    public string rank;
    private int MaxLevel = 0;
    [SerializeField] private Text levelText;
    [SerializeField] private Text goldUpdateText;
    [SerializeField] private Text opitUpdateText;
    [SerializeField] private Text goldAllUpdateText;
    [SerializeField] private Text opitAllUpdateText;
    [SerializeField] private Text ButtonUpLevelText;
    [SerializeField] private Text silaText;
    //[SerializeField] private Text NextUpText;
    [SerializeField] private Text AttackText;
    [SerializeField] private Text HpText;
    [SerializeField] private Text DefensText;
    [SerializeField] private Text SpeedText;
    [SerializeField] private Image Rang;
    [SerializeField] private List<Sprite> RangSprite = new List<Sprite>();
    [SerializeField] public List<Sprite> DefaultSpriteIcon = new List<Sprite>();
    public int level;
    public int levelEvo;
    public string Class;
    public int Attack;
    public int Hp;
    public int Defens;
    public int Speed;
    public float gold;
    public float opit;
    public float goldAll;
    public float opitAll;
    public List<GameObject> Item = new List<GameObject>();
    public string nameItem;
    public int idSlot;
    private bool UpdateLevel;
    private float Attack_info = 0;
    private float Hp_info = 0;
    private float Defens_info = 0;
    private float Speed_info = 0;
    public GameObject evalution;
    public Button ButtonEvalution;
    public int DamageReduction;
    public int CritDamage;
    public int CritChance;
    public int Evasion;
    public int Accuracy;
    public int DamageBonus;
    public int AntiCrit;
    public int Control;
    public int AntiControl;
    public int Treatment;
    public int Recovery;
    [SerializeField] private GameObject DopInfoPerson;
    public Image isEvol;
    public Text NameText;
    public GameObject InfoItem;
    public GameObject skilsPanel;
    public void DopInfoOpenOnClose()
    {
        DopInfoPerson.GetComponent<DopInfoPerson>().Attack = Attack_info;
        DopInfoPerson.GetComponent<DopInfoPerson>().Defens = Defens_info;
        DopInfoPerson.GetComponent<DopInfoPerson>().Speed = Speed_info;
        DopInfoPerson.GetComponent<DopInfoPerson>().Hp = Hp_info;
        DopInfoPerson.GetComponent<DopInfoPerson>().DamageReduction = DamageReduction;
        DopInfoPerson.GetComponent<DopInfoPerson>().CritDamage = CritDamage;
        DopInfoPerson.GetComponent<DopInfoPerson>().CritChance = CritChance;
        DopInfoPerson.GetComponent<DopInfoPerson>().Evasion = Evasion;
        DopInfoPerson.GetComponent<DopInfoPerson>().Accuracy = Accuracy;
        DopInfoPerson.GetComponent<DopInfoPerson>().DamageBonus = DamageBonus;
        DopInfoPerson.GetComponent<DopInfoPerson>().AntiCrit = AntiCrit;
        DopInfoPerson.GetComponent<DopInfoPerson>().Control = Control;
        DopInfoPerson.GetComponent<DopInfoPerson>().AntiControl = AntiControl;
        DopInfoPerson.GetComponent<DopInfoPerson>().Treatment = Treatment;
        DopInfoPerson.GetComponent<DopInfoPerson>().Recovery = Recovery;

        DopInfoPerson.SetActive(!DopInfoPerson.activeSelf);
    }
    private void Awake()
    {
        Item[0].GetComponent<Button>().onClick.AddListener(() => Helmet());
        Item[1].GetComponent<Button>().onClick.AddListener(() => Armor());
        Item[2].GetComponent<Button>().onClick.AddListener(() => Gloves());
        Item[3].GetComponent<Button>().onClick.AddListener(() => bots());
        Item[4].GetComponent<Button>().onClick.AddListener(() => Weapon());
        Item[5].GetComponent<Button>().onClick.AddListener(() => Rings());
        Item[6].GetComponent<Button>().onClick.AddListener(() => Earrings());
        Item[7].GetComponent<Button>().onClick.AddListener(() => Necklace());
        Item[8].GetComponent<Button>().onClick.AddListener(() => Book1());
        ButtonEvalution.GetComponent<Button>().onClick.AddListener(() => ButtonEvalutionVoid());
        //Item[9].GetComponent<Button>().onClick.AddListener(() => Book2());
    }
    public void ButtonSkilsVoid()
    {
        
        ClientSend.SearchPersonPanel(GameControll.instance.personPanel.gameObject.GetComponent<PersControlScript>().id);
        skilsPanel.SetActive(true);
        
    }
    public void ButtonEvalutionVoid()
    {
        foreach (var st in GameControll.instance.MaterialLoad)
        {
            string[] server_info = st.Split(',');
            if (server_info[0] == "UserUpdateMaterial")
            {
                evalution.GetComponent<evalutionPanelScript>().Material = Convert.ToInt32(server_info[2]);
                evalution.GetComponent<evalutionPanelScript>().IdMaterial = Convert.ToInt32(server_info[1]);

            }
            else
            {
                evalution.GetComponent<evalutionPanelScript>().Material = 0;
                evalution.GetComponent<evalutionPanelScript>().IdMaterial = 0;

            }
        }
        evalution.GetComponent<evalutionPanelScript>().level = level;
        evalution.GetComponent<evalutionPanelScript>().EvoLevel = levelEvo;
        evalution.GetComponent<evalutionPanelScript>().EvoLevel = levelEvo;
        evalution.GetComponent<evalutionPanelScript>().Hp = Convert.ToInt32(Hp_info);
        evalution.GetComponent<evalutionPanelScript>().Attack = Convert.ToInt32(Attack_info);
        evalution.GetComponent<evalutionPanelScript>().Defens = Convert.ToInt32(Defens_info);
        evalution.GetComponent<evalutionPanelScript>().Speed = Convert.ToInt32(Defens_info);
        evalution.GetComponent<evalutionPanelScript>().Rang = rank;
        evalution.SetActive(true);
    }
    public void UpLevel()
    {
        
        if (level < MaxLevel)
        {
            int levelM = 0;
            if (levelEvo == 0)
            {
                levelM = 100;
            }
            else if (levelEvo == 1)
            {
                levelM = 150;
            }
            else if (levelEvo == 2)
            {
                levelM = 200;
            }
            else if (levelEvo == 3)
            {
                levelM = 250;
            }
            else if (levelEvo == 4)
            {
                levelM = 300;
            }
            else if (levelEvo == 5)
            {
                levelM = 340;
            }
            else if (levelEvo == 6)
            {
                levelM = 380;
            }
            else if (levelEvo == 7)
            {
                levelM = 420;
            }
            else if (levelEvo == 8)
            {
                levelM = 460;
            }
            else if (levelEvo == 9)
            {
                levelM = 500;
            }
            else if (levelEvo == 10)
            {
                levelM = 520;
            }
            /*
            if (goldAll >= (gold * 1.023f * 1.023f * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f * 1.023f * 1.023f) && (level + 5) <= MaxLevel)
            {
                goldAll = goldAll - (gold * 1.023f * 1.023f * 1.023f * 1.023f);
                opitAll = opitAll - (opit * 1.023f * 1.023f * 1.023f * 1.023f);
                level = level + 5;
                UpdateLevel = false;
                UpdateLevelDef();

            }
            else if (goldAll >= (gold * 1.023f * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f * 1.023f) && (level + 4) <= MaxLevel)
            {
                level = level + 4;
                goldAll = goldAll - (gold * 1.01f * 1.01f * 1.01f);
                opitAll = opitAll - (opit * 1.01f * 1.01f * 1.01f);
                UpdateLevel = false;
                UpdateLevelDef();
            }
            else if (goldAll >= (gold * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f) && (level + 3) <= MaxLevel)
            {
                UpdateLevel = false;
                level = level + 3;
                goldAll = goldAll - (gold * 1.023f * 1.023f);
                opitAll = opitAll - (opit * 1.023f * 1.023f);
                UpdateLevelDef();
            }
            else if (goldAll >= (gold * 1.023f) && opitAll >= (opit * 1.023f) && (level + 2) <= MaxLevel)
            {
                UpdateLevel = false;
                level = level + 2;
                goldAll = goldAll - (gold * 1.023f);
                opitAll = opitAll - (opit * 1.023f);
                UpdateLevelDef();

            }*/
            if (goldAll >= gold && opitAll >= opit && (level + 1) <= MaxLevel && (level + 1) <= levelM)
            {
                level = level + 1;
                UpdateLevel = false;
                goldAll = goldAll - gold;
                opitAll = opitAll - opit;
                ClientSend.ValuteUpdate((int)gold, "Gold", "-");
                ClientSend.ValuteUpdate((int)opit, "OpitPerson", "-");
                ClientSend.UpdateLevelPerson(level, id);
                UpdateLevelDef();
            }
        }
        
    }
    public void Book1()
    {
        nameItem = "Book";

        if (Item[8].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[8].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[8].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[8].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[8].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[8].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[8].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[8].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[8].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);

        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            idSlot = 1;
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);

        }

    }
    public void Book2()
    {
        while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
        }
        nameItem = "Book";
        idSlot = 2;
        ClientSend.InventorySearchUser();
        GameControll.instance.Inventory.SetActive(true);
    }
    public void Helmet()
    {
        nameItem = "Helmet";

        if (Item[0].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[0].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[0].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[0].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[0].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[0].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[0].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[0].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[0].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);

        }

    }
    public void Armor()
    {
        nameItem = "Armor";
        if (Item[1].GetComponent<SelectItemScript>().Nameru != "")
        {

            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[1].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[1].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[1].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[1].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[1].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[1].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[1].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[1].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);

        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }

            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void Gloves()
    {
        nameItem = "Gloves";

        if (Item[2].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[2].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[2].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[2].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[2].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[2].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[2].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[2].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[2].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void bots()
    {
        nameItem = "Bots";

        if (Item[3].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[3].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[3].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[3].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[3].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[3].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[3].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[3].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[3].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void Weapon()
    {
        nameItem = "Weapon";

        if (Item[4].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[4].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[4].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[4].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[4].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[4].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[4].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[4].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[4].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void Rings()
    {
        nameItem = "Rings";

        if (Item[5].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[5].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[5].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[5].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[5].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[5].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[5].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[5].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[5].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void Earrings()
    {
        nameItem = "Earrings";

        if (Item[6].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[6].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[6].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[6].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[6].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[6].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[6].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[6].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[6].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void Necklace()
    {
        nameItem = "Necklace";

        if (Item[7].GetComponent<SelectItemScript>().Nameru != "")
        {
            InfoItem.GetComponent<InfoItemPersonScript>().Nameru = Item[7].GetComponent<SelectItemScript>().Nameru;
            InfoItem.GetComponent<InfoItemPersonScript>().RangItem = Item[7].GetComponent<SelectItemScript>().RangItem;
            InfoItem.GetComponent<InfoItemPersonScript>().Attack = Item[7].GetComponent<SelectItemScript>().attack;
            InfoItem.GetComponent<InfoItemPersonScript>().Defens = Item[7].GetComponent<SelectItemScript>().defens;
            InfoItem.GetComponent<InfoItemPersonScript>().Speed = Item[7].GetComponent<SelectItemScript>().speed;
            InfoItem.GetComponent<InfoItemPersonScript>().Hp = Item[7].GetComponent<SelectItemScript>().hp;
            InfoItem.GetComponent<InfoItemPersonScript>().id = Item[7].GetComponent<SelectItemScript>().id;
            InfoItem.GetComponent<InfoItemPersonScript>().NameItem = Item[7].GetComponent<SelectItemScript>().NameItem;
            InfoItem.SetActive(true);
        }
        else
        {
            while (GameControll.instance.InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            GameControll.instance.Inventory.SetActive(true);
        }

    }
    public void UpdateItemBook1()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Book")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().description = "";

                    }



                }


            }
            catch
            {

            }

        }
    }
    public void UpdateItemNecklace()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Necklace")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().description = "";

                    }



                }


            }
            catch
            {

            }

        }
    }
    public void UpdateItemEarrings()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Earrings")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().description = "";

                    }



                }


            }
            catch
            {

            }

        }
    }
    public void UpdateItemRings()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Rings")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().description = "";

                    }



                }

            }
            catch
            {

            }

        }
    }
    public void UpdateItemGloves()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Gloves")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().description = "";

                    }



                }






            }
            catch
            {

            }

        }
    }
    public void UpdateItemArmor()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Armor")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().description = "";

                    }



                }





            }
            catch
            {

            }

        }
    }
    public void UpdateItemWeapon()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Weapon")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().description = "";

                    }



                }




            }
            catch
            {

            }

        }
    }
    public void UpdateItembots()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');

                if (server_info[0] == "Bots")
                {

                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().description = "";

                    }



                }



            }
            catch
            {

            }

        }
    }
    public void UpdateItemHelmet()
    {
        Debug.Log("Нажаьте");
        Debug.Log(GameControll.instance.ItemLoad);
        foreach (var item in GameControll.instance.ItemLoad)
        {
            try
            {
                string[] server_info = item.Split(',');
                
                if (server_info[0] == "Helmet")
                {
                    
                    if (Convert.ToInt32(server_info[10]) == id)
                    {
                        Debug.Log(server_info[0]);
                        Debug.Log(server_info[10]);
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int CritDamage = 0;
                        int DamageBonus = 0;
                        try
                        {
                            attack = Convert.ToInt32(server_info[2]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            defens = Convert.ToInt32(server_info[3]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed = Convert.ToInt32(server_info[4]);
                        }
                        catch
                        {


                        }
                        try
                        {
                            hp = Convert.ToInt32(server_info[5]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            attack_proc = Convert.ToInt32(server_info[6]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            hp_proc = Convert.ToInt32(server_info[7]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            CritDamage = Convert.ToInt32(server_info[8]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DamageBonus = Convert.ToInt32(server_info[9]);
                        }
                        catch
                        {

                        }


                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().NameItem = server_info[0];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().RangItem = server_info[1];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().attack = attack;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().defens = defens;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().speed = speed;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().hp = hp;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._attack_Proc = attack_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._hp_proc = hp_proc;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().id = Convert.ToInt32(server_info[11]);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().idPerson = id;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().Nameru = server_info[12];
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().description = server_info[13];
                        break;
                    }
                    else
                    {
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().NameItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().RangItem = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().attack = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().defens = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().speed = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().hp = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._attack_Proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._hp_proc = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().CritDamage = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().DamageBonus = 0;
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().Nameru = "";
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().description = "";

                    }



                }
                

            }
            catch
            {

            }

        }
    }
    public void UpdateLevelDef()
    {
        Attack_info = 0;
        Hp_info = 0;
        Defens_info = 0;
        Speed_info = 0;
        float _attack = Attack;
        float _hp = Hp;
        float _defens = Defens;
        float _speed = Speed;

        for (int i = 0; i < levelEvo + 1; i++)
        {
            
            if (i == 1)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
            }
            else if (i == 2)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
            }
            else if (i == 3)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 4)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 5)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 6)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 7)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 8)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 9)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 10)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
        }

        for (int i = 0; i < level; i++)
        {
            if (i < 50)
            {
                _attack = _attack * 1.045f;
                _hp = _hp * 1.044f;
                _defens = _defens * 1.021f;
                _speed = _speed * 1.021f;
            }
            else if (i >= 50 && i < 80)
            {
                _attack = _attack * 1.035f;
                _hp = _hp * 1.034f;
                _defens = _defens * 1.015f;
                _speed = _speed * 1.021f;
            }
            else if (i >= 80 && i < 100)
            {
                _attack = _attack * 1.03f;
                _hp = _hp * 1.03f;
                _defens = _defens * 1.015f;
                _speed = _speed * 1.015f;
            }
            else if (i >= 100 && i < 150)
            {
                _attack = _attack * 1.02f;
                _hp = _hp * 1.02f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 150 && i < 200)
            {
                _attack = _attack * 1.02f;
                _hp = _hp * 1.02f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 200 && i < 250)
            {
                _attack = _attack * 1.01f;
                _hp = _hp * 1.01f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 250 && i < 300)
            {
                _attack = _attack * 1.008f;
                _hp = _hp * 1.007f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 300 && i < 340)
            {
                _attack = _attack * 1.007f;
                _hp = _hp * 1.006f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 340 && i < 380)
            {
                _attack = _attack * 1.006f;
                _hp = _hp * 1.005f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 380 && i < 420)
            {
                _attack = _attack * 1.004f;
                _hp = _hp * 1.003f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 420 && i < 460)
            {
                _attack = _attack * 1.003f;
                _hp = _hp * 1.002f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 460 && i < 500)
            {
                _attack = _attack * 1.002f;
                _hp = _hp * 1.002f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 500 && i <= 520)
            {
                _attack = _attack * 1.001f;
                _hp = _hp * 1.001f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            
        }
        Attack_info = _attack + Item[0].GetComponent<SelectItemScript>().attack + Item[1].GetComponent<SelectItemScript>().attack + Item[2].GetComponent<SelectItemScript>().attack + Item[3].GetComponent<SelectItemScript>().attack + Item[4].GetComponent<SelectItemScript>().attack + Item[5].GetComponent<SelectItemScript>().attack + Item[6].GetComponent<SelectItemScript>().attack + Item[7].GetComponent<SelectItemScript>().attack + Item[8].GetComponent<SelectItemScript>().attack + Item[9].GetComponent<SelectItemScript>().attack;
        Hp_info = _hp + Item[0].GetComponent<SelectItemScript>().hp + Item[1].GetComponent<SelectItemScript>().hp + Item[2].GetComponent<SelectItemScript>().hp + Item[3].GetComponent<SelectItemScript>().hp + Item[4].GetComponent<SelectItemScript>().hp + Item[5].GetComponent<SelectItemScript>().hp + Item[6].GetComponent<SelectItemScript>().hp + Item[7].GetComponent<SelectItemScript>().hp + Item[7].GetComponent<SelectItemScript>().hp + Item[8].GetComponent<SelectItemScript>().hp + Item[9].GetComponent<SelectItemScript>().hp;
        Defens_info = _defens + Item[0].GetComponent<SelectItemScript>().defens + Item[1].GetComponent<SelectItemScript>().defens + Item[2].GetComponent<SelectItemScript>().defens + Item[3].GetComponent<SelectItemScript>().defens + Item[4].GetComponent<SelectItemScript>().defens + Item[5].GetComponent<SelectItemScript>().defens + Item[6].GetComponent<SelectItemScript>().defens + Item[7].GetComponent<SelectItemScript>().defens + Item[8].GetComponent<SelectItemScript>().defens + Item[9].GetComponent<SelectItemScript>().defens;
        Speed_info = _speed + Item[0].GetComponent<SelectItemScript>().speed + Item[1].GetComponent<SelectItemScript>().speed + Item[2].GetComponent<SelectItemScript>().speed + Item[3].GetComponent<SelectItemScript>().speed + Item[4].GetComponent<SelectItemScript>().speed + Item[5].GetComponent<SelectItemScript>().speed + Item[6].GetComponent<SelectItemScript>().speed + Item[7].GetComponent<SelectItemScript>().speed + Item[8].GetComponent<SelectItemScript>().speed + Item[9].GetComponent<SelectItemScript>().speed;
        //Подсчет процента атаки
        Attack_info = Attack_info * (100 + Item[0].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[1].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[2].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[3].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[4].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[5].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[6].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[7].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[8].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        //Подсчет процента хп
        Hp_info = Hp_info * (100 + Item[0].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[1].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[2].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[3].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[4].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[5].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[6].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[7].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[8].GetComponent<SelectItemScript>()._hp_proc) / 100;
        //Подсчет процента Защиты
        Defens_info = Defens_info * (100 + Item[0].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[1].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[2].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[3].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[4].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[5].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[6].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[7].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[8].GetComponent<SelectItemScript>().defens_proc) / 100;
        //Подсчет процента Скорости
        Speed_info = Speed_info * (100 + Item[0].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[1].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[2].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[3].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[4].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[5].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[6].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[7].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[8].GetComponent<SelectItemScript>().speed_proc) / 100;



        silaText.text = $"{(BigInteger)((Attack_info /2) + (Hp_info /2) + (Defens_info * 2.5f) + (Speed_info * 6.4f))}";

    }
    private void Update()
    {
        
        //opitAll = PlayerPrefs.GetFloat("opit");
        //goldAll = PlayerPrefs.GetFloat("gold");
        goldUpdateText.text = Convert.ToString((BigInteger)gold);
        opitUpdateText.text = Convert.ToString((BigInteger)opit);
        opitAllUpdateText.text = Convert.ToString((BigInteger)opitAll);
        goldAllUpdateText.text = Convert.ToString((BigInteger)goldAll);
        if (levelEvo == 10)
        {
            ButtonEvalution.gameObject.SetActive(false);
        }
        else
        {
            ButtonEvalution.gameObject.SetActive(true);

        }
        if (level == 1)
        {
            gold = 410f;
            opit = 305f;
        }
        else
        {
            if (UpdateLevel == false)
            {
                float _gold = 410f;
                float _opit = 305f;
                //gold = 101;
                //opit = 56;
                for (int i = 0; i < level; i++)
                {
                    if (i < 50)
                    {
                        _gold = _gold * 1.1f;
                        _opit = _opit * 1.1f;
                    }
                    else if (i >= 50 && i < 80)
                    {
                        _gold = _gold * 1.03f;
                        _opit = _opit * 1.03f;
                    }
                    else if (i >= 80 && i < 100)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 100 && i < 150)
                    {
                        _gold = _gold * 1.015f;
                        _opit = _opit * 1.015f;
                    }
                    else if (i >= 150 && i < 200)
                    {
                        _gold = _gold * 1.015f;
                        _opit = _opit * 1.015f;
                    }
                    else if (i >= 200 && i < 250)
                    {
                        _gold = _gold * 1.015f;
                        _opit = _opit * 1.015f;
                    }
                    else if (i >= 250 && i < 300)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 300 && i < 340)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 340 && i < 380)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 380 && i < 420)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 420 && i < 460)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 460 && i < 500)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }
                    else if (i >= 500 && i <= 520)
                    {
                        _gold = _gold * 1.01f;
                        _opit = _opit * 1.01f;
                    }

                }
                gold = _gold;
                opit = _opit;
                UpdateLevel = true;
                Debug.Log(gold);
            }
            
        }
        if (rank == "A")
        {
            MaxLevel = 300;
        }
        else
        {
            MaxLevel = 520;
        }
        /*
        if (goldAll >= (gold * 1.023f * 1.023f * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f * 1.023f * 1.023f) && (level + 5) <= MaxLevel)
        {
            ButtonUpLevelText.text = "Повысить: 5 ур.";

        }
        else if (goldAll >= (gold * 1.023f * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f * 1.023f) && (level + 4) <= MaxLevel)
        {
            ButtonUpLevelText.text = "Повысить: 4 ур.";

        }
        else if (goldAll >= (gold * 1.023f * 1.023f) && opitAll >= (opit * 1.023f * 1.023f) && (level + 3) <= MaxLevel)
        {
            ButtonUpLevelText.text = "Повысить: 3 ур.";

        }
        else if (goldAll >= (gold * 1.023f) && opitAll >= (opit * 1.023f) && (level + 2) <= MaxLevel)
        {
            ButtonUpLevelText.text = "Повысить: 2 ур.";


        }*/
        NameText.text = name;
        if (levelEvo == 0)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[0];
        }
        else if (levelEvo == 1)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[1];
        }
        else if (levelEvo == 2)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[2];
        }
        else if (levelEvo == 3)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[3];
        }
        else if (levelEvo == 4)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[4];
        }
        else if (levelEvo == 5)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[5];
        }
        else if (levelEvo == 6)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[6];
        }
        else if (levelEvo == 7)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[7];
        }
        else if (levelEvo == 8)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[8];
        }
        else if (levelEvo == 9)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[9];
        }
        else if (levelEvo == 10)
        {
            isEvol.sprite = evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[10];
        }

        int levelM = 0;
        if (levelEvo == 0)
        {
            levelM = 100;
        }
        else if (levelEvo == 1)
        {
            levelM = 150;
        }
        else if (levelEvo == 2)
        {
            levelM = 200;
        }
        else if (levelEvo == 3)
        {
            levelM = 250;
        }
        else if (levelEvo == 4)
        {
            levelM = 300;
        }
        else if (levelEvo == 5)
        {
            levelM = 340;
        }
        else if (levelEvo == 6)
        {
            levelM = 380;
        }
        else if (levelEvo == 7)
        {
            levelM = 420;
        }
        else if (levelEvo == 8)
        {
            levelM = 460;
        }
        else if (levelEvo == 9)
        {
            levelM = 500;
        }
        else if (levelEvo == 10)
        {
            levelM = 520;
        }
        if (goldAll >= gold && opitAll >= opit && (level + 1) <= MaxLevel && (level + 1) <= levelM)
        {
            ButtonUpLevelText.text = "Повысить: 1 ур.";
            
        }
        else
        {
            ButtonUpLevelText.text = "Повысить";
        }
        if (rank == "A")
        {
            Rang.sprite = RangSprite[0];
            if (levelEvo == 0)
            {
                levelText.text = $"Ур.: {level}/100";
            }
            else if (levelEvo == 1)
            {
                levelText.text = $"Ур.: {level}/150";
            }
            else if (levelEvo == 2)
            {
                levelText.text = $"Ур.: {level}/200";
            }
            else if (levelEvo == 3)
            {
                levelText.text = $"Ур.: {level}/250";
            }
            else if (levelEvo == 4)
            {
                levelText.text = $"Ур.: {level}/300";
            }
            else if (levelEvo == 5)
            {
                levelText.text = $"Ур.: {level}/340";
            }
            else if (levelEvo == 6)
            {
                levelText.text = $"Ур.: {level}/380";
            }
            
            
        }
        else if (rank == "S")
        {
            Rang.sprite = RangSprite[1];
            if (levelEvo == 0)
            {
                levelText.text = $"Ур.: {level}/100";
            }
            else if (levelEvo == 1)
            {
                levelText.text = $"Ур.: {level}/150";
            }
            else if (levelEvo == 2)
            {
                levelText.text = $"Ур.: {level}/200";
            }
            else if (levelEvo == 3)
            {
                levelText.text = $"Ур.: {level}/250";
            }
            else if (levelEvo == 4)
            {
                levelText.text = $"Ур.: {level}/300";
            }
            else if (levelEvo == 5)
            {
                levelText.text = $"Ур.: {level}/340";
            }
            else if (levelEvo == 6)
            {
                levelText.text = $"Ур.: {level}/380";
            }
            else if (levelEvo == 7)
            {
                levelText.text = $"Ур.: {level}/420";
            }
            else if (levelEvo == 8)
            {
                levelText.text = $"Ур.: {level}/460";
            }
            else if (levelEvo == 9)
            {
                levelText.text = $"Ур.: {level}/500";
            }
            else if (levelEvo == 10)
            {
                levelText.text = $"Ур.: {level}/520";
            }

        }
        else if (rank == "SR")
        {
            Rang.sprite = RangSprite[2];
            if (levelEvo == 0)
            {
                levelText.text = $"Ур.: {level}/100";
            }
            else if (levelEvo == 1)
            {
                levelText.text = $"Ур.: {level}/150";
            }
            else if (levelEvo == 2)
            {
                levelText.text = $"Ур.: {level}/200";
            }
            else if (levelEvo == 3)
            {
                levelText.text = $"Ур.: {level}/250";
            }
            else if (levelEvo == 4)
            {
                levelText.text = $"Ур.: {level}/300";
            }
            else if (levelEvo == 5)
            {
                levelText.text = $"Ур.: {level}/340";
            }
            else if (levelEvo == 6)
            {
                levelText.text = $"Ур.: {level}/380";
            }
            else if (levelEvo == 7)
            {
                levelText.text = $"Ур.: {level}/420";
            }
            else if (levelEvo == 8)
            {
                levelText.text = $"Ур.: {level}/460";
            }
            else if (levelEvo == 9)
            {
                levelText.text = $"Ур.: {level}/500";
            }
            else if (levelEvo == 10)
            {
                levelText.text = $"Ур.: {level}/520";
            }

        }
        AttackText.text = $"{(BigInteger)Attack_info}";
        HpText.text = $"{(BigInteger)Hp_info}";
        DefensText.text = $"{(BigInteger)Defens_info}";
        SpeedText.text = $"{(BigInteger)Speed_info}";
        
        if (name == "King")
        {
            Image.sprite = GameControll.instance.pers[0];
        }
        else if (name == "The villain with the whip")
        {
            Image.sprite = GameControll.instance.pers[1];

        }
        else if (name == "Genos")
        {
            Image.sprite = GameControll.instance.pers[2];

        }
        else if (name == "Tatsumaki Tornado")
        {
            Image.sprite = GameControll.instance.pers[3];

        }
        else if (name == "Isamu the Cruel Emperor")
        {
            Image.sprite = GameControll.instance.pers[4];

        }
        else if (name == "Suiryu")
        {
            Image.sprite = GameControll.instance.pers[5];

        }
        else if (name == "Bad Steel Bat")
        {
            Image.sprite = GameControll.instance.pers[6];

        }
        else if (name == "The master in a Tshirt")
        {
            Image.sprite = GameControll.instance.pers[7];

        }
        else if (name == "Kamikaze Atomic Samurai")
        {
            Image.sprite = GameControll.instance.pers[8];

        }
        else if (name == "Asta")
        {
            Image.sprite = GameControll.instance.pers[9];

        }
        else if (name == "Noel Silver")
        {
            Image.sprite = GameControll.instance.pers[10];

        }
        else if (name == "Yami Sukehiro")
        {
            Image.sprite = GameControll.instance.pers[11];

        }
        else if (name == "Yuno")
        {
            Image.sprite = GameControll.instance.pers[12];

        }
        else if (name == "William Wanjins")
        {
            Image.sprite = GameControll.instance.pers[13];

        }
        else if (name == "Mereoleon The Crimson Lion")
        {
            Image.sprite = GameControll.instance.pers[14];

        }
        else if (name == "Fana")
        {
            Image.sprite = GameControll.instance.pers[15];

        }
        else if (name == "Finral Rollcase")
        {
            Image.sprite = GameControll.instance.pers[16];

        }
        
        else if (name == "Julius Novochrono")
        {
            Image.sprite = GameControll.instance.pers[17];

        }
        else if (name == "Zora Ideare")
        {
            Image.sprite = GameControll.instance.pers[18];

        }
        else if (name == "Gomo gomo zek")
        {
            Image.sprite = GameControll.instance.pers[19];

        }
        else if (name == "Genrysay Yamamoto")
        {
            Image.sprite = GameControll.instance.pers[20];

        }
        else if (name == "Retsu Unohana")
        {
            Image.sprite = GameControll.instance.pers[21];

        }
        else if (name == "Syuhey Hisagi")
        {
            Image.sprite = GameControll.instance.pers[22];

        }
        else if (name == "Chad")
        {
            Image.sprite = GameControll.instance.pers[23];

        }
        else if (name == "Kenpachi Zaraki")
        {
            Image.sprite = GameControll.instance.pers[24];

        }
        else if (name == "Djushiro Ikitake")
        {
            Image.sprite = GameControll.instance.pers[25];

        }
        else if (name == "Byakuya Kuchiki")
        {
            Image.sprite = GameControll.instance.pers[26];

        }
        else if (name == "Yumichka")
        {
            Image.sprite = GameControll.instance.pers[27];

        }
        else if (name == "Sandji Komamura")
        {
            Image.sprite = GameControll.instance.pers[28];

        }
        else if (name == "Yuriu Isida")
        {
            Image.sprite = GameControll.instance.pers[29];

        }
        else if (name == "Rangiku Matsumoto")
        {
            Image.sprite = GameControll.instance.pers[30];

        }
        else if (name == "Ikkaku Maderame")
        {
            Image.sprite = GameControll.instance.pers[31];

        }
        else if (name == "Gin")
        {
            Image.sprite = GameControll.instance.pers[32];

        }
        else if (name == "Hirako")
        {
            Image.sprite = GameControll.instance.pers[33];

        }
        else if (name == "Aizen")
        {
            Image.sprite = GameControll.instance.pers[34];

        }
        else if (name == "Grimjou")
        {
            Image.sprite = GameControll.instance.pers[35];

        }
        else if (name == "Soy-Fon")
        {
            Image.sprite = GameControll.instance.pers[36];

        }
        else if (name == "Ichigo Kurasaki")
        {
            Image.sprite = GameControll.instance.pers[37];

        }
        else if (name == "Kento Nanami")
        {
            Image.sprite = GameControll.instance.pers[38];

        }
        else if (name == "Kigusaki Nabora")
        {
            Image.sprite = GameControll.instance.pers[39];

        }
        else if (name == "Zenin Maki")
        {
            Image.sprite = GameControll.instance.pers[40];

        }
        else if (name == "Yuta Okkotsu")
        {
            Image.sprite = GameControll.instance.pers[41];

        }
        else if (name == "Todji Fushigura")
        {
            Image.sprite = GameControll.instance.pers[42];

        }
        else if (name == "Djogo")
        {
            Image.sprite = GameControll.instance.pers[43];

        }
        else if (name == "Suguru Geto")
        {
            Image.sprite = GameControll.instance.pers[44];

        }
        else if (name == "Todo Ayo")
        {
            Image.sprite = GameControll.instance.pers[45];

        }
        else if (name == "Kusumi Miva")
        {
            Image.sprite = GameControll.instance.pers[46];

        }
        else if (name == "Ryomen Sukuna")
        {
            Image.sprite = GameControll.instance.pers[47];

        }
        else if (name == "Satoru Godjo")
        {
            Image.sprite = GameControll.instance.pers[48];

        }
        else if (name == "Mahito")
        {
            Image.sprite = GameControll.instance.pers[49];

        }
        else if (name == "Hanami")
        {
            Image.sprite = GameControll.instance.pers[50];

        }
        else if (name == "Itadori Yudji")
        {
            Image.sprite = GameControll.instance.pers[51];

        }
        else if (name == "Beng")
        {
            Image.sprite = GameControll.instance.pers[52];

        }
        else if (name == "Satoru")
        {
            Image.sprite = GameControll.instance.pers[53];

        }
        else if (name == "Sonik")
        {
            Image.sprite = GameControll.instance.pers[54];

        }
        else if (name == "May Mask")
        {
            Image.sprite = GameControll.instance.pers[55];

        }
        else if (name == "Garo")
        {
            Image.sprite = GameControll.instance.pers[56];

        }
        else if (name == "Prujinyashii Us")
        {
            Image.sprite = GameControll.instance.pers[57];

        }
        else if (name == "Maskitnaya Jenshina")
        {
            Image.sprite = GameControll.instance.pers[58];

        }
        else if (name == "Choso")
        {
            Image.sprite = GameControll.instance.pers[59];

        }
        else if (name == "Fushigura Megumia")
        {
            Image.sprite = GameControll.instance.pers[60];

        }
        else if (name == "Panda")
        {
            Image.sprite = GameControll.instance.pers[61];

        }
        else if (name == "Rengoku")
        {
            Image.sprite = GameControll.instance.pers[62];

        }
        else if (name == "Sanemi")
        {
            Image.sprite = GameControll.instance.pers[63];

        }
        else if (name == "Tomioka")
        {
            Image.sprite = GameControll.instance.pers[64];

        }
        else if (name == "Nezuko")
        {
            Image.sprite = GameControll.instance.pers[65];

        }
        else if (name == "Tandjiro")
        {
            Image.sprite = GameControll.instance.pers[66];

        }
        else if (name == "Susamaru")
        {
            Image.sprite = GameControll.instance.pers[67];

        }
        else if (name == "Zenitsu")
        {
            Image.sprite = GameControll.instance.pers[68];

        }
        else if (name == "Mudzan")
        {
            Image.sprite = GameControll.instance.pers[69];

        }
        else if (name == "Gyutaro")
        {
            Image.sprite = GameControll.instance.pers[70];

        }
        else if (name == "Inoske")
        {
            Image.sprite = GameControll.instance.pers[71];

        }
        else if (name == "Shinobu Kocho")
        {
            Image.sprite = GameControll.instance.pers[72];

        }
        else if (name == "Toketu")
        {
            Image.sprite = GameControll.instance.pers[73];

        }
        else if (name == "Gyumey")
        {
            Image.sprite = GameControll.instance.pers[74];

        }
        else if (name == "Kokushibo")
        {
            Image.sprite = GameControll.instance.pers[75];

        }
        else if (name == "Tengen")
        {
            Image.sprite = GameControll.instance.pers[76];

        }
        else if (name == "Kaygaku")
        {
            Image.sprite = GameControll.instance.pers[77];

        }
        else if (name == "Reve")
        {
            Image.sprite = GameControll.instance.pers[78];

        }
        else if (name == "Gordon")
        {
            Image.sprite = GameControll.instance.pers[79];

        }
        else if (name == "Kaiser")
        {
            Image.sprite = GameControll.instance.pers[80];

        }
        else if (name == "Zarget Demon")
        {
            Image.sprite = GameControll.instance.pers[81];

        }
        else if (name == "Gosh")
        {
            Image.sprite = GameControll.instance.pers[82];

        }
        else if (name == "Langris")
        {
            Image.sprite = GameControll.instance.pers[83];

        }
        else if (name == "Lack")
        {
            Image.sprite = GameControll.instance.pers[84];

        }
        else if (name == "Vanika")
        {
            Image.sprite = GameControll.instance.pers[85];

        }
        else if (name == "Doroti")
        {
            Image.sprite = GameControll.instance.pers[86];

        }
        else if (name == "Nomu")
        {
            Image.sprite = GameControll.instance.pers[87];

        }
        else if (name == "Shoto")
        {
            Image.sprite = GameControll.instance.pers[88];

        }
        else if (name == "Tokoyame")
        {
            Image.sprite = GameControll.instance.pers[89];

        }
        else if (name == "Tsuyu")
        {
            Image.sprite = GameControll.instance.pers[90];

        }
        else if (name == "Dabi")
        {
            Image.sprite = GameControll.instance.pers[91];

        }
        else if (name == "Bakugo")
        {
            Image.sprite = GameControll.instance.pers[92];

        }
        else if (name == "Uraraka")
        {
            Image.sprite = GameControll.instance.pers[93];

        }
        else if (name == "Gran Torino")
        {
            Image.sprite = GameControll.instance.pers[94];

        }
        else if (name == "All might")
        {
            Image.sprite = GameControll.instance.pers[95];

        }
        else if (name == "Izuki Midoriya")
        {
            Image.sprite = GameControll.instance.pers[121];

        }
        else if (name == "Himiko Toga")
        {
            Image.sprite = GameControll.instance.pers[96];

        }
        else if (name == "Muskular")
        {
            Image.sprite = GameControll.instance.pers[97];

        }
        else if (name == "Kirishima")
        {
            Image.sprite = GameControll.instance.pers[98];

        }
        else if (name == "Staratel")
        {
            Image.sprite = GameControll.instance.pers[99];

        }
        else if (name == "Shtein")
        {
            Image.sprite = GameControll.instance.pers[100];

        }
        else if (name == "Momo Yayorozu")
        {
            Image.sprite = GameControll.instance.pers[101];

        }
        else if (name == "Minoru Mineta")
        {
            Image.sprite = GameControll.instance.pers[102];

        }
        else if (name == "Mitsuki")
        {
            Image.sprite = GameControll.instance.pers[103];

        }
        else if (name == "Kakashi")
        {
            Image.sprite = GameControll.instance.pers[104];

        }
        else if (name == "Orochimaru")
        {
            Image.sprite = GameControll.instance.pers[105];

        }
        else if (name == "Obito")
        {
            Image.sprite = GameControll.instance.pers[106];

        }
        else if (name == "Naruto")
        {
            Image.sprite = GameControll.instance.pers[107];

        }
        else if (name == "Jiraya")
        {
            Image.sprite = GameControll.instance.pers[108];

        }
        else if (name == "Kavaki")
        {
            Image.sprite = GameControll.instance.pers[109];

        }
        else if (name == "Boruto")
        {
            Image.sprite = GameControll.instance.pers[110];

        }
        else if (name == "Mifune")
        {
            Image.sprite = GameControll.instance.pers[111];

        }
        else if (name == "Sasuke")
        {
            Image.sprite = GameControll.instance.pers[112];

        }
        else if (name == "Sarada")
        {
            Image.sprite = GameControll.instance.pers[113];

        }
        else if (name == "Madara")
        {
            Image.sprite = GameControll.instance.pers[114];

        }
        else if (name == "Kurenay")
        {
            Image.sprite = GameControll.instance.pers[115];

        }
        else if (name == "Sakura")
        {
            Image.sprite = GameControll.instance.pers[116];

        }
        else if (name == "Gaara")
        {
            Image.sprite = GameControll.instance.pers[117];

        }
        else if (name == "Hashirama")
        {
            Image.sprite = GameControll.instance.pers[118];

        }
        else if (name == "Tsunade")
        {
            Image.sprite = GameControll.instance.pers[119];

        }
        else if (name == "Itachi")
        {
            Image.sprite = GameControll.instance.pers[120];

        }
        
    }
}
