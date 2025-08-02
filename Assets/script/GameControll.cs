using GooglePlayGames.BasicApi.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    public GameObject persons;
    public List<Sprite> AvatarPerson = new List<Sprite>();
    public GameObject PersonsFather;
    public GameObject PersonsUseFather;
    public GameObject Persons;
    public GameObject PersonPrefab;
    public static GameControll instance;
    public List<string> persLoad = new List<string>();
    public List<string> ItemLoad = new List<string>();
    public List<string> MaterialLoad = new List<string>();
    public List<string> StroiLoad = new List<string>();
    public List<string> BattlePveInfoLevel = new List<string>();
    public List<Sprite> pers = new List<Sprite>();
    public GameObject personPanel;
    public List<Sprite> EvoSprite = new List<Sprite>();
    public Text debug;
    public List<Sprite> SpriteItemSnar = new List<Sprite>();
    [SerializeField] public GameObject InventoryItemFather;
    [SerializeField] private GameObject InventoryItemPrefab;
    [SerializeField] private GameObject InventoryMaterialPrefab;
    [SerializeField] public GameObject Inventory;
    [SerializeField] public GameObject ItemInfoPanel;
    [SerializeField] public List<Animation> animationsZvezda = new List<Animation>();
    public GameObject ItemShopPersonFather;
    public GameObject ItemShopPersonPrefab;
    public GameObject ItemShopPredmetPrefab;
    public GameObject ShopPanel;
    public GameObject priziv;
    public Text serebro;
    public Text almaz;
    public int gold;
    public int almazInt;
    public List<Sprite> material = new List<Sprite>();
    [Header("Ванпачман")]
    public List<String> VanpachRankA = new List<String>();
    public List<String> VanpachRankS = new List<String>();
    public List<String> VanpachRankSR = new List<String>();
    [Header("Черный клевер")]
    public List<String> BlackCleverRankA = new List<String>();
    public List<String> BlackCleverS = new List<String>();
    public List<String> BlackCleverSR = new List<String>();
    [Header("блич")]
    public List<String> BleachRankA = new List<String>();
    public List<String> BleachS = new List<String>();
    public List<String> BleachSR = new List<String>();
    [Header("клинок")]
    public List<String> KlinokRankA = new List<String>();
    public List<String> KlinokS = new List<String>();
    public List<String> KlinokSR = new List<String>();
    [Header("Академия")]
    public List<String> AcademiaRankA = new List<String>();
    public List<String> AcademiaS = new List<String>();
    public List<String> AcademiaSR = new List<String>();
    [Header("Наруто")]
    public List<String> NarutoRankA = new List<String>();
    public List<String> NarutoS = new List<String>();
    public List<String> NarutoSR = new List<String>();
    [Header("магическая битва")]
    public List<String> MagichkaRankA = new List<String>();
    public List<String> MagichkaS = new List<String>();
    public List<String> MagichkaSR = new List<String>();
    [Header("Предметы")]
    public List<String> SnarRankA = new List<String>();
    public List<String> SnarRankS = new List<String>();
    public GameObject stroiFatherList;
    public GameObject stroi;
    public GameObject kvestPanel;

    public GameObject PvePanel;

    [Header("Изображения для скилов")]
    public List<Sprite> SpriteSkill = new List<Sprite>();
    public GameObject Gildia;

    //Клан
    public GameObject KlanUser;
    //Чат
    public GameObject ChatPanel;
    //Насйтроки
    public GameObject SettingsPanel;

    //Уровень
    public GameObject Level;
    public bool levelBool = false;

    //Панель с письмом
    public GameObject MailPanel;
    public GameObject MailOpenPanel;


    //Покупка астралов
    public GameObject AstralShop;

    public RawImage Avatar;
    public Text UsernameText;

    public AudioClip DefaultClip;
    public AudioClip BattleClip;

    public AudioSource AudioSourceG;

    public GameObject LoadPanel;
    public void OpenAstralShopPanel()
    {
        ClientSend.UpdateAstralCount();
        ClientSend.SelectAstralShop();
        AstralShop.SetActive(true);
    }
    public void OpenMail()
    {
        ClientSend.MailUpdate();
        MailPanel.SetActive(true);
    }

    public void SettingsOpen()
    {
        ClientSend.SelectAvatar();
        SettingsPanel.SetActive(true);
    }
    public IEnumerator UpdateLevel()
    {
        Debug.Log("Корутина");
        LoadPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        ClientSend.UpdateLevelUser();
        ClientSend.GetUpPanel();
        yield return new WaitForSeconds(0.5f);
        LoadPanel.SetActive(false);
        yield return new WaitForSeconds(5f);

    }
    public IEnumerator CheckPayments(string InvId)
    {
        string invid = InvId;
        for (; ; )
        {
            Debug.Log("Корутина");
            ClientSend.CheckPayments(InvId);
            yield return new WaitForSeconds(1f);
        }
        
    }
    public void StartCorPayments(string InvId)
    {
        StartCoroutine(CheckPayments(InvId));
    }

    

    public void ChatCloseOpen()
    {
        ChatPanel.SetActive(true);
        StopCoroutine(ChatPanel.GetComponent<chat>().UpdateChat());
        StartCoroutine(ChatPanel.GetComponent<chat>().UpdateChat());
    }
    public void Gildiavoid()
    {
        ClientSend.SearchKlanUser();        
    }
    public void PvePannelClick()
    {
        if (PvePanel.activeSelf == false)
        {
            while (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().PerentUserAttck.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().PerentUserAttck.transform.GetChild(0).gameObject);
            }
            ClientSend.SearchPveCount("!");
            ClientSend.SearchPveUserAtack();
            PvePanel.SetActive(true);
            persons.SetActive(false);
            ItemInfoPanel.SetActive(false);
            ShopPanel.SetActive(false);
            kvestPanel.SetActive(false);
            priziv.SetActive(false);
            Inventory.SetActive(false);
            Gildia.SetActive(false);




        }
        else
        {
            PvePanel.SetActive(false);
        }
    }

    public void kvestPanelOn()
    {
        if (kvestPanel.activeSelf && !kvestPanel.GetComponent<cvestControlScript>().BattleStart)
        {
            kvestPanel.SetActive(false);

        }
        else
        {
            kvestPanel.SetActive(true);
            persons.SetActive(false);
            ItemInfoPanel.SetActive(false);
            ShopPanel.SetActive(false);
            PvePanel.SetActive(false);
            priziv.SetActive(false);
            Inventory.SetActive(false);
            Gildia.SetActive(false);

        }
    }
    public void PrizavOpen()
    {
        ClientSend.InventoryMaterialSearchUser();

        
        priziv.SetActive(true);
        persons.SetActive(false);
        ItemInfoPanel.SetActive(false);
        ShopPanel.SetActive(false);
        kvestPanel.SetActive(false);
        PvePanel.SetActive(false);
        Inventory.SetActive(false);
        Gildia.SetActive(false);

    }

    public void ShopOpenClose()
    {
        if (ShopPanel.activeSelf == false)
        {
            while (ItemShopPersonFather.transform.childCount > 0)
            {
                DestroyImmediate(ItemShopPersonFather.transform.GetChild(0).gameObject);
            }
            ClientSend.SearchShopPerson();
            ClientSend.SearchKlanMoney();
            ShopPanel.SetActive(true);
            persons.SetActive(false);
            ItemInfoPanel.SetActive(false);
            PvePanel.SetActive(false);
            kvestPanel.SetActive(false);
            priziv.SetActive(false);
            Inventory.SetActive(false);
            Gildia.SetActive(false);
            ShopPanel.GetComponent<Shop>().Person.sprite = ShopPanel.GetComponent<Shop>().On;
            ShopPanel.GetComponent<Shop>().Snarazhenie.sprite = ShopPanel.GetComponent<Shop>().Off;
        }
        else
        {
            ShopPanel.SetActive(false);
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroy object");
            Destroy(this);

        }
        AudioSourceG = gameObject.GetComponent<AudioSource>();
        AudioSourceG.clip = DefaultClip;
        AudioSourceG.Play();

    }
    private void Start()
    {
        //PlayerPrefs.DeleteKey("GameServerIp");
        //PlayerPrefs.DeleteKey("mail");
        //ClientSend.GetUpPanel();
        PlayerPrefs.SetFloat("gold", 100000000);
        PlayerPrefs.SetFloat("almaz", 100000000);
    }
    public void InventoryBtn()
    {
        if (Inventory.activeSelf == true)
        {
            Inventory.SetActive(false);


        }
        else
        {
            while (InventoryItemFather.transform.childCount > 0)
            {
                DestroyImmediate(InventoryItemFather.transform.GetChild(0).gameObject);
            }
            ClientSend.InventorySearchUser();
            Inventory.SetActive(true);
            persons.SetActive(false);
            ItemInfoPanel.SetActive(false);
            PvePanel.SetActive(false);
            kvestPanel.SetActive(false);
            priziv.SetActive(false);
            ShopPanel.SetActive(false);
            Gildia.SetActive(false);
        }
        
    }

    public void Glavnai()
    {
        Inventory.SetActive(false);
        persons.SetActive(false);
        ItemInfoPanel.SetActive(false);
        PvePanel.SetActive(false);
        kvestPanel.SetActive(false);
        priziv.SetActive(false);
        ShopPanel.SetActive(false);
        Gildia.SetActive(false);
    }
    private void Update()
    {
        serebro.text = $"{(BigInteger)gold}";
        almaz.text = $"{(BigInteger)almazInt}";
        foreach (Animation anim in animationsZvezda)
        {
            anim.Play();
        }
        try
        {
            if (!levelBool)
            {
                StartCoroutine(UpdateLevel());
                //ClientSend.GetUpPanel();
                levelBool = true;
            }
        }
        catch
        {

        }
    }
    public static void AddNagradaBossWin(string type, int Count,string name)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().WinNagrandaPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().WinNagrandaFather.transform, false);
        ButtonSearch.GetComponent<NagradaWinBossKvest>().type = type;
        ButtonSearch.GetComponent<NagradaWinBossKvest>().Count = Count;
        ButtonSearch.GetComponent<NagradaWinBossKvest>().Name = name;



    }

    public static void SelectAstralShopItem(int id, int Count, int Price)
    {
        
        GameObject ButtonSearch = Instantiate(GameControll.instance.AstralShop.GetComponent<ShopAstral>().PrefabShop);
        ButtonSearch.transform.SetParent(GameControll.instance.AstralShop.GetComponent<ShopAstral>().FatherShop.transform, false);
        ButtonSearch.GetComponent<AstralShopItem>().id = id;
        ButtonSearch.GetComponent<AstralShopItem>().Count = Count;
        ButtonSearch.GetComponent<AstralShopItem>().Price = Price;




    }

    public static void AddChatMsg(string time, string msg,string avatar, int ID)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.ChatPanel.GetComponent<chat>().PrefabMsgChat);
        ButtonSearch.transform.SetParent(GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform, false);
        ButtonSearch.GetComponent<msgChat>().datetime = time;
        ButtonSearch.GetComponent<msgChat>().msg = msg;
        ButtonSearch.GetComponent<msgChat>().UserId = ID;
        string avStr = avatar;
        byte[] ava = Convert.FromBase64String(avStr);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(ava);
        if (!string.IsNullOrEmpty(avStr))
        {
            ButtonSearch.GetComponent<msgChat>().Avatar.gameObject.SetActive(true);
            ButtonSearch.GetComponent<msgChat>().Avatar.texture = texture;

        }
        else
        {
            ButtonSearch.GetComponent<msgChat>().Avatar.gameObject.SetActive(false);


        }
        GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.childCount * 200);


    }

    public static void AddNagradaKvestKlan(string type, int Count, string name)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().WinBoos.GetComponent<WInRewerdKvestKlan>().WinPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().WinBoos.GetComponent<WInRewerdKvestKlan>().WinFather.transform, false);
        ButtonSearch.GetComponent<NagradaWinBossKvest>().type = type;
        ButtonSearch.GetComponent<NagradaWinBossKvest>().Count = Count;
        ButtonSearch.GetComponent<NagradaWinBossKvest>().Name = name;



    }

    public static void AddListUserKlan(string ID, bool ownerBool,string mail, string Avatar)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.KlanUser.GetComponent<KlanUser>().PrefabListUser);
        ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform, false);
        ButtonSearch.GetComponent<SpisokUserKlan>().ID = Convert.ToInt32(ID);
        ButtonSearch.GetComponent<SpisokUserKlan>().mail = mail;

        if (!string.IsNullOrEmpty(Avatar))
        {
            byte[] ava = Convert.FromBase64String(Avatar);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(ava);
            ButtonSearch.GetComponent<SpisokUserKlan>().Avatar.gameObject.SetActive(true);
            ButtonSearch.GetComponent<SpisokUserKlan>().Avatar.texture = texture;
        }
        else
        {
            ButtonSearch.GetComponent<SpisokUserKlan>().Avatar.gameObject.SetActive(false);
        }

        if (ownerBool == true)
        {
            ButtonSearch.GetComponent<SpisokUserKlan>().buttonKick.SetActive(true);

        }
        else
        {
            ButtonSearch.GetComponent<SpisokUserKlan>().buttonKick.SetActive(false);

        }
        GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform.childCount * 236);



    }
    public static void AddShopItemPredmet(string Name, string Valet, int Price, int id, int idItem, int MaxByu, int Byu,string description)
    {
        Debug.Log(id);
        GameObject ButtonSearch = Instantiate(GameControll.instance.ItemShopPredmetPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.ItemShopPersonFather.transform, false);
        ButtonSearch.GetComponent<ShopItemPredmet>().Name = Name;
        ButtonSearch.GetComponent<ShopItemPredmet>().Valet = Valet;
        ButtonSearch.GetComponent<ShopItemPredmet>().Price = Price;
        ButtonSearch.GetComponent<ShopItemPredmet>().type = "Predmet";
        ButtonSearch.GetComponent<ShopItemPredmet>().id = id;
        ButtonSearch.GetComponent<ShopItemPredmet>().idItem = idItem;
        ButtonSearch.GetComponent<ShopItemPredmet>().MaxByu = MaxByu;
        ButtonSearch.GetComponent<ShopItemPredmet>().Byu = Byu;
        ButtonSearch.GetComponent<ShopItemPredmet>().description = description;


    }
    public static void SearchPersonItemBattle(int _idSlot, int Hp, int Attack, int Defens, int Speed, int HpProc,int AttackProc,int DefensProc,int SpeedProc)
    {
        if (GameControll.instance.PvePanel.activeSelf == true)
        {
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().HpItem.Add(Hp);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().AttackItem.Add(Attack);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().DefensItem.Add(Defens);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().SpeedItem.Add(Speed);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_procItem.Add(HpProc);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Attack_procItem.Add(AttackProc);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Defens_procItem.Add(DefensProc);
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Speed_procItem.Add(SpeedProc);
        }
        else
        {
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().HpItem.Add(Hp);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().AttackItem.Add(Attack);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().DefensItem.Add(Defens);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().SpeedItem.Add(Speed);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_procItem.Add(HpProc);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Attack_procItem.Add(AttackProc);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Defens_procItem.Add(DefensProc);
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[_idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Speed_procItem.Add(SpeedProc);
        }
        
        

    }
    public static void SearchPvpReiting(string Name, int GlassesPve, int bs, int ID, int mesto,string Avatar)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserAttckPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ReitingPerent.transform, false);
        ButtonSearch.GetComponent<UserPvePrefScript>().Name = Name;
        ButtonSearch.GetComponent<UserPvePrefScript>().GlassesPve = GlassesPve;
        ButtonSearch.GetComponent<UserPvePrefScript>().bs = bs;
        ButtonSearch.GetComponent<UserPvePrefScript>().ID = ID;
        ButtonSearch.GetComponent<UserPvePrefScript>().mesto = mesto;
        if (!string.IsNullOrEmpty(Avatar))
        {
            byte[] ava = Convert.FromBase64String(Avatar);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(ava);
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.gameObject.SetActive(true);
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.texture = texture;
        }
        else
        {
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.gameObject.SetActive(false);
        }

    }
    public static void SearchSpisokGildia(string Name, string GlavaKlan, int LevelGildiaPerson, int LevelGildia, int SilaGildia, int CountPerson)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.Gildia.GetComponent<GildiaPanel>().PrefabSpisokGildia);
        ButtonSearch.transform.SetParent(GameControll.instance.Gildia.GetComponent<GildiaPanel>().FatherSpisokGildia.transform, false);
        ButtonSearch.GetComponent<ObjectGilgia>().NameKlan = Name;
        ButtonSearch.GetComponent<ObjectGilgia>().GlavaKlan = GlavaKlan;
        ButtonSearch.GetComponent<ObjectGilgia>().LevelGildiaPerson = LevelGildiaPerson;
        ButtonSearch.GetComponent<ObjectGilgia>().LevelGildia = LevelGildia;
        ButtonSearch.GetComponent<ObjectGilgia>().SilaGildia = SilaGildia;
        ButtonSearch.GetComponent<ObjectGilgia>().AllPeople = CountPerson;

    }
    public static void SearchUserAttackPve(string Name,int GlassesPve,int bs,int ID,int mesto,string Avatar)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserAttckPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().PerentUserAttck.transform, false);
        ButtonSearch.GetComponent<UserPvePrefScript>().Name = Name;
        ButtonSearch.GetComponent<UserPvePrefScript>().GlassesPve = GlassesPve;
        ButtonSearch.GetComponent<UserPvePrefScript>().bs = bs;
        ButtonSearch.GetComponent<UserPvePrefScript>().ID = ID;
        ButtonSearch.GetComponent<UserPvePrefScript>().mesto = mesto;
        if (!string.IsNullOrEmpty(Avatar))
        {
            byte[] ava = Convert.FromBase64String(Avatar);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(ava);
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.gameObject.SetActive(true);
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.texture = texture;
        }
        else
        {
            ButtonSearch.GetComponent<UserPvePrefScript>().Avatar.gameObject.SetActive(false);
        }

    }
    public static void AddShopItemPerson(string Name, string Rank, string Class, string Valet, int Price, int Hp, int Defens, int Attack, int Speed,int id, int idItem,int MaxByu, int Byu)
    {
        Debug.Log(id);
        GameObject ButtonSearch = Instantiate(GameControll.instance.ItemShopPersonPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.ItemShopPersonFather.transform, false);
        ButtonSearch.GetComponent<ItemShop>().Name = Name;
        ButtonSearch.GetComponent<ItemShop>().rank = Rank;
        ButtonSearch.GetComponent<ItemShop>().Class = Class;
        ButtonSearch.GetComponent<ItemShop>().Valet = Valet;
        ButtonSearch.GetComponent<ItemShop>().Price = Price;
        ButtonSearch.GetComponent<ItemShop>().Hp = Hp;
        ButtonSearch.GetComponent<ItemShop>().Defens = Defens;
        ButtonSearch.GetComponent<ItemShop>().Attack = Attack;
        ButtonSearch.GetComponent<ItemShop>().Speed = Speed;
        ButtonSearch.GetComponent<ItemShop>().type = "Person";
        ButtonSearch.GetComponent<ItemShop>().id = id;
        ButtonSearch.GetComponent<ItemShop>().idItem = idItem;
        ButtonSearch.GetComponent<ItemShop>().MaxByu = MaxByu;
        ButtonSearch.GetComponent<ItemShop>().Byu = Byu;
        

    }
    public static void AddShopItemSnar(string Name,string name_ru, string Rank, string Valet, int Price, int Hp, int Defens, int Attack, int Speed, int id, int idItem, int MaxByu, int Byu)
    {
        Debug.Log(id);
        GameObject ButtonSearch = Instantiate(GameControll.instance.ItemShopPersonPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.ItemShopPersonFather.transform, false);
        ButtonSearch.GetComponent<ItemShop>().Name = Name;
        ButtonSearch.GetComponent<ItemShop>().name_ru = name_ru;
        ButtonSearch.GetComponent<ItemShop>().rank = Rank;
        ButtonSearch.GetComponent<ItemShop>().Valet = Valet;
        ButtonSearch.GetComponent<ItemShop>().Price = Price;
        ButtonSearch.GetComponent<ItemShop>().Hp = Hp;
        ButtonSearch.GetComponent<ItemShop>().Defens = Defens;
        ButtonSearch.GetComponent<ItemShop>().Attack = Attack;
        ButtonSearch.GetComponent<ItemShop>().Speed = Speed;
        ButtonSearch.GetComponent<ItemShop>().type = "Snar";
        ButtonSearch.GetComponent<ItemShop>().id = id;
        ButtonSearch.GetComponent<ItemShop>().idItem = idItem;
        ButtonSearch.GetComponent<ItemShop>().MaxByu = MaxByu;
        ButtonSearch.GetComponent<ItemShop>().Byu = Byu;

    }
    public static void AddInventoryItem(int b, string _name, string _type, int attack, int defens, int speed, int hp, int _attack_Proc, int _hp_proc, int CritDamage, int DamageBonus,int _id,string _nameRu,string _description,int _defens_proc, int _speed_proc)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.InventoryItemPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.InventoryItemFather.transform, false);
        
        ButtonSearch.GetComponent<ItemSlotScript>().NameItem = _name;
        ButtonSearch.GetComponent<ItemSlotScript>().RangItem = _type;
        ButtonSearch.GetComponent<ItemSlotScript>().attack = attack;
        ButtonSearch.GetComponent<ItemSlotScript>().defens = defens;
        ButtonSearch.GetComponent<ItemSlotScript>().speed = speed;
        ButtonSearch.GetComponent<ItemSlotScript>().hp = hp;
        ButtonSearch.GetComponent<ItemSlotScript>()._attack_Proc = _attack_Proc;
        ButtonSearch.GetComponent<ItemSlotScript>()._hp_proc = _hp_proc;
        ButtonSearch.GetComponent<ItemSlotScript>().CritDamage = CritDamage;
        ButtonSearch.GetComponent<ItemSlotScript>().DamageBonus = DamageBonus;
        ButtonSearch.GetComponent<ItemSlotScript>().id = _id;
        ButtonSearch.GetComponent<ItemSlotScript>().Nameru = _nameRu;
        ButtonSearch.GetComponent<ItemSlotScript>().description = _description;
        ButtonSearch.GetComponent<ItemSlotScript>().speed_proc = _speed_proc;
        ButtonSearch.GetComponent<ItemSlotScript>().defens_proc = _defens_proc;


    }

    public static void AddInventoryMaterial(string _name,int _id,int _count)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.InventoryMaterialPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.InventoryItemFather.transform, false);

        ButtonSearch.GetComponent<materailScripts>().Name = _name;
        ButtonSearch.GetComponent<materailScripts>().id = _id;
        ButtonSearch.GetComponent<materailScripts>().Count = _count;
        

    }
    public static void AddPersonSearch(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction,int CritDamage,int CritChance,int Evasion,int Accuracy,int DamageBonus,int AntiCrit, int Control,int AntiControl,int Treatment, int Recovery)
    {
        Debug.Log($"id: {_id}");
        GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.PersonsFather.transform, false);
        ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
        ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
        ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
        ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
        ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
        ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
        ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
        ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
        ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
        ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
        ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
        ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
        ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
        ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
        ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
        ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
        ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
        ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
        ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
        ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
        ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

        if (_namePers == "King")
        {

            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];
            
        }
        else if (_namePers == "The villain with the whip")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];
            
        }
        else if (_namePers == "Genos")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];
            
        }
        else if (_namePers == "Tatsumaki Tornado")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

        }
        else if (_namePers == "Isamu the Cruel Emperor")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

        }
        else if (_namePers == "Suiryu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

        }
        else if (_namePers == "Bad Steel Bat")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

        }
        else if (_namePers == "The master in a Tshirt")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

        }
        else if (_namePers == "Kamikaze Atomic Samurai")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

        }
        else if (_namePers == "Asta")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

        }
        else if (_namePers == "Noel Silver")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

        }
        else if (_namePers == "Yami Sukehiro")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

        }
        else if (_namePers == "Yuno")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

        }
        else if (_namePers == "William Wanjins")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

        }
        else if (_namePers == "Mereoleon The Crimson Lion")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

        }
        else if (_namePers == "Fana")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

        }
        else if (_namePers == "Finral Rollcase")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

        }
        
        else if (_namePers == "Julius Novochrono")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];
            
        }
        else if (_namePers == "Zora Ideare")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

        }
        else if (_namePers == "Gomo gomo zek")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

        }
        else if (_namePers == "Genrysay Yamamoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

        }
        else if (_namePers == "Retsu Unohana")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

        }
        else if (_namePers == "Syuhey Hisagi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

        }
        else if (_namePers == "Chad")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

        }
        else if (_namePers == "Kenpachi Zaraki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

        }
        else if (_namePers == "Djushiro Ikitake")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

        }
        else if (_namePers == "Byakuya Kuchiki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

        }
        else if (_namePers == "Yumichka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

        }
        else if (_namePers == "Sandji Komamura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

        }
        else if (_namePers == "Yuriu Isida")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

        }
        else if (_namePers == "Rangiku Matsumoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

        }
        else if (_namePers == "Ikkaku Maderame")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

        }
        else if (_namePers == "Gin")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

        }
        else if (_namePers == "Hirako")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

        }
        else if (_namePers == "Aizen")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

        }
        else if (_namePers == "Grimjou")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

        }
        else if (_namePers == "Soy-Fon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

        }
        else if (_namePers == "Kurasaki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

        }
        else if (_namePers == "Kento Nanami")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

        }
        else if (_namePers == "Kigusaki Nabora")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

        }
        else if (_namePers == "Zenin Maki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

        }
        else if (_namePers == "Yuta Okkotsu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

        }
        else if (_namePers == "Todji Fushigura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

        }
        else if (_namePers == "Djogo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

        }
        else if (_namePers == "Suguru Geto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

        }
        else if (_namePers == "Todo Ayo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

        }
        else if (_namePers == "Kusumi Miva")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

        }
        else if (_namePers == "Ryomen Sukuna")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

        }
        else if (_namePers == "Satoru Godjo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

        }
        else if (_namePers == "Mahito")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

        }
        else if (_namePers == "Hanami")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

        }
        else if (_namePers == "Itadori Yudji")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

        }
        else if (_namePers == "Beng")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

        }
        else if (_namePers == "Satoru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

        }
        else if (_namePers == "Sonik")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

        }
        else if (_namePers == "May Mask")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

        }
        else if (_namePers == "Garo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

        }
        else if (_namePers == "Prujinyashii Us")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

        }
        else if (_namePers == "Maskitnaya Jenshina")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

        }
        else if (_namePers == "Choso")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

        }
        else if (_namePers == "Fushigura Megumia")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

        }
        else if (_namePers == "Panda")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

        }
        else if (_namePers == "Rengoku")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

        }
        else if (_namePers == "Sanemi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

        }
        else if (_namePers == "Tomioka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

        }
        else if (_namePers == "Nezuko")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

        }
        else if (_namePers == "Tandjiro")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

        }
        else if (_namePers == "Susamaru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

        }
        else if (_namePers == "Zenitsu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

        }
        else if (_namePers == "Mudzan")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

        }
        else if (_namePers == "Gyutago")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

        }
        else if (_namePers == "Inoske")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

        }
        else if (_namePers == "Shinobu Kocho")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

        }
        else if (_namePers == "Toketu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

        }
        else if (_namePers == "Gyumey")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

        }
        else if (_namePers == "Kokushibo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

        }
        else if (_namePers == "Tengen")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

        }
        else if (_namePers == "Kaygaku")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

        }
        else if (_namePers == "Reve")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

        }
        else if (_namePers == "Gordon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

        }
        else if (_namePers == "Kaiser")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

        }
        else if (_namePers == "Zarget Demon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

        }
        else if (_namePers == "Gosh")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

        }
        else if (_namePers == "Langris")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

        }
        else if (_namePers == "Lack")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

        }
        else if (_namePers == "Vanika")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

        }
        else if (_namePers == "Doroti")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

        }
        else if (_namePers == "Nomu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

        }
        else if (_namePers == "Shoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

        }
        else if (_namePers == "Tokoyame")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

        }
        else if (_namePers == "Tsuyu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

        }
        else if (_namePers == "Dabi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

        }
        else if (_namePers == "Bakugo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

        }
        else if (_namePers == "Uraraka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

        }
        else if (_namePers == "Gran Torino")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

        }
        else if (_namePers == "All might")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

        }
        else if (_namePers == "Izuki Midoriya")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

        }
        else if (_namePers == "Himiko Toga")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

        }
        else if (_namePers == "Muskular")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

        }
        else if (_namePers == "Kirishima")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

        }
        else if (_namePers == "Staratel")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

        }
        else if (_namePers == "Shtein")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

        }
        else if (_namePers == "Momo Yayorozu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

        }
        else if (_namePers == "Minoru Mineta")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

        }
        else if (_namePers == "Mitsuki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

        }
        else if (_namePers == "Kakashi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

        }
        else if (_namePers == "Orochimaru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

        }
        else if (_namePers == "Obito")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

        }
        else if (_namePers == "Naruto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

        }
        else if (_namePers == "Jiraya")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

        }
        else if (_namePers == "Kavaki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

        }
        else if (_namePers == "Boruto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

        }
        else if (_namePers == "Mifune")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

        }
        else if (_namePers == "Sasuke")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

        }
        else if (_namePers == "Sarada")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

        }
        else if (_namePers == "Madara")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

        }
        else if (_namePers == "Kurenay")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

        }
        else if (_namePers == "Sakura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

        }
        else if (_namePers == "Gaara")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

        }
        else if (_namePers == "Hashirama")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

        }
        else if (_namePers == "Tsunade")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

        }
        else if (_namePers == "Itachi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

        }
        
        //Debug.Log(ButtonSearch.gameObject.transform.Find("NameServer"));
        //Debug.Log(ButtonSearch.transform.localPosition);

    }
    public static void AddPersonSearchsSroi(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
        ButtonSearch.transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
        ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
        ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
        ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
        ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
        ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
        ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
        ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
        ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
        ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
        ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
        ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
        ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
        ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
        ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
        ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
        ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
        ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
        ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
        ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
        ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
        ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

        if (_namePers == "King")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

        }
        else if (_namePers == "The villain with the whip")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

        }
        else if (_namePers == "Genos")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

        }
        else if (_namePers == "Tatsumaki Tornado")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

        }
        else if (_namePers == "Isamu the Cruel Emperor")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

        }
        else if (_namePers == "Suiryu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

        }
        else if (_namePers == "Bad Steel Bat")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

        }
        else if (_namePers == "The master in a Tshirt")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

        }
        else if (_namePers == "Kamikaze Atomic Samurai")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

        }
        else if (_namePers == "Asta")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

        }
        else if (_namePers == "Noel Silver")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

        }
        else if (_namePers == "Yami Sukehiro")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

        }
        else if (_namePers == "Yuno")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

        }
        else if (_namePers == "William Wanjins")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

        }
        else if (_namePers == "Mereoleon The Crimson Lion")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

        }
        else if (_namePers == "Fana")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

        }
        else if (_namePers == "Finral Rollcase")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

        }

        else if (_namePers == "Julius Novochrono")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

        }
        else if (_namePers == "Zora Ideare")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

        }
        else if (_namePers == "Gomo gomo zek")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

        }
        else if (_namePers == "Genrysay Yamamoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

        }
        else if (_namePers == "Retsu Unohana")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

        }
        else if (_namePers == "Syuhey Hisagi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

        }
        else if (_namePers == "Chad")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

        }
        else if (_namePers == "Kenpachi Zaraki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

        }
        else if (_namePers == "Djushiro Ikitake")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

        }
        else if (_namePers == "Byakuya Kuchiki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

        }
        else if (_namePers == "Yumichka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

        }
        else if (_namePers == "Sandji Komamura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

        }
        else if (_namePers == "Yuriu Isida")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

        }
        else if (_namePers == "Rangiku Matsumoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

        }
        else if (_namePers == "Ikkaku Maderame")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

        }
        else if (_namePers == "Gin")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

        }
        else if (_namePers == "Hirako")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

        }
        else if (_namePers == "Aizen")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

        }
        else if (_namePers == "Grimjou")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

        }
        else if (_namePers == "Soy-Fon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

        }
        else if (_namePers == "Kurasaki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

        }
        else if (_namePers == "Kento Nanami")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

        }
        else if (_namePers == "Kigusaki Nabora")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

        }
        else if (_namePers == "Zenin Maki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

        }
        else if (_namePers == "Yuta Okkotsu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

        }
        else if (_namePers == "Todji Fushigura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

        }
        else if (_namePers == "Djogo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

        }
        else if (_namePers == "Suguru Geto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

        }
        else if (_namePers == "Todo Ayo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

        }
        else if (_namePers == "Kusumi Miva")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

        }
        else if (_namePers == "Ryomen Sukuna")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

        }
        else if (_namePers == "Satoru Godjo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

        }
        else if (_namePers == "Mahito")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

        }
        else if (_namePers == "Hanami")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

        }
        else if (_namePers == "Itadori Yudji")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

        }
        else if (_namePers == "Beng")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

        }
        else if (_namePers == "Satoru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

        }
        else if (_namePers == "Sonik")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

        }
        else if (_namePers == "May Mask")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

        }
        else if (_namePers == "Garo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

        }
        else if (_namePers == "Prujinyashii Us")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

        }
        else if (_namePers == "Maskitnaya Jenshina")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

        }
        else if (_namePers == "Choso")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

        }
        else if (_namePers == "Fushigura Megumia")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

        }
        else if (_namePers == "Panda")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

        }
        else if (_namePers == "Rengoku")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

        }
        else if (_namePers == "Sanemi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

        }
        else if (_namePers == "Tomioka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

        }
        else if (_namePers == "Nezuko")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

        }
        else if (_namePers == "Tandjiro")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

        }
        else if (_namePers == "Susamaru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

        }
        else if (_namePers == "Zenitsu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

        }
        else if (_namePers == "Mudzan")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

        }
        else if (_namePers == "Gyutago")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

        }
        else if (_namePers == "Inoske")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

        }
        else if (_namePers == "Shinobu Kocho")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

        }
        else if (_namePers == "Toketu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

        }
        else if (_namePers == "Gyumey")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

        }
        else if (_namePers == "Kokushibo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

        }
        else if (_namePers == "Tengen")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

        }
        else if (_namePers == "Kaygaku")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

        }
        else if (_namePers == "Reve")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

        }
        else if (_namePers == "Gordon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

        }
        else if (_namePers == "Kaiser")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

        }
        else if (_namePers == "Zarget Demon")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

        }
        else if (_namePers == "Gosh")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

        }
        else if (_namePers == "Langris")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

        }
        else if (_namePers == "Lack")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

        }
        else if (_namePers == "Vanika")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

        }
        else if (_namePers == "Doroti")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

        }
        else if (_namePers == "Nomu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

        }
        else if (_namePers == "Shoto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

        }
        else if (_namePers == "Tokoyame")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

        }
        else if (_namePers == "Tsuyu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

        }
        else if (_namePers == "Dabi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

        }
        else if (_namePers == "Bakugo")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

        }
        else if (_namePers == "Uraraka")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

        }
        else if (_namePers == "Gran Torino")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

        }
        else if (_namePers == "All might")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

        }
        else if (_namePers == "Izuki Midoriya")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

        }
        else if (_namePers == "Himiko Toga")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

        }
        else if (_namePers == "Muskular")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

        }
        else if (_namePers == "Kirishima")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

        }
        else if (_namePers == "Staratel")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

        }
        else if (_namePers == "Shtein")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

        }
        else if (_namePers == "Momo Yayorozu")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

        }
        else if (_namePers == "Minoru Mineta")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

        }
        else if (_namePers == "Mitsuki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

        }
        else if (_namePers == "Kakashi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

        }
        else if (_namePers == "Orochimaru")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

        }
        else if (_namePers == "Obito")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

        }
        else if (_namePers == "Naruto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

        }
        else if (_namePers == "Jiraya")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

        }
        else if (_namePers == "Kavaki")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

        }
        else if (_namePers == "Boruto")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

        }
        else if (_namePers == "Mifune")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

        }
        else if (_namePers == "Sasuke")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

        }
        else if (_namePers == "Sarada")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

        }
        else if (_namePers == "Madara")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

        }
        else if (_namePers == "Kurenay")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

        }
        else if (_namePers == "Sakura")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

        }
        else if (_namePers == "Gaara")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

        }
        else if (_namePers == "Hashirama")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

        }
        else if (_namePers == "Tsunade")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

        }
        else if (_namePers == "Itachi")
        {
            ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

        }
        //Debug.Log(ButtonSearch.gameObject.transform.Find("NameServer"));
        //Debug.Log(ButtonSearch.transform.localPosition);

    }
    public class PersonSearchSpeed
    {
        public int idSlot;
        public float speed;
        public string typePerson;
        public float attack;
        public float hp;
        public float bs;





        public PersonSearchSpeed(int idSlot, float speed,string typePerson, float attack,float hp,float bs)
        {
            this.idSlot = idSlot;
            this.speed = speed;
            this.typePerson = typePerson;
            this.attack = attack;
            this.hp = hp;
            this.bs = bs;
        }
    }
    public static void AddPersonBattle(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery, int idSlot, string skill1,string skill2,string skill3, string skill4Pasiv, string skill5Pasiv)
    {
        if (GameControll.instance.PvePanel.activeSelf == true)
        {
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonidListSlot.Add(idSlot - 1);
            //GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot - 1, _speed));
            GameObject ButtonSearch = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonPrefab);
            if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[0].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[0].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[0].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[1].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[1].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[1].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[2].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[2].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[2].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[3].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[3].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[3].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[4].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[4].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[4].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[5].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[5].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[5].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[6].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[6].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[6].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[7].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[7].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[7].transform.position;
            }
            else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[8].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[8].transform, false);
                ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[8].transform.position;
            }
            ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
            ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
            ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = idSlot - 1;
            ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
            ButtonSearch.GetComponent<PersonBattleScript>().level = _level;
            ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
            ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
            ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
            ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
            ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
            ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
            ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
            ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
            ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
            ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
            ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
            ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
            ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "UserPerson";
            ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
            ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
            ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
            ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
            ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;
        }
        else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonidListSlot.Add(idSlot - 1);
            //GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot - 1, _speed));
            GameObject ButtonSearch = Instantiate(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonPrefab);
            if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[0].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[0].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[0].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[1].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[1].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[1].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[2].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[2].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[2].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[3].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[3].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[3].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[4].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[4].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[4].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[5].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[5].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[5].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[6].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[6].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[6].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[7].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[7].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[7].transform.position;
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[8].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[8].transform, false);
                ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[8].transform.position;
            }
            ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
            ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
            ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = idSlot - 1;
            ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
            ButtonSearch.GetComponent<PersonBattleScript>().level = _level;
            ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
            ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
            ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
            ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
            ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
            ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
            ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
            ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
            ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
            ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
            ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
            ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
            ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "UserPerson";
            ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
            ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
            ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
            ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
            ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;
        }
        else
        {
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonidListSlot.Add(idSlot - 1);
            //GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot - 1, _speed));
            GameObject ButtonSearch = Instantiate(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonPrefab);
            if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[0].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[0].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[0].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[1].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[1].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[1].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[2].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[2].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[2].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[3].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[3].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[3].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[4].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[4].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[4].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[5].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[5].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[5].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[6].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[6].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[6].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[7].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[7].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[7].transform.position;
            }
            else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[8].GetComponent<UserPointSpavnScript>().id == idSlot)
            {
                ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[8].transform, false);
                ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[8].transform.position;
            }
            ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
            ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
            ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = idSlot - 1;
            ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
            ButtonSearch.GetComponent<PersonBattleScript>().level = _level;
            ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
            ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
            ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
            ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
            ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
            ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
            ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
            ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
            ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
            ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
            ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
            ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
            ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "UserPerson";
            ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
            ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
            ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
            ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
            ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;
        }
        

    }

    public static void AddPersonBossKLan(int b, string _namePers, string _id, string _rank, string _levelEvo,string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery, string skill1, string skill2, string skill3, string skill4Pasiv, string skill5Pasiv)
    {
        if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {
            Debug.Log(_id);
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().EnemyPersonidListSlot.Add(0);
            //GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot - 1, _speed));
            GameObject ButtonSearch = Instantiate(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonPrefab);
            ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().EnemyPersonSpavn[0].transform, false);
            ButtonSearch.transform.position = GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().EnemyPersonSpavn[0].transform.position;
            ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
            ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
            ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 0;
            ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
            ButtonSearch.GetComponent<PersonBattleScript>().level = 1;
            ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
            ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
            ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
            ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
            ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
            ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
            ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
            ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
            ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
            ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
            ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
            ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
            ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
            ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
            ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "Enemy";
            ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
            ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
            ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
            ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
            ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;
        }


    }

    public static void AddMail(string NameMail,string DescriptionMail,string date,string time)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.MailPanel.GetComponent<Mail>().PrefabMail);
        ButtonSearch.transform.SetParent(GameControll.instance.MailPanel.GetComponent<Mail>().FatherMail.transform, false);
        ButtonSearch.GetComponent<LetterScript>().NameMail = NameMail;
        ButtonSearch.GetComponent<LetterScript>().descripton = DescriptionMail;
        ButtonSearch.GetComponent<LetterScript>().Date = date;
        ButtonSearch.GetComponent<LetterScript>().Time = time;
        


    }

    public static void AddPersonEnemyUserBattle(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery, int idSlot, string skill1, string skill2, string skill3, string skill4Pasiv, string skill5Pasiv)
    {
        GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonidListSlot.Add(idSlot - 1);
        //GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot - 1, _speed));
        GameObject ButtonSearch = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonPrefab);
        if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[0].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[0].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[0].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[1].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[1].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[1].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[2].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[2].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[2].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[3].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[3].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[3].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[4].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[4].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[4].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[5].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[5].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[5].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[6].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[6].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[6].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[7].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[7].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[7].transform.position;
        }
        else if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[8].GetComponent<UserPointSpavnScript>().id == idSlot)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[8].transform, false);
            ButtonSearch.transform.position = GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[8].transform.position;
        }
        ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
        ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
        ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
        ButtonSearch.GetComponent<PersonBattleScript>().idSlot = idSlot - 1;
        ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
        ButtonSearch.GetComponent<PersonBattleScript>().level = _level;
        ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
        ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
        ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
        ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
        ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
        ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
        ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
        ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
        ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
        ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
        ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
        ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
        ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
        ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
        ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
        ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
        ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "Enemy";
        ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
        ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
        ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
        ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
        ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;


    }
    public static void AddPersonEmenyBattle(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery, string skill1, string skill2, string skill3, string skill4Pasiv, string skill5Pasiv)
    {
        GameObject ButtonSearch = Instantiate(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonPrefab);
        if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[0].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[0].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[0].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(0);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 0;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[1].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[1].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[1].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(1);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 1;

        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[2].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[2].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[2].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(2);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 2;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[3].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[3].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[3].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(3);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 3;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[4].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[4].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[4].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(4);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 4;

        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[5].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[5].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[5].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(5);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 5;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[6].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[6].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[6].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(6);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 6;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[7].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[7].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[7].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(7);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 7;


        }
        else if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[8].transform.childCount == 0)
        {
            ButtonSearch.transform.SetParent(GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[8].transform, false);
            ButtonSearch.transform.position = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[8].transform.position;
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Add(8);
            ButtonSearch.GetComponent<PersonBattleScript>().idSlot = 8;


        }
        ButtonSearch.GetComponent<PersonBattleScript>().name = _namePers;
        ButtonSearch.GetComponent<PersonBattleScript>().id = Convert.ToInt32(_id);
        ButtonSearch.GetComponent<PersonBattleScript>().rank = _rank;
        ButtonSearch.GetComponent<PersonBattleScript>().levelEvo = Convert.ToInt32(_levelEvo);
        ButtonSearch.GetComponent<PersonBattleScript>().level = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().levelPerson;
        ButtonSearch.GetComponent<PersonBattleScript>().Class = _class;
        ButtonSearch.GetComponent<PersonBattleScript>().Attack = _defens; // Перепутаны с защитой
        ButtonSearch.GetComponent<PersonBattleScript>().Hp = _hp;
        ButtonSearch.GetComponent<PersonBattleScript>().Defens = _attack; // Перепутаны с атакой
        ButtonSearch.GetComponent<PersonBattleScript>().Speed = _speed;
        ButtonSearch.GetComponent<PersonBattleScript>().DamageReduction = DamageReduction;
        ButtonSearch.GetComponent<PersonBattleScript>().CritDamage = CritDamage;
        ButtonSearch.GetComponent<PersonBattleScript>().CritChance = CritChance;
        ButtonSearch.GetComponent<PersonBattleScript>().Evasion = Evasion;
        ButtonSearch.GetComponent<PersonBattleScript>().Accuracy = Accuracy;
        ButtonSearch.GetComponent<PersonBattleScript>().DamageBonus = DamageBonus;
        ButtonSearch.GetComponent<PersonBattleScript>().AntiCrit = AntiCrit;
        ButtonSearch.GetComponent<PersonBattleScript>().Control = Control;
        ButtonSearch.GetComponent<PersonBattleScript>().AntiControl = AntiControl;
        ButtonSearch.GetComponent<PersonBattleScript>().Treatment = Treatment;
        ButtonSearch.GetComponent<PersonBattleScript>().Recovery = Recovery;
        ButtonSearch.GetComponent<PersonBattleScript>().typePerson = "Enemy";
        ButtonSearch.GetComponent<PersonBattleScript>().skill1 = skill1;
        ButtonSearch.GetComponent<PersonBattleScript>().skill2 = skill2;
        ButtonSearch.GetComponent<PersonBattleScript>().skill3 = skill3;
        ButtonSearch.GetComponent<PersonBattleScript>().skill4Pasiv = skill4Pasiv;
        ButtonSearch.GetComponent<PersonBattleScript>().skill5Pasiv = skill5Pasiv;
    }
    public static void AddSkillPersonPanel(string skill1,string skill2,string skill3,string skill4passiv,string skill5passiv)
    {
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill1 = skill1;
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2 = skill2;
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill3 = skill3;
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill4Pasiv = skill4passiv;
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill5Pasiv = skill5passiv;
        instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().UpdateSkillBlock();
    }
    public static void AddSkillPersonPanelStrF(string name,string description,string skillName)
    {
        if (skillName == "skill1")
        {
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill1Block.GetComponent<SkilsPersonBlock>().Name = name;
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill1Block.GetComponent<SkilsPersonBlock>().Description = description;
        }
        else if (skillName == "skill2")
        {
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2Block.GetComponent<SkilsPersonBlock>().Name = name;
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill2Block.GetComponent<SkilsPersonBlock>().Description = description;
        }
        else if (skillName == "skill3")
        {
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill3Block.GetComponent<SkilsPersonBlock>().Name = name;
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill3Block.GetComponent<SkilsPersonBlock>().Description = description;
        }
        else if (skillName == "skill4")
        {
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill4PassivBlock.GetComponent<SkilsPersonBlock>().Name = name;
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill4PassivBlock.GetComponent<SkilsPersonBlock>().Description = description;
        }
        else if (skillName == "skill5")
        {
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill5PassivBlock.GetComponent<SkilsPersonBlock>().Name = name;
            instance.personPanel.GetComponent<PersControlScript>().skilsPanel.GetComponent<SkilsPanelScript>().skill5PassivBlock.GetComponent<SkilsPersonBlock>().Description = description;
        }
    }
    public static void AddPersonSearchUse(int b, string _namePers, string _id, string _rank, string _levelEvo, int _level, string _class, int _attack, int _hp, int _defens, int _speed, int DamageReduction, int CritDamage, int CritChance, int Evasion, int Accuracy, int DamageBonus, int AntiCrit, int Control, int AntiControl, int Treatment, int Recovery)
    {
        if (instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 1)
        {
            if (_namePers == instance.personPanel.GetComponent<PersControlScript>().name)
            {
                if (Convert.ToInt32(_id) != instance.personPanel.GetComponent<PersControlScript>().id)
                {
                    if (instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Contains(Convert.ToInt32(_id)))
                    {

                    }
                    else
                    {
                        if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 0)
                        {
                            if (Convert.ToInt32(_levelEvo) == 0)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 2)
                        {
                            if (Convert.ToInt32(_levelEvo) == 1)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 3)
                        {
                            if (Convert.ToInt32(_levelEvo) == 0)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 4)
                        {
                            if (Convert.ToInt32(_levelEvo) == 1)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 5)
                        {
                            if (Convert.ToInt32(_levelEvo) == 1)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 6)
                        {
                            if (Convert.ToInt32(_levelEvo) == 1)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 7)
                        {
                            if (Convert.ToInt32(_levelEvo) == 1)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 8)
                        {
                            if (Convert.ToInt32(_levelEvo) == 3)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                        else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 9)
                        {
                            if (Convert.ToInt32(_levelEvo) == 4)
                            {
                                GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                                ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                                ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                                ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                                ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                                ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                                ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                                ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                                ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                                ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                                ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                                ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                                if (_namePers == "King")
                                {

                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                                }
                                else if (_namePers == "The villain with the whip")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                                }
                                else if (_namePers == "Genos")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                                }
                                else if (_namePers == "Tatsumaki Tornado")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                                }
                                else if (_namePers == "Isamu the Cruel Emperor")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                                }
                                else if (_namePers == "Suiryu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                                }
                                else if (_namePers == "Bad Steel Bat")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                                }
                                else if (_namePers == "The master in a Tshirt")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                                }
                                else if (_namePers == "Kamikaze Atomic Samurai")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                                }
                                else if (_namePers == "Asta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                                }
                                else if (_namePers == "Noel Silver")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                                }
                                else if (_namePers == "Yami Sukehiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                                }
                                else if (_namePers == "Yuno")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                                }
                                else if (_namePers == "William Wanjins")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                                }
                                else if (_namePers == "Mereoleon The Crimson Lion")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                                }
                                else if (_namePers == "Fana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                                }
                                else if (_namePers == "Finral Rollcase")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                                }

                                else if (_namePers == "Julius Novochrono")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                                }
                                else if (_namePers == "Zora Ideare")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                                }
                                else if (_namePers == "Gomo gomo zek")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                                }
                                else if (_namePers == "Genrysay Yamamoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                                }
                                else if (_namePers == "Retsu Unohana")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                                }
                                else if (_namePers == "Syuhey Hisagi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                                }
                                else if (_namePers == "Chad")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                                }
                                else if (_namePers == "Kenpachi Zaraki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                                }
                                else if (_namePers == "Djushiro Ikitake")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                                }
                                else if (_namePers == "Byakuya Kuchiki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                                }
                                else if (_namePers == "Yumichka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                                }
                                else if (_namePers == "Sandji Komamura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                                }
                                else if (_namePers == "Yuriu Isida")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                                }
                                else if (_namePers == "Rangiku Matsumoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                                }
                                else if (_namePers == "Ikkaku Maderame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                                }
                                else if (_namePers == "Gin")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                                }
                                else if (_namePers == "Hirako")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                                }
                                else if (_namePers == "Aizen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                                }
                                else if (_namePers == "Grimjou")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                                }
                                else if (_namePers == "Soy-Fon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                                }
                                else if (_namePers == "Kurasaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                                }
                                else if (_namePers == "Kento Nanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                                }
                                else if (_namePers == "Kigusaki Nabora")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                                }
                                else if (_namePers == "Zenin Maki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                                }
                                else if (_namePers == "Yuta Okkotsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                                }
                                else if (_namePers == "Todji Fushigura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                                }
                                else if (_namePers == "Djogo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                                }
                                else if (_namePers == "Suguru Geto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                                }
                                else if (_namePers == "Todo Ayo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                                }
                                else if (_namePers == "Kusumi Miva")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                                }
                                else if (_namePers == "Ryomen Sukuna")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                                }
                                else if (_namePers == "Satoru Godjo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                                }
                                else if (_namePers == "Mahito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                                }
                                else if (_namePers == "Hanami")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                                }
                                else if (_namePers == "Itadori Yudji")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                                }
                                else if (_namePers == "Beng")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                                }
                                else if (_namePers == "Satoru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                                }
                                else if (_namePers == "Sonik")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                                }
                                else if (_namePers == "May Mask")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                                }
                                else if (_namePers == "Garo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                                }
                                else if (_namePers == "Prujinyashii Us")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                                }
                                else if (_namePers == "Maskitnaya Jenshina")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                                }
                                else if (_namePers == "Choso")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                                }
                                else if (_namePers == "Fushigura Megumia")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                                }
                                else if (_namePers == "Panda")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                                }
                                else if (_namePers == "Rengoku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                                }
                                else if (_namePers == "Sanemi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                                }
                                else if (_namePers == "Tomioka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                                }
                                else if (_namePers == "Nezuko")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                                }
                                else if (_namePers == "Tandjiro")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                                }
                                else if (_namePers == "Susamaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                                }
                                else if (_namePers == "Zenitsu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                                }
                                else if (_namePers == "Mudzan")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                                }
                                else if (_namePers == "Gyutago")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                                }
                                else if (_namePers == "Inoske")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                                }
                                else if (_namePers == "Shinobu Kocho")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                                }
                                else if (_namePers == "Toketu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                                }
                                else if (_namePers == "Gyumey")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                                }
                                else if (_namePers == "Kokushibo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                                }
                                else if (_namePers == "Tengen")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                                }
                                else if (_namePers == "Kaygaku")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                                }
                                else if (_namePers == "Reve")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                                }
                                else if (_namePers == "Gordon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                                }
                                else if (_namePers == "Kaiser")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                                }
                                else if (_namePers == "Zarget Demon")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                                }
                                else if (_namePers == "Gosh")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                                }
                                else if (_namePers == "Langris")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                                }
                                else if (_namePers == "Lack")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                                }
                                else if (_namePers == "Vanika")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                                }
                                else if (_namePers == "Doroti")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                                }
                                else if (_namePers == "Nomu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                                }
                                else if (_namePers == "Shoto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                                }
                                else if (_namePers == "Tokoyame")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                                }
                                else if (_namePers == "Tsuyu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                                }
                                else if (_namePers == "Dabi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                                }
                                else if (_namePers == "Bakugo")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                                }
                                else if (_namePers == "Uraraka")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                                }
                                else if (_namePers == "Gran Torino")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                                }
                                else if (_namePers == "All might")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                                }
                                else if (_namePers == "Izuki Midoriya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                                }
                                else if (_namePers == "Himiko Toga")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                                }
                                else if (_namePers == "Muskular")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                                }
                                else if (_namePers == "Kirishima")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                                }
                                else if (_namePers == "Staratel")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                                }
                                else if (_namePers == "Shtein")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                                }
                                else if (_namePers == "Momo Yayorozu")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                                }
                                else if (_namePers == "Minoru Mineta")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                                }
                                else if (_namePers == "Mitsuki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                                }
                                else if (_namePers == "Kakashi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                                }
                                else if (_namePers == "Orochimaru")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                                }
                                else if (_namePers == "Obito")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                                }
                                else if (_namePers == "Naruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                                }
                                else if (_namePers == "Jiraya")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                                }
                                else if (_namePers == "Kavaki")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                                }
                                else if (_namePers == "Boruto")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                                }
                                else if (_namePers == "Mifune")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                                }
                                else if (_namePers == "Sasuke")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                                }
                                else if (_namePers == "Sarada")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                                }
                                else if (_namePers == "Madara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                                }
                                else if (_namePers == "Kurenay")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                                }
                                else if (_namePers == "Sakura")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                                }
                                else if (_namePers == "Gaara")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                                }
                                else if (_namePers == "Hashirama")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                                }
                                else if (_namePers == "Tsunade")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                                }
                                else if (_namePers == "Itachi")
                                {
                                    ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                                }
                            }
                        }
                    }
                    
                }
                


            }
        }
        if (instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 2)
        {
            if (Convert.ToInt32(_id) != instance.personPanel.GetComponent<PersControlScript>().id)
            {
                if (instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Contains(Convert.ToInt32(_id)))
                {

                }
                else
                {
                    if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 0)
                    {

                        if (Convert.ToInt32(_levelEvo) == 0)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 1)
                    {
                        if (Convert.ToInt32(_levelEvo) == 0)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 2)
                    {
                        if (Convert.ToInt32(_levelEvo) == 0)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 3)
                    {
                        if (Convert.ToInt32(_levelEvo) == 3)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 4)
                    {
                        if (Convert.ToInt32(_levelEvo) == 4)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 5)
                    {
                        if (Convert.ToInt32(_levelEvo) == 4)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 6)
                    {
                        if (Convert.ToInt32(_levelEvo) == 5)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 7)
                    {
                        if (Convert.ToInt32(_levelEvo) == 5)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 8)
                    {
                        if (Convert.ToInt32(_levelEvo) == 5)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                    else if (instance.personPanel.GetComponent<PersControlScript>().levelEvo == 9)
                    {
                        if (Convert.ToInt32(_levelEvo) == 5)
                        {
                            GameObject ButtonSearch = Instantiate(GameControll.instance.PersonPrefab);
                            ButtonSearch.transform.SetParent(GameControll.instance.PersonsUseFather.transform, false);
                            ButtonSearch.GetComponent<PersonPrefabScript>().name = _namePers;
                            ButtonSearch.GetComponent<PersonPrefabScript>().id = Convert.ToInt32(_id);
                            ButtonSearch.GetComponent<PersonPrefabScript>().rank = _rank;
                            ButtonSearch.GetComponent<PersonPrefabScript>().levelEvo = Convert.ToInt32(_levelEvo);
                            ButtonSearch.GetComponent<PersonPrefabScript>().level = _level;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Class = _class;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Attack = _defens; // Перепутаны с защитой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Hp = _hp;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Defens = _attack; // Перепутаны с атакой
                            ButtonSearch.GetComponent<PersonPrefabScript>().Speed = _speed;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageReduction = DamageReduction;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritDamage = CritDamage;
                            ButtonSearch.GetComponent<PersonPrefabScript>().CritChance = CritChance;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Evasion = Evasion;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Accuracy = Accuracy;
                            ButtonSearch.GetComponent<PersonPrefabScript>().DamageBonus = DamageBonus;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiCrit = AntiCrit;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Control = Control;
                            ButtonSearch.GetComponent<PersonPrefabScript>().AntiControl = AntiControl;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Treatment = Treatment;
                            ButtonSearch.GetComponent<PersonPrefabScript>().Recovery = Recovery;

                            if (_namePers == "King")
                            {

                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[0];

                            }
                            else if (_namePers == "The villain with the whip")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[10];

                            }
                            else if (_namePers == "Genos")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[4];

                            }
                            else if (_namePers == "Tatsumaki Tornado")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[17];

                            }
                            else if (_namePers == "Isamu the Cruel Emperor")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[11];

                            }
                            else if (_namePers == "Suiryu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[3];

                            }
                            else if (_namePers == "Bad Steel Bat")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[7];

                            }
                            else if (_namePers == "The master in a Tshirt")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[5];

                            }
                            else if (_namePers == "Kamikaze Atomic Samurai")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[12];

                            }
                            else if (_namePers == "Asta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[18];

                            }
                            else if (_namePers == "Noel Silver")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[19];

                            }
                            else if (_namePers == "Yami Sukehiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[20];

                            }
                            else if (_namePers == "Yuno")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[21];

                            }
                            else if (_namePers == "William Wanjins")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[22];

                            }
                            else if (_namePers == "Mereoleon The Crimson Lion")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[23];

                            }
                            else if (_namePers == "Fana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[24];

                            }
                            else if (_namePers == "Finral Rollcase")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[25];

                            }

                            else if (_namePers == "Julius Novochrono")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[26];

                            }
                            else if (_namePers == "Zora Ideare")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[27];

                            }
                            else if (_namePers == "Gomo gomo zek")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[28];

                            }
                            else if (_namePers == "Genrysay Yamamoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[29];

                            }
                            else if (_namePers == "Retsu Unohana")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[30];

                            }
                            else if (_namePers == "Syuhey Hisagi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[31];

                            }
                            else if (_namePers == "Chad")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[32];

                            }
                            else if (_namePers == "Kenpachi Zaraki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[33];

                            }
                            else if (_namePers == "Djushiro Ikitake")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[34];

                            }
                            else if (_namePers == "Byakuya Kuchiki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[35];

                            }
                            else if (_namePers == "Yumichka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[36];

                            }
                            else if (_namePers == "Sandji Komamura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[37];

                            }
                            else if (_namePers == "Yuriu Isida")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[38];

                            }
                            else if (_namePers == "Rangiku Matsumoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[39];

                            }
                            else if (_namePers == "Ikkaku Maderame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[40];

                            }
                            else if (_namePers == "Gin")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[41];

                            }
                            else if (_namePers == "Hirako")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[42];

                            }
                            else if (_namePers == "Aizen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[43];

                            }
                            else if (_namePers == "Grimjou")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[44];

                            }
                            else if (_namePers == "Soy-Fon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[45];

                            }
                            else if (_namePers == "Kurasaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[46];

                            }
                            else if (_namePers == "Kento Nanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[47];

                            }
                            else if (_namePers == "Kigusaki Nabora")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[48];

                            }
                            else if (_namePers == "Zenin Maki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[49];

                            }
                            else if (_namePers == "Yuta Okkotsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[50];

                            }
                            else if (_namePers == "Todji Fushigura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[51];

                            }
                            else if (_namePers == "Djogo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[52];

                            }
                            else if (_namePers == "Suguru Geto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[53];

                            }
                            else if (_namePers == "Todo Ayo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[54];

                            }
                            else if (_namePers == "Kusumi Miva")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[55];

                            }
                            else if (_namePers == "Ryomen Sukuna")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[56];

                            }
                            else if (_namePers == "Satoru Godjo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[57];

                            }
                            else if (_namePers == "Mahito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[58];

                            }
                            else if (_namePers == "Hanami")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[59];

                            }
                            else if (_namePers == "Itadori Yudji")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[60];

                            }
                            else if (_namePers == "Beng")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[61];

                            }
                            else if (_namePers == "Satoru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[62];

                            }
                            else if (_namePers == "Sonik")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[63];

                            }
                            else if (_namePers == "May Mask")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[64];

                            }
                            else if (_namePers == "Garo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[65];

                            }
                            else if (_namePers == "Prujinyashii Us")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[66];

                            }
                            else if (_namePers == "Maskitnaya Jenshina")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[67];

                            }
                            else if (_namePers == "Choso")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[68];

                            }
                            else if (_namePers == "Fushigura Megumia")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[69];

                            }
                            else if (_namePers == "Panda")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[130];

                            }
                            else if (_namePers == "Rengoku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[70];

                            }
                            else if (_namePers == "Sanemi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[71];

                            }
                            else if (_namePers == "Tomioka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[72];

                            }
                            else if (_namePers == "Nezuko")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[73];

                            }
                            else if (_namePers == "Tandjiro")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[74];

                            }
                            else if (_namePers == "Susamaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[75];

                            }
                            else if (_namePers == "Zenitsu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[76];

                            }
                            else if (_namePers == "Mudzan")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[77];

                            }
                            else if (_namePers == "Gyutago")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[78];

                            }
                            else if (_namePers == "Inoske")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[79];

                            }
                            else if (_namePers == "Shinobu Kocho")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[80];

                            }
                            else if (_namePers == "Toketu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[81];

                            }
                            else if (_namePers == "Gyumey")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[82];

                            }
                            else if (_namePers == "Kokushibo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[83];

                            }
                            else if (_namePers == "Tengen")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[84];

                            }
                            else if (_namePers == "Kaygaku")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[85];

                            }
                            else if (_namePers == "Reve")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[86];

                            }
                            else if (_namePers == "Gordon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[87];

                            }
                            else if (_namePers == "Kaiser")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[88];

                            }
                            else if (_namePers == "Zarget Demon")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[89];

                            }
                            else if (_namePers == "Gosh")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[90];

                            }
                            else if (_namePers == "Langris")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[91];

                            }
                            else if (_namePers == "Lack")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[92];

                            }
                            else if (_namePers == "Vanika")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[93];

                            }
                            else if (_namePers == "Doroti")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[94];

                            }
                            else if (_namePers == "Nomu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[95];

                            }
                            else if (_namePers == "Shoto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[96];

                            }
                            else if (_namePers == "Tokoyame")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[97];

                            }
                            else if (_namePers == "Tsuyu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[98];

                            }
                            else if (_namePers == "Dabi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[99];

                            }
                            else if (_namePers == "Bakugo")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[100];

                            }
                            else if (_namePers == "Uraraka")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[101];

                            }
                            else if (_namePers == "Gran Torino")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[102];

                            }
                            else if (_namePers == "All might")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[103];

                            }
                            else if (_namePers == "Izuki Midoriya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[104];

                            }
                            else if (_namePers == "Himiko Toga")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[105];

                            }
                            else if (_namePers == "Muskular")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[106];

                            }
                            else if (_namePers == "Kirishima")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[107];

                            }
                            else if (_namePers == "Staratel")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[108];

                            }
                            else if (_namePers == "Shtein")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[109];

                            }
                            else if (_namePers == "Momo Yayorozu")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[110];

                            }
                            else if (_namePers == "Minoru Mineta")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[111];

                            }
                            else if (_namePers == "Mitsuki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[112];

                            }
                            else if (_namePers == "Kakashi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[113];

                            }
                            else if (_namePers == "Orochimaru")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[114];

                            }
                            else if (_namePers == "Obito")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[115];

                            }
                            else if (_namePers == "Naruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[116];

                            }
                            else if (_namePers == "Jiraya")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[117];

                            }
                            else if (_namePers == "Kavaki")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[118];

                            }
                            else if (_namePers == "Boruto")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[119];

                            }
                            else if (_namePers == "Mifune")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[120];

                            }
                            else if (_namePers == "Sasuke")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[121];

                            }
                            else if (_namePers == "Sarada")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[122];

                            }
                            else if (_namePers == "Madara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[123];

                            }
                            else if (_namePers == "Kurenay")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[124];

                            }
                            else if (_namePers == "Sakura")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[125];

                            }
                            else if (_namePers == "Gaara")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[126];

                            }
                            else if (_namePers == "Hashirama")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[127];

                            }
                            else if (_namePers == "Tsunade")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[128];

                            }
                            else if (_namePers == "Itachi")
                            {
                                ButtonSearch.GetComponent<PersonPrefabScript>().Image.sprite = GameControll.instance.AvatarPerson[129];

                            }
                        }
                    }
                }
                
            }
            
        }
        //Debug.Log(ButtonSearch.gameObject.transform.Find("NameServer"));
        //Debug.Log(ButtonSearch.transform.localPosition);

    }
    public void PersonsButtonOn()
    {
        if (persons.activeSelf == true || personPanel.activeSelf == true || PvePanel.activeSelf == true)
        {
            persons.SetActive(false);
            personPanel.SetActive(false);
        }
        else
        {
            ClientSend.PersonSearchUser();
            ClientSend.InventorySearchUser();
            ClientSend.GetUpPanel();
            persons.SetActive(true);
            while (PersonsFather.transform.childCount > 0)
            {
                DestroyImmediate(PersonsFather.transform.GetChild(0).gameObject);
            }
        }

    }
}
