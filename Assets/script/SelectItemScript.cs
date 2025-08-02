using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemScript : MonoBehaviour
{
    public string NameItem = "";
    public string RangItem;
    public int attack;
    public int defens;
    public int speed;
    public int hp;
    public int _attack_Proc;
    public int _hp_proc;
    public int CritDamage;
    public int DamageBonus;
    public int id;
    public int idPerson;
    public int idItemUI;
    public string Nameru = "";
    public string description = "";
    public int defens_proc;
    public int speed_proc;
    private void Update()
    {
        if (NameItem == "Helmet")
        {

            if (Nameru == "Beginner helmet")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[20];
            }
            else if (Nameru == "Dark Crystal helmet")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[21];
            }
            else if (Nameru == "Dinasty helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[24];
            }
            else if (Nameru == "Draconik helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[23];
            }
            else if (Nameru == "Majestik helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[25];
            }
            else if (Nameru == "Tallum helmett")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[22];
            }
            else if (Nameru == "Ice Helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[28];
            }
            else if (Nameru == "Imperial Helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[27];
            }
            else if (Nameru == "Golden Helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[115];
            }
            else if (Nameru == "Demonic Helmet")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[26];
            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[0];
            }

        }
        else if (idItemUI == 1)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[0];

        }
        if (NameItem == "Bots")
        {

            if (Nameru == "Beginner boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[0];

            }
            else if (Nameru == "Majestik boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[4];
            }
            else if (Nameru == "Tallum boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[5];

            }
            else if (Nameru == "Demonic Boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[6];

            }
            else if (Nameru == "Golden Shoes")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[7];

            }
            else if (Nameru == "Ice boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[9];

            }
            else if (Nameru == "Imperial Boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[8];

            }
            else if (Nameru == "Dark Crystal boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[1];

            }
            else if (Nameru == "Dinasty boots S")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[3];

            }
            else if (Nameru == "Draconik boots")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[2];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[3];
            }
        }
        else if (idItemUI == 4)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[3];

        }

        if (NameItem == "Weapon")
        {

            if (Nameru == "Demonic Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[49];

            }
            else if (Nameru == "Demonic Two-handed Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[47];
            }
            else if (Nameru == "The Golden Wrecker")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[54];

            }
            else if (Nameru == "Golden Knife")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[56];

            }
            else if (Nameru == "Golden Peak")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[52];

            }
            else if (Nameru == "Golden Two-handed Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[53];

            }
            else if (Nameru == "The Imperial Sword of Justice")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[61];

            }
            else if (Nameru == "Golden Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[55];

            }
            else if (Nameru == "Imperial Two-handed Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[59];

            }
            else if (Nameru == "Imperial Snake Fangs")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[57];

            }
            else if (Nameru == "The Imperial Spellcaster")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[60];

            }
            else if (Nameru == "The Imperial Axe")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[58];

            }
            else if (Nameru == "Ice Knife")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[64];

            }
            else if (Nameru == "Ice Sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[63];

            }
            else if (Nameru == "Ice Caster")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[62];

            }
            else if (Nameru == "Ice Piercer")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[566];

            }
            else if (Nameru == "Ice Staff")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[65];

            }
            else if (Nameru == "The Demonic Wand")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[48];

            }
            else if (Nameru == "Demonic Staff")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[51];

            }
            else if (Nameru == "Demonic Knife")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[50];

            }
            else if (Nameru == "Killer dagger")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[46];

            }
            else if (Nameru == "Bazalt hammer")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[44];

            }
            else if (Nameru == "Bloody orich dagger")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[42];

            }
            else if (Nameru == "Cristal dagger")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[43];

            }
            else if (Nameru == "Dark legion sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[41];

            }
            else if (Nameru == "Beginner wooden sword")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[39];

            }
            else if (Nameru == "Dragon slayer")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[40];

            }
            else if (Nameru == "duals of greatness")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[45];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[4];
            }
        }
        else if (idItemUI == 5)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[4];

        }
        if (NameItem == "Armor")
        {

            if (Nameru == "Beginner armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[29];

            }
            else if (Nameru == "Imperial Armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[37];
            }
            else if (Nameru == "Dark Crystal armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[34];

            }
            else if (Nameru == "Dinasty armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[30];

            }
            else if (Nameru == "Draconik armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[33];

            }
            else if (Nameru == "Majestik armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[32];

            }
            else if (Nameru == "Tallum armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[31];

            }
            else if (Nameru == "Demonic Armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[35];

            }
            else if (Nameru == "Golden Armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[36];

            }
            else if (Nameru == "Ice Armor")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[38];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[1];
            }
        }
        else if (idItemUI == 2)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[1];

        }
        if (NameItem == "Gloves")
        {

            if (Nameru == "Tallum gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[11];

            }
            else if (Nameru == "Beginner gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[10];
            }
            else if (Nameru == "Demonic Gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[16];

            }
            else if (Nameru == "Dark Crystal gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[12];

            }
            else if (Nameru == "Dinasty gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[13];

            }
            else if (Nameru == "Draconik gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[15];

            }
            else if (Nameru == "Majestik gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[14];

            }
            else if (Nameru == "Golden Gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[17];

            }
            else if (Nameru == "Imperial Gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[18];

            }
            else if (Nameru == "Ice Gloves")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[19];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[2];
            }
        }
        else if (idItemUI == 3)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[2];

        }
        if (NameItem == "Rings")
        {

            if (Nameru == "Power Core Rings")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[84];

            }
            else if (Nameru == "The Ant Ring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[85];
            }
            else if (Nameru == "Ruby Power Ring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[83];

            }
            else if (Nameru == "Beginner ring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[82];

            }
            else if (Nameru == "Demans Ring of Power")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[93];

            }
            else if (Nameru == "Imperial Control Rings")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[86];

            }
            else if (Nameru == "The Imperial Ring of Crete")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[87];

            }
            else if (Nameru == "The Imperial Ring of Power")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[88];

            }
            else if (Nameru == "Charm Power Ring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[90];

            }
            else if (Nameru == "The Ring of Wisdom Power")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[89];

            }
            else if (Nameru == "The Ring of power of Aspiration")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[91];

            }
            else if (Nameru == "The ring of Deman luck")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[92];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[5];
            }
        }
        else if (idItemUI == 6)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[5];
        }
        if (NameItem == "Earrings")
        {

            if (Nameru == "Magnificent earring of Greatness")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[109];

            }
            else if (Nameru == "The earring of the heart of the ice dragon of rage")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[114];
            }
            else if (Nameru == "Beginner earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[105];

            }
            else if (Nameru == "Lich earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[106];

            }
            else if (Nameru == "Dinasty earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[107];

            }
            else if (Nameru == "Core Earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[108];

            }
            else if (Nameru == "The earring of the heart of the ice dragon of darkness")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[113];

            }
            else if (Nameru == "Ice Dragon Heart Earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[112];

            }
            else if (Nameru == "Magnificent earring of good luck")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[111];

            }
            else if (Nameru == "Gorgeous Charm Earring")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[110];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[6];
            }
        }
        else if (idItemUI == 7)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[6];

        }
        if (NameItem == "Necklace")
        {
            if (Nameru == "Disciple Necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[21];
            }
            else if (Nameru == "Necklace of Light")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[22];
            }
            else if (Nameru == "Dragon Eye Necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[23];
            }
            if (Nameru == "Beginner necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[95];

            }
            else if (Nameru == "Lich necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[97];
            }
            else if (Nameru == "Dinasty necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[98];

            }
            else if (Nameru == "Demonic Necklace of Greatness")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[99];

            }
            else if (Nameru == "Dragon Necklace of Wisdom")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[102];

            }
            else if (Nameru == "core necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[96];

            }
            else if (Nameru == "Demonic Necklace of Power")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[100];

            }
            else if (Nameru == "Demonic Necklace of Darkness")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[101];

            }
            else if (Nameru == "Dragon Charm Necklace")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[103];

            }
            else if (Nameru == "Dragon Necklace of Aspiration")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[104];

            }
            else
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[7];
            }
        }
        else if (idItemUI == 8)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[7];
        }
        if (NameItem == "Book")
        {
            if (Nameru == "The Book of Blessings of the Earth")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[72];
            }
            else if (Nameru == "The Book of Dark Power")
            {
                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[77];
            }
            else if (Nameru == "Universal Book")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[71];
            }
            else if (Nameru == "The Book of Green Nature")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[74];
            }
            else if (Nameru == "The Book of Holiness")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[76];
            }
            else if (Nameru == "The book of power")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[69];
            }
            else if (Nameru == "The book of life")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[67];
            }
            else if (Nameru == "Book of protection")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[68];
            }
            else if (Nameru == "Speed book")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[70];
            }
            else if (Nameru == "The Book of Water Spirits")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[73];
            }
            else if (Nameru == "The Book of Dead Spirits")
            {

                gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.SpriteItemSnar[75];
            }

        }

        else if (idItemUI == 9)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[8];
        }
        else if (idItemUI == 10)
        {
            gameObject.transform.Find("icon").gameObject.GetComponent<Image>().sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().DefaultSpriteIcon[8];
        }
    }
}
