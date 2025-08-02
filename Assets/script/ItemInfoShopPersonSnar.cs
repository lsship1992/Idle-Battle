using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class ItemInfoShopPersonSnar : MonoBehaviour
{
    public string NameItem;
    public string RangItem;
    [SerializeField] private Text NameText;
    [SerializeField] private Text TypeText;
    [SerializeField] private Image ImageSlot;
    public string type;
    public string Nameru = "";
    [SerializeField] private Text AttackText;
    [SerializeField] private Text DefensText;
    [SerializeField] private Text SpeedText;
    [SerializeField] private Text HpText;
    public int Attack;
    public int Defens;
    public int Speed;
    public int Hp;
    public int id;
    public int idItemShop;
    public string Valet;
    public float Price;
    public int MaxByu;
    public int Byu;
    public string description;
    public Text descriptionText;
    public GameObject HpObj;
    public GameObject AttackObj;
    public GameObject DefensObj;
    public GameObject SpeedObj;
    public void buy()
    {
        
        if (Valet == "serebro")
        {
            if (GameControll.instance.gold >= Price)
            {
                if (MaxByu != Byu)
                {
                    if (Nameru == "Bilet areny")
                    {
                        ClientSend.UserAddMateralAcc(1, Nameru,id);
                        ClientSend.ValuteUpdate((int)Price, "Gold", "-");
                    }
                    else if (type == "Person")
                    {
                        ClientSend.BuyShopPerson(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Gold", "-");

                    }
                    else if (type == "Snar")
                    {

                        ClientSend.BuyShopSnar(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Gold", "-");

                    }
                    else if (type == "Predmet")
                    {

                        ClientSend.BuyShopPredmet(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Gold", "-");

                    }
                }
            }
        }
        else if (Valet == "almaz")
        {
            if (GameControll.instance.almazInt >= Price)
            {
                if (MaxByu != Byu)
                {
                    if (Nameru == "Bilet areny")
                    {
                        ClientSend.UserAddMateralAcc(1, Nameru,id);
                        ClientSend.ValuteUpdate((int)Price, "Almaz", "-");

                    }
                    else if (type == "Person")
                    {
                        ClientSend.BuyShopPerson(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Almaz", "-");

                    }
                    else if (type == "Snar")
                    {

                        ClientSend.BuyShopSnar(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Almaz", "-");

                    }
                    else if (type == "Predmet")
                    {

                        ClientSend.BuyShopPredmet(idItemShop, id);
                        ClientSend.ValuteUpdate((int)Price, "Almaz", "-");

                    }
                }
            }
        }
        else if (Valet == "KlanMoney")
        {
            if (GameControll.instance.ShopPanel.GetComponent<Shop>().KlanMoney >= Price)
            {
                if (MaxByu != Byu)
                {
                    if (Nameru == "Bilet areny")
                    {
                        ClientSend.UserAddMateralAcc(1, Nameru, id,true);
                        ClientSend.VischetMoney(Convert.ToInt32(Price), "KlanMoney");
                    }
                    else if (type == "Person")
                    {
                        ClientSend.BuyShopPerson(idItemShop, id,true);
                        ClientSend.VischetMoney(Convert.ToInt32(Price), "KlanMoney");

                    }
                    else if (type == "Snar")
                    {

                        ClientSend.BuyShopSnar(idItemShop, id,true);
                        ClientSend.VischetMoney(Convert.ToInt32(Price), "KlanMoney");

                    }
                    else if (type == "Predmet")
                    {

                        ClientSend.BuyShopPredmet(idItemShop, id,true);
                        ClientSend.VischetMoney(Convert.ToInt32(Price), "KlanMoney");

                    }
                }
            }
        }
       
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        NameText.text = Nameru;
        if (type == "Snar" || type == "Person")
        {
            AttackText.text = $"{(BigInteger)Attack}";
            DefensText.text = $"{(BigInteger)Defens}";
            SpeedText.text = $"{(BigInteger)Speed}";
            HpText.text = $"{(BigInteger)Hp}";
            descriptionText.text = "";
            TypeText.text = RangItem;
            HpObj.SetActive(true);
            AttackObj.SetActive(true);
            DefensObj.SetActive(true);
            SpeedObj.SetActive(true);
        }
        else if (type == "Predmet")
        {
            descriptionText.text = description;
            AttackText.text = $"";
            DefensText.text = $"";
            SpeedText.text = $"";
            HpText.text = $"";
            TypeText.text = "Предмет";
            HpObj.SetActive(false);
            AttackObj.SetActive(false);
            DefensObj.SetActive(false);
            SpeedObj.SetActive(false);
        }
        if (type == "Snar")
        {
            if (NameItem == "Book")
            {
                if (Nameru == "The Book of Blessings of the Earth")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[72];
                }
                else if (Nameru == "The Book of Dark Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[77];
                }
                else if (Nameru == "Universal Book")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[71];
                }
                else if (Nameru == "The Book of Green Nature")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[74];
                }
                else if (Nameru == "The Book of Holiness")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[76];
                }
                else if (Nameru == "The book of power")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[69];
                }
                else if (Nameru == "The book of life")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[67];
                }
                else if (Nameru == "Book of protection")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[68];
                }
                else if (Nameru == "Speed book")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[70];
                }
                else if (Nameru == "The Book of Water Spirits")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[73];
                }
                else if (Nameru == "The Book of Dead Spirits")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[75];
                }
                
               
            }
            if (NameItem == "Helmet")
            {
                if (Nameru == "Beginner helmet")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[20];
                }
                else if (Nameru == "Dark Crystal helmet")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[21];
                }
                else if (Nameru == "Dinasty helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[24];
                }
                else if (Nameru == "Draconik helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[23];
                }
                else if (Nameru == "Majestik helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[25];
                }
                else if (Nameru == "Tallum helmett")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[22];
                }
                else if (Nameru == "Ice Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[28];
                }
                else if (Nameru == "Imperial Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[27];
                }
                else if (Nameru == "Golden Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[115];
                }
                else if (Nameru == "Demonic Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[26];
                }
                

            }
            if (NameItem == "Bots")
            {
                if (Nameru == "Beginner boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[0];

                }
                else if (Nameru == "Majestik boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[4];
                }
                else if (Nameru == "Tallum boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[5];

                }
                else if (Nameru == "Demonic Boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[6];

                }
                else if (Nameru == "Golden Shoes")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[7];

                }
                else if (Nameru == "Ice boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[9];

                }
                else if (Nameru == "Imperial Boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[8];

                }
                else if (Nameru == "Dark Crystal boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[1];

                }
                else if (Nameru == "Dinasty boots S")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[3];

                }
                else if (Nameru == "Draconik boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[2];

                }
            }
            if (NameItem == "Weapon")
            {
                if (Nameru == "Demonic Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[49];

                }
                else if (Nameru == "Demonic Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[47];
                }
                else if (Nameru == "The Golden Wrecker")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[54];

                }
                else if (Nameru == "Golden Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[56];

                }
                else if (Nameru == "Golden Peak")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[52];

                }
                else if (Nameru == "Golden Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[53];

                }
                else if (Nameru == "The Imperial Sword of Justice")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[61];

                }
                else if (Nameru == "Golden Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[55];

                }
                else if (Nameru == "Imperial Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[59];

                }
                else if (Nameru == "Imperial Snake Fangs")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[57];

                }
                else if (Nameru == "The Imperial Spellcaster")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[60];

                }
                else if (Nameru == "The Imperial Axe")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[58];

                }
                else if (Nameru == "Ice Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[64];

                }
                else if (Nameru == "Ice Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[63];

                }
                else if (Nameru == "Ice Caster")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[62];

                }
                else if (Nameru == "Ice Piercer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[566];

                }
                else if (Nameru == "Ice Staff")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[65];

                }
                else if (Nameru == "The Demonic Wand")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[48];

                }
                else if (Nameru == "Demonic Staff")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[51];

                }
                else if (Nameru == "Demonic Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[50];

                }
                else if (Nameru == "Killer dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[46];

                }
                else if (Nameru == "Bazalt hammer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[44];

                }
                else if (Nameru == "Bloody orich dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[42];

                }
                else if (Nameru == "Cristal dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[43];

                }
                else if (Nameru == "Dark legion sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[41];

                }
                else if (Nameru == "Beginner wooden sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[39];

                }
                else if (Nameru == "Dragon slayer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[40];

                }
                else if (Nameru == "duals of greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[45];

                }


            }
            if (NameItem == "Armor")
            {
                if (Nameru == "Beginner armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[29];

                }
                else if (Nameru == "Imperial Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[37];
                }
                else if (Nameru == "Dark Crystal armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[34];

                }
                else if (Nameru == "Dinasty armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[30];

                }
                else if (Nameru == "Draconik armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[33];

                }
                else if (Nameru == "Majestik armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[32];

                }
                else if (Nameru == "Tallum armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[31];

                }
                else if (Nameru == "Demonic Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[35];

                }
                else if (Nameru == "Golden Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[36];

                }
                else if (Nameru == "Ice Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[38];

                }
               
            }
            if (NameItem == "Gloves")
            {
                if (Nameru == "Tallum gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[11];

                }
                else if (Nameru == "Beginner gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[10];
                }
                else if (Nameru == "Demonic Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[16];

                }
                else if (Nameru == "Dark Crystal gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[12];

                }
                else if (Nameru == "Dinasty gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[13];

                }
                else if (Nameru == "Draconik gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[15];

                }
                else if (Nameru == "Majestik gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[14];

                }
                else if (Nameru == "Golden Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[17];

                }
                else if (Nameru == "Imperial Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[18];

                }
                else if (Nameru == "Ice Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[19];

                }
            }
            if (NameItem == "Rings")
            {
                if (Nameru == "Power Core Rings")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[84];

                }
                else if (Nameru == "The Ant Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[85];
                }
                else if (Nameru == "Ruby Power Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[83];

                }
                else if (Nameru == "Beginner ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[82];

                }
                else if (Nameru == "Demans Ring of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[93];

                }
                else if (Nameru == "Imperial Control Rings")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[86];

                }
                else if (Nameru == "The Imperial Ring of Crete")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[87];

                }
                else if (Nameru == "The Imperial Ring of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[88];

                }
                else if (Nameru == "Charm Power Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[90];

                }
                else if (Nameru == "The Ring of Wisdom Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[89];

                }
                else if (Nameru == "The Ring of power of Aspiration")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[91];

                }
                else if (Nameru == "The ring of Deman luck")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[92];

                }
                
            }
            if (NameItem == "Earrings")
            {
                if (Nameru == "Magnificent earring of Greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[109];

                }
                else if (Nameru == "The earring of the heart of the ice dragon of rage")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[114];
                }
                else if (Nameru == "Beginner earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[105];

                }
                else if (Nameru == "Lich earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[106];

                }
                else if (Nameru == "Dinasty earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[107];

                }
                else if (Nameru == "Core Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[108];

                }
                else if (Nameru == "The earring of the heart of the ice dragon of darkness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[113];

                }
                else if (Nameru == "Ice Dragon Heart Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[112];

                }
                else if (Nameru == "Magnificent earring of good luck")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[111];

                }
                else if (Nameru == "Gorgeous Charm Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[110];

                }
                
            }
            if (NameItem == "Necklace")
            {
                if (Nameru == "Beginner necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[95];

                }
                else if (Nameru == "Lich necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[97];
                }
                else if (Nameru == "Dinasty necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[98];

                }
                else if (Nameru == "Demonic Necklace of Greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[99];

                }
                else if (Nameru == "Dragon Necklace of Wisdom")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[102];

                }
                else if (Nameru == "core necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[96];

                }
                else if (Nameru == "Demonic Necklace of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[100];

                }
                else if (Nameru == "Demonic Necklace of Darkness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[101];

                }
                else if (Nameru == "Dragon Charm Necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[103];

                }
                else if (Nameru == "Dragon Necklace of Aspiration")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[104];

                }
            }
        }
        else if (type == "Person")
        {
            if (Nameru == "King")
            {

                ImageSlot.sprite = GameControll.instance.AvatarPerson[0];

            }
            else if (Nameru == "The villain with the whip")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[10];

            }
            else if (Nameru == "Genos")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[4];

            }
            else if (Nameru == "Tatsumaki Tornado")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[17];

            }
            else if (Nameru == "Isamu the Cruel Emperor")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[11];

            }
            else if (Nameru == "Suiryu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[3];

            }
            else if (Nameru == "Bad Steel Bat")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[7];

            }
            else if (Nameru == "The master in a Tshirt")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[5];

            }
            else if (Nameru == "Kamikaze Atomic Samurai")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[12];

            }
            else if (Nameru == "Asta")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[18];

            }
            else if (Nameru == "Noel Silver")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[19];

            }
            else if (Nameru == "Yami Sukehiro")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[20];

            }
            else if (Nameru == "Yuno")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[21];

            }
            else if (Nameru == "William Wanjins")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[22];

            }
            else if (Nameru == "Mereoleon The Crimson Lion")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[23];

            }
            else if (Nameru == "Fana")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[24];

            }
            else if (Nameru == "Finral Rollcase")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[25];

            }

            else if (Nameru == "Julius Novochrono")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[26];

            }
            else if (Nameru == "Zora Ideare")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[27];

            }
            else if (Nameru == "Gomo gomo zek")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[28];

            }
            else if (Nameru == "Genrysay Yamamoto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[29];

            }
            else if (Nameru == "Retsu Unohana")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[30];

            }
            else if (Nameru == "Syuhey Hisagi")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[31];

            }
            else if (Nameru == "Chad")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[32];

            }
            else if (Nameru == "Kenpachi Zaraki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[33];

            }
            else if (Nameru == "Djushiro Ikitake")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[34];

            }
            else if (Nameru == "Byakuya Kuchiki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[35];

            }
            else if (Nameru == "Yumichka")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[36];

            }
            else if (Nameru == "Sandji Komamura")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[37];

            }
            else if (Nameru == "Yuriu Isida")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[38];

            }
            else if (Nameru == "Rangiku Matsumoto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[39];

            }
            else if (Nameru == "Ikkaku Maderame")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[40];

            }
            else if (Nameru == "Gin")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[41];

            }
            else if (Nameru == "Hirako")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[42];

            }
            else if (Nameru == "Aizen")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[43];

            }
            else if (Nameru == "Grimjou")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[44];

            }
            else if (Nameru == "Soy-Fon")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[45];

            }
            else if (Nameru == "Kurasaki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[46];

            }
            else if (Nameru == "Kento Nanami")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[47];

            }
            else if (Nameru == "Kigusaki Nabora")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[48];

            }
            else if (Nameru == "Zenin Maki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[49];

            }
            else if (Nameru == "Yuta Okkotsu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[50];

            }
            else if (Nameru == "Todji Fushigura")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[51];

            }
            else if (Nameru == "Djogo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[52];

            }
            else if (Nameru == "Suguru Geto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[53];

            }
            else if (Nameru == "Todo Ayo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[54];

            }
            else if (Nameru == "Kusumi Miva")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[55];

            }
            else if (Nameru == "Ryomen Sukuna")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[56];

            }
            else if (Nameru == "Satoru Godjo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[57];

            }
            else if (Nameru == "Mahito")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[58];

            }
            else if (Nameru == "Hanami")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[59];

            }
            else if (Nameru == "Itadori Yudji")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[60];

            }
            else if (Nameru == "Beng")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[61];

            }
            else if (Nameru == "Satoru")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[62];

            }
            else if (Nameru == "Sonik")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[63];

            }
            else if (Nameru == "May Mask")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[64];

            }
            else if (Nameru == "Garo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[65];

            }
            else if (Nameru == "Prujinyashii Us")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[66];

            }
            else if (Nameru == "Maskitnaya Jenshina")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[67];

            }
            else if (Nameru == "Choso")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[68];

            }
            else if (Nameru == "Fushigura Megumia")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[69];

            }
            else if (Nameru == "Panda")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[130];

            }
            else if (Nameru == "Rengoku")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[70];

            }
            else if (Nameru == "Sanemi")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[71];

            }
            else if (Nameru == "Tomioka")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[72];

            }
            else if (Nameru == "Nezuko")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[73];

            }
            else if (Nameru == "Tandjiro")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[74];

            }
            else if (Nameru == "Susamaru")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[75];

            }
            else if (Nameru == "Zenitsu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[76];

            }
            else if (Nameru == "Mudzan")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[77];

            }
            else if (Nameru == "Gyutago")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[78];

            }
            else if (Nameru == "Inoske")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[79];

            }
            else if (Nameru == "Shinobu Kocho")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[80];

            }
            else if (Nameru == "Toketu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[81];

            }
            else if (Nameru == "Gyumey")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[82];

            }
            else if (Nameru == "Kokushibo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[83];

            }
            else if (Nameru == "Tengen")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[84];

            }
            else if (Nameru == "Kaygaku")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[85];

            }
            else if (Nameru == "Reve")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[86];

            }
            else if (Nameru == "Gordon")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[87];

            }
            else if (Nameru == "Kaiser")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[88];

            }
            else if (Nameru == "Zarget Demon")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[89];

            }
            else if (Nameru == "Gosh")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[90];

            }
            else if (Nameru == "Langris")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[91];

            }
            else if (Nameru == "Lack")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[92];

            }
            else if (Nameru == "Vanika")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[93];

            }
            else if (Nameru == "Doroti")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[94];

            }
            else if (Nameru == "Nomu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[95];

            }
            else if (Nameru == "Shoto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[96];

            }
            else if (Nameru == "Tokoyame")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[97];

            }
            else if (Nameru == "Tsuyu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[98];

            }
            else if (Nameru == "Dabi")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[99];

            }
            else if (Nameru == "Bakugo")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[100];

            }
            else if (Nameru == "Uraraka")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[101];

            }
            else if (Nameru == "Gran Torino")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[102];

            }
            else if (Nameru == "All might")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[103];

            }
            else if (Nameru == "Izuki Midoriya")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[104];

            }
            else if (Nameru == "Himiko Toga")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[105];

            }
            else if (Nameru == "Muskular")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[106];

            }
            else if (Nameru == "Kirishima")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[107];

            }
            else if (Nameru == "Staratel")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[108];

            }
            else if (Nameru == "Shtein")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[109];

            }
            else if (Nameru == "Momo Yayorozu")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[110];

            }
            else if (Nameru == "Minoru Mineta")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[111];

            }
            else if (Nameru == "Mitsuki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[112];

            }
            else if (Nameru == "Kakashi")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[113];

            }
            else if (Nameru == "Orochimaru")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[114];

            }
            else if (Nameru == "Obito")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[115];

            }
            else if (Nameru == "Naruto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[116];

            }
            else if (Nameru == "Jiraya")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[117];

            }
            else if (Nameru == "Kavaki")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[118];

            }
            else if (Nameru == "Boruto")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[119];

            }
            else if (Nameru == "Mifune")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[120];

            }
            else if (Nameru == "Sasuke")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[121];

            }
            else if (Nameru == "Sarada")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[122];

            }
            else if (Nameru == "Madara")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[123];

            }
            else if (Nameru == "Kurenay")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[124];

            }
            else if (Nameru == "Sakura")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[125];

            }
            else if (Nameru == "Gaara")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[126];

            }
            else if (Nameru == "Hashirama")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[127];

            }
            else if (Nameru == "Tsunade")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[128];

            }
            else if (Nameru == "Itachi")
            {
                ImageSlot.sprite = GameControll.instance.AvatarPerson[129];

            }
        }
        else if (type == "Predmet")
        {
            if (Nameru == "UserUpdateMaterial")
            {
                ImageSlot.sprite = GameControll.instance.material[0];
            }
            else if (Nameru == "svitok")
            {
                ImageSlot.sprite = GameControll.instance.material[1];
            }
            else if (Nameru == "modifikator")
            {
                ImageSlot.sprite = GameControll.instance.material[2];
            }
            else if (Nameru == "Zelie rosta")
            {
                ImageSlot.sprite = GameControll.instance.material[3];
            }
            else if (Nameru == "Zelia usileniya")
            {
                ImageSlot.sprite = GameControll.instance.material[4];
            }
            else if (Nameru == "Svitok zatochki A")
            {
                ImageSlot.sprite = GameControll.instance.material[5];
            }
            else if (Nameru == "Svitok zatochki S")
            {
                ImageSlot.sprite = GameControll.instance.material[6];
            }
            else if (Nameru == "Svitok zatochki SR")
            {
                ImageSlot.sprite = GameControll.instance.material[7];
            }
            else if (Nameru == "Bilet areny")
            {
                ImageSlot.sprite = GameControll.instance.material[8];
            }
        }
    }
}
