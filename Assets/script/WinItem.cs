using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinItem : MonoBehaviour
{
    public string type;
    public string Name;
    public string name_ru;
    public string rank;
    public Image img;
    private void Update()
    {
        if (type == "Person")
        {
            if (Name == "King")
            {

                img.sprite = GameControll.instance.AvatarPerson[0];

            }
            else if (Name == "The villain with the whip")
            {
                img.sprite = GameControll.instance.AvatarPerson[10];

            }
            else if (Name == "Genos")
            {
                img.sprite = GameControll.instance.AvatarPerson[4];

            }
            else if (Name == "Tatsumaki Tornado")
            {
                img.sprite = GameControll.instance.AvatarPerson[17];

            }
            else if (Name == "Isamu the Cruel Emperor")
            {
                img.sprite = GameControll.instance.AvatarPerson[11];

            }
            else if (Name == "Suiryu")
            {
                img.sprite = GameControll.instance.AvatarPerson[3];

            }
            else if (Name == "Bad Steel Bat")
            {
                img.sprite = GameControll.instance.AvatarPerson[7];

            }
            else if (Name == "The master in a Tshirt")
            {
                img.sprite = GameControll.instance.AvatarPerson[5];

            }
            else if (Name == "Kamikaze Atomic Samurai")
            {
                img.sprite = GameControll.instance.AvatarPerson[12];

            }
            else if (Name == "Asta")
            {
                img.sprite = GameControll.instance.AvatarPerson[18];

            }
            else if (Name == "Noel Silver")
            {
                img.sprite = GameControll.instance.AvatarPerson[19];

            }
            else if (Name == "Yami Sukehiro")
            {
                img.sprite = GameControll.instance.AvatarPerson[20];

            }
            else if (Name == "Yuno")
            {
                img.sprite = GameControll.instance.AvatarPerson[21];

            }
            else if (Name == "William Wanjins")
            {
                img.sprite = GameControll.instance.AvatarPerson[22];

            }
            else if (Name == "Mereoleon The Crimson Lion")
            {
                img.sprite = GameControll.instance.AvatarPerson[23];

            }
            else if (Name == "Fana")
            {
                img.sprite = GameControll.instance.AvatarPerson[24];

            }
            else if (Name == "Finral Rollcase")
            {
                img.sprite = GameControll.instance.AvatarPerson[25];

            }

            else if (Name == "Julius Novochrono")
            {
                img.sprite = GameControll.instance.AvatarPerson[26];

            }
            else if (Name == "Zora Ideare")
            {
                img.sprite = GameControll.instance.AvatarPerson[27];

            }
            else if (Name == "Gomo gomo zek")
            {
                img.sprite = GameControll.instance.AvatarPerson[28];

            }
            else if (Name == "Genrysay Yamamoto")
            {
                img.sprite = GameControll.instance.AvatarPerson[29];

            }
            else if (Name == "Retsu Unohana")
            {
                img.sprite = GameControll.instance.AvatarPerson[30];

            }
            else if (Name == "Syuhey Hisagi")
            {
                img.sprite = GameControll.instance.AvatarPerson[31];

            }
            else if (Name == "Chad")
            {
                img.sprite = GameControll.instance.AvatarPerson[32];

            }
            else if (Name == "Kenpachi Zaraki")
            {
                img.sprite = GameControll.instance.AvatarPerson[33];

            }
            else if (Name == "Djushiro Ikitake")
            {
                img.sprite = GameControll.instance.AvatarPerson[34];

            }
            else if (Name == "Byakuya Kuchiki")
            {
                img.sprite = GameControll.instance.AvatarPerson[35];

            }
            else if (Name == "Yumichka")
            {
                img.sprite = GameControll.instance.AvatarPerson[36];

            }
            else if (Name == "Sandji Komamura")
            {
                img.sprite = GameControll.instance.AvatarPerson[37];

            }
            else if (Name == "Yuriu Isida")
            {
                img.sprite = GameControll.instance.AvatarPerson[38];

            }
            else if (Name == "Rangiku Matsumoto")
            {
                img.sprite = GameControll.instance.AvatarPerson[39];

            }
            else if (Name == "Ikkaku Maderame")
            {
                img.sprite = GameControll.instance.AvatarPerson[40];

            }
            else if (Name == "Gin")
            {
                img.sprite = GameControll.instance.AvatarPerson[41];

            }
            else if (Name == "Hirako")
            {
                img.sprite = GameControll.instance.AvatarPerson[42];

            }
            else if (Name == "Aizen")
            {
                img.sprite = GameControll.instance.AvatarPerson[43];

            }
            else if (Name == "Grimjou")
            {
                img.sprite = GameControll.instance.AvatarPerson[44];

            }
            else if (Name == "Soy-Fon")
            {
                img.sprite = GameControll.instance.AvatarPerson[45];

            }
            else if (Name == "Kurasaki")
            {
                img.sprite = GameControll.instance.AvatarPerson[46];

            }
            else if (Name == "Kento Nanami")
            {
                img.sprite = GameControll.instance.AvatarPerson[47];

            }
            else if (Name == "Kigusaki Nabora")
            {
                img.sprite = GameControll.instance.AvatarPerson[48];

            }
            else if (Name == "Zenin Maki")
            {
                img.sprite = GameControll.instance.AvatarPerson[49];

            }
            else if (Name == "Yuta Okkotsu")
            {
                img.sprite = GameControll.instance.AvatarPerson[50];

            }
            else if (Name == "Todji Fushigura")
            {
                img.sprite = GameControll.instance.AvatarPerson[51];

            }
            else if (Name == "Djogo")
            {
                img.sprite = GameControll.instance.AvatarPerson[52];

            }
            else if (Name == "Suguru Geto")
            {
                img.sprite = GameControll.instance.AvatarPerson[53];

            }
            else if (Name == "Todo Ayo")
            {
                img.sprite = GameControll.instance.AvatarPerson[54];

            }
            else if (Name == "Kusumi Miva")
            {
                img.sprite = GameControll.instance.AvatarPerson[55];

            }
            else if (Name == "Ryomen Sukuna")
            {
                img.sprite = GameControll.instance.AvatarPerson[56];

            }
            else if (Name == "Satoru Godjo")
            {
                img.sprite = GameControll.instance.AvatarPerson[57];

            }
            else if (Name == "Mahito")
            {
                img.sprite = GameControll.instance.AvatarPerson[58];

            }
            else if (Name == "Hanami")
            {
                img.sprite = GameControll.instance.AvatarPerson[59];

            }
            else if (Name == "Itadori Yudji")
            {
                img.sprite = GameControll.instance.AvatarPerson[60];

            }
            else if (Name == "Beng")
            {
                img.sprite = GameControll.instance.AvatarPerson[61];

            }
            else if (Name == "Satoru")
            {
                img.sprite = GameControll.instance.AvatarPerson[62];

            }
            else if (Name == "Sonik")
            {
                img.sprite = GameControll.instance.AvatarPerson[63];

            }
            else if (Name == "May Mask")
            {
                img.sprite = GameControll.instance.AvatarPerson[64];

            }
            else if (Name == "Garo")
            {
                img.sprite = GameControll.instance.AvatarPerson[65];

            }
            else if (Name == "Prujinyashii Us")
            {
                img.sprite = GameControll.instance.AvatarPerson[66];

            }
            else if (Name == "Maskitnaya Jenshina")
            {
                img.sprite = GameControll.instance.AvatarPerson[67];

            }
            else if (Name == "Choso")
            {
                img.sprite = GameControll.instance.AvatarPerson[68];

            }
            else if (Name == "Fushigura Megumia")
            {
                img.sprite = GameControll.instance.AvatarPerson[69];

            }
            else if (Name == "Panda")
            {
                img.sprite = GameControll.instance.AvatarPerson[130];

            }
            else if (Name == "Rengoku")
            {
                img.sprite = GameControll.instance.AvatarPerson[70];

            }
            else if (Name == "Sanemi")
            {
                img.sprite = GameControll.instance.AvatarPerson[71];

            }
            else if (Name == "Tomioka")
            {
                img.sprite = GameControll.instance.AvatarPerson[72];

            }
            else if (Name == "Nezuko")
            {
                img.sprite = GameControll.instance.AvatarPerson[73];

            }
            else if (Name == "Tandjiro")
            {
                img.sprite = GameControll.instance.AvatarPerson[74];

            }
            else if (Name == "Susamaru")
            {
                img.sprite = GameControll.instance.AvatarPerson[75];

            }
            else if (Name == "Zenitsu")
            {
                img.sprite = GameControll.instance.AvatarPerson[76];

            }
            else if (Name == "Mudzan")
            {
                img.sprite = GameControll.instance.AvatarPerson[77];

            }
            else if (Name == "Gyutago")
            {
                img.sprite = GameControll.instance.AvatarPerson[78];

            }
            else if (Name == "Inoske")
            {
                img.sprite = GameControll.instance.AvatarPerson[79];

            }
            else if (Name == "Shinobu Kocho")
            {
                img.sprite = GameControll.instance.AvatarPerson[80];

            }
            else if (Name == "Toketu")
            {
                img.sprite = GameControll.instance.AvatarPerson[81];

            }
            else if (Name == "Gyumey")
            {
                img.sprite = GameControll.instance.AvatarPerson[82];

            }
            else if (Name == "Kokushibo")
            {
                img.sprite = GameControll.instance.AvatarPerson[83];

            }
            else if (Name == "Tengen")
            {
                img.sprite = GameControll.instance.AvatarPerson[84];

            }
            else if (Name == "Kaygaku")
            {
                img.sprite = GameControll.instance.AvatarPerson[85];

            }
            else if (Name == "Reve")
            {
                img.sprite = GameControll.instance.AvatarPerson[86];

            }
            else if (Name == "Gordon")
            {
                img.sprite = GameControll.instance.AvatarPerson[87];

            }
            else if (Name == "Kaiser")
            {
                img.sprite = GameControll.instance.AvatarPerson[88];

            }
            else if (Name == "Zarget Demon")
            {
                img.sprite = GameControll.instance.AvatarPerson[89];

            }
            else if (Name == "Gosh")
            {
                img.sprite = GameControll.instance.AvatarPerson[90];

            }
            else if (Name == "Langris")
            {
                img.sprite = GameControll.instance.AvatarPerson[91];

            }
            else if (Name == "Lack")
            {
                img.sprite = GameControll.instance.AvatarPerson[92];

            }
            else if (Name == "Vanika")
            {
                img.sprite = GameControll.instance.AvatarPerson[93];

            }
            else if (Name == "Doroti")
            {
                img.sprite = GameControll.instance.AvatarPerson[94];

            }
            else if (Name == "Nomu")
            {
                img.sprite = GameControll.instance.AvatarPerson[95];

            }
            else if (Name == "Shoto")
            {
                img.sprite = GameControll.instance.AvatarPerson[96];

            }
            else if (Name == "Tokoyame")
            {
                img.sprite = GameControll.instance.AvatarPerson[97];

            }
            else if (Name == "Tsuyu")
            {
                img.sprite = GameControll.instance.AvatarPerson[98];

            }
            else if (Name == "Dabi")
            {
                img.sprite = GameControll.instance.AvatarPerson[99];

            }
            else if (Name == "Bakugo")
            {
                img.sprite = GameControll.instance.AvatarPerson[100];

            }
            else if (Name == "Uraraka")
            {
                img.sprite = GameControll.instance.AvatarPerson[101];

            }
            else if (Name == "Gran Torino")
            {
                img.sprite = GameControll.instance.AvatarPerson[102];

            }
            else if (Name == "All might")
            {
                img.sprite = GameControll.instance.AvatarPerson[103];

            }
            else if (Name == "Izuki Midoriya")
            {
                img.sprite = GameControll.instance.AvatarPerson[104];

            }
            else if (Name == "Himiko Toga")
            {
                img.sprite = GameControll.instance.AvatarPerson[105];

            }
            else if (Name == "Muskular")
            {
                img.sprite = GameControll.instance.AvatarPerson[106];

            }
            else if (Name == "Kirishima")
            {
                img.sprite = GameControll.instance.AvatarPerson[107];

            }
            else if (Name == "Staratel")
            {
                img.sprite = GameControll.instance.AvatarPerson[108];

            }
            else if (Name == "Shtein")
            {
                img.sprite = GameControll.instance.AvatarPerson[109];

            }
            else if (Name == "Momo Yayorozu")
            {
                img.sprite = GameControll.instance.AvatarPerson[110];

            }
            else if (Name == "Minoru Mineta")
            {
                img.sprite = GameControll.instance.AvatarPerson[111];

            }
            else if (Name == "Mitsuki")
            {
                img.sprite = GameControll.instance.AvatarPerson[112];

            }
            else if (Name == "Kakashi")
            {
                img.sprite = GameControll.instance.AvatarPerson[113];

            }
            else if (Name == "Orochimaru")
            {
                img.sprite = GameControll.instance.AvatarPerson[114];

            }
            else if (Name == "Obito")
            {
                img.sprite = GameControll.instance.AvatarPerson[115];

            }
            else if (Name == "Naruto")
            {
                img.sprite = GameControll.instance.AvatarPerson[116];

            }
            else if (Name == "Jiraya")
            {
                img.sprite = GameControll.instance.AvatarPerson[117];

            }
            else if (Name == "Kavaki")
            {
                img.sprite = GameControll.instance.AvatarPerson[118];

            }
            else if (Name == "Boruto")
            {
                img.sprite = GameControll.instance.AvatarPerson[119];

            }
            else if (Name == "Mifune")
            {
                img.sprite = GameControll.instance.AvatarPerson[120];

            }
            else if (Name == "Sasuke")
            {
                img.sprite = GameControll.instance.AvatarPerson[121];

            }
            else if (Name == "Sarada")
            {
                img.sprite = GameControll.instance.AvatarPerson[122];

            }
            else if (Name == "Madara")
            {
                img.sprite = GameControll.instance.AvatarPerson[123];

            }
            else if (Name == "Kurenay")
            {
                img.sprite = GameControll.instance.AvatarPerson[124];

            }
            else if (Name == "Sakura")
            {
                img.sprite = GameControll.instance.AvatarPerson[125];

            }
            else if (Name == "Gaara")
            {
                img.sprite = GameControll.instance.AvatarPerson[126];

            }
            else if (Name == "Hashirama")
            {
                img.sprite = GameControll.instance.AvatarPerson[127];

            }
            else if (Name == "Tsunade")
            {
                img.sprite = GameControll.instance.AvatarPerson[128];

            }
            else if (Name == "Itachi")
            {
                img.sprite = GameControll.instance.AvatarPerson[129];

            }
        }
        else if (type == "Snar")
        {
            if (name_ru == "Attack Spell Book" || name_ru == "Health Spell Book" || name_ru == "Book of Spells of Protection" || name_ru == "Book of Speed Spells")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[24];
            }
            else if (name_ru == "Attack Spell Book 2" || name_ru == "Health Spell Book 2" || name_ru == "Book of Spells of Protection 2" || name_ru == "Speed Spell Book 2")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[25];
            }
            else if (name_ru == "Assassin balaclava")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[6];
            }
            else if (name_ru == "Steel Helmet")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[7];
            }
            else if (name_ru == "Dragon Emperor Helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[8];
            }
            else if (name_ru == "Avadon Boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[0];

            }
            else if (name_ru == "Steel boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[1];
            }
            else if (name_ru == "Dragon Boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[2];

            }
            else if (name_ru == "Beginner Dagger")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[3];

            }
            else if (name_ru == "Red Snake Fang")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[4];
            }
            else if (name_ru == "Ice Dragon Fang")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[5];

            }
            else if (name_ru == "Shirt")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[9];

            }
            else if (name_ru == "Mantle of the Steel Knight")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[10];
            }
            else if (name_ru == "Dragon scale helmet")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[11];

            }
            else if (name_ru == "Leather gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[12];

            }
            else if (name_ru == "Steel Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[13];
            }
            else if (name_ru == "Dragon Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[14];

            }
            else if (name_ru == "Disciple's Ring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[15];

            }
            else if (name_ru == "Ring of Light")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[16];
            }
            else if (name_ru == "Ring of Eternity")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[17];

            }
            else if (name_ru == "Copper Earrings")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[18];

            }
            else if (name_ru == "Earrings of Light")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[19];
            }
            else if (name_ru == "Eternity Earrings")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[20];

            }
            else if (name_ru == "Disciple Necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[21];

            }
            else if (name_ru == "Necklace of Light")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[22];
            }
            else if (name_ru == "Dragon Eye Necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[23];

            }
            if (name_ru == "The Book of Blessings of the Earth")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[72];
            }
            else if (name_ru == "The Book of Dark Power")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[77];
            }
            else if (name_ru == "Universal Book")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[71];
            }
            else if (name_ru == "The Book of Green Nature")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[74];
            }
            else if (name_ru == "The Book of Holiness")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[76];
            }
            else if (name_ru == "The book of power")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[69];
            }
            else if (name_ru == "The book of life")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[67];
            }
            else if (name_ru == "Book of protection")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[68];
            }
            else if (name_ru == "Speed book")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[70];
            }
            else if (name_ru == "The Book of Water Spirits")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[73];
            }
            else if (name_ru == "The Book of Dead Spirits")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[75];
            }
            else if (name_ru == "Beginner helmet")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[20];
            }
            else if (name_ru == "Dark Crystal helmet")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[21];
            }
            else if (name_ru == "Dinasty helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[24];
            }
            else if (name_ru == "Draconik helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[23];
            }
            else if (name_ru == "Majestik helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[25];
            }
            else if (name_ru == "Tallum helmett")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[22];
            }
            else if (name_ru == "Ice Helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[28];
            }
            else if (name_ru == "Imperial Helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[27];
            }
            else if (name_ru == "Golden Helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[115];
            }
            else if (name_ru == "Demonic Helmet")
            {

                img.sprite = GameControll.instance.SpriteItemSnar[26];
            }
            else if (name_ru == "Beginner boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[0];

            }
            else if (name_ru == "Majestik boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[4];
            }
            else if (name_ru == "Tallum boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[5];

            }
            else if (name_ru == "Demonic Boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[6];

            }
            else if (name_ru == "Golden Shoes")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[7];

            }
            else if (name_ru == "Ice boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[9];

            }
            else if (name_ru == "Imperial Boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[8];

            }
            else if (name_ru == "Dark Crystal boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[1];

            }
            else if (name_ru == "Dinasty boots S")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[3];

            }
            else if (name_ru == "Draconik boots")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[2];

            }
            else if (name_ru == "Demonic Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[49];

            }
            else if (name_ru == "Demonic Two-handed Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[47];
            }
            else if (name_ru == "The Golden Wrecker")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[54];

            }
            else if (name_ru == "Golden Knife")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[56];

            }
            else if (name_ru == "Golden Peak")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[52];

            }
            else if (name_ru == "Golden Two-handed Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[53];

            }
            else if (name_ru == "The Imperial Sword of Justice")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[61];

            }
            else if (name_ru == "Golden Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[55];

            }
            else if (name_ru == "Imperial Two-handed Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[59];

            }
            else if (name_ru == "Imperial Snake Fangs")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[57];

            }
            else if (name_ru == "The Imperial Spellcaster")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[60];

            }
            else if (name_ru == "The Imperial Axe")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[58];

            }
            else if (name_ru == "Ice Knife")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[64];

            }
            else if (name_ru == "Ice Sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[63];

            }
            else if (name_ru == "Ice Caster")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[62];

            }
            else if (name_ru == "Ice Piercer")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[566];

            }
            else if (name_ru == "Ice Staff")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[65];

            }
            else if (name_ru == "The Demonic Wand")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[48];

            }
            else if (name_ru == "Demonic Staff")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[51];

            }
            else if (name_ru == "Demonic Knife")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[50];

            }
            else if (name_ru == "Killer dagger")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[46];

            }
            else if (name_ru == "Bazalt hammer")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[44];

            }
            else if (name_ru == "Bloody orich dagger")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[42];

            }
            else if (name_ru == "Cristal dagger")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[43];

            }
            else if (name_ru == "Dark legion sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[41];

            }
            else if (name_ru == "Beginner wooden sword")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[39];

            }
            else if (name_ru == "Dragon slayer")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[40];

            }
            else if (name_ru == "duals of greatness")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[45];

            }
            else if (name_ru == "Beginner armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[29];

            }
            else if (name_ru == "Imperial Armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[37];
            }
            else if (name_ru == "Dark Crystal armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[34];

            }
            else if (name_ru == "Dinasty armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[30];

            }
            else if (name_ru == "Draconik armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[33];

            }
            else if (name_ru == "Majestik armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[32];

            }
            else if (name_ru == "Tallum armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[31];

            }
            else if (name_ru == "Demonic Armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[35];

            }
            else if (name_ru == "Golden Armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[36];

            }
            else if (name_ru == "Ice Armor")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[38];

            }
            else if (name_ru == "Tallum gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[11];

            }
            else if (name_ru == "Beginner gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[10];
            }
            else if (name_ru == "Demonic Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[16];

            }
            else if (name_ru == "Dark Crystal gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[12];

            }
            else if (name_ru == "Dinasty gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[13];

            }
            else if (name_ru == "Draconik gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[15];

            }
            else if (name_ru == "Majestik gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[14];

            }
            else if (name_ru == "Golden Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[17];

            }
            else if (name_ru == "Imperial Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[18];

            }
            else if (name_ru == "Ice Gloves")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[19];

            }
            else if (name_ru == "Power Core Rings")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[84];

            }
            else if (name_ru == "The Ant Ring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[85];
            }
            else if (name_ru == "Ruby Power Ring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[83];

            }
            else if (name_ru == "Beginner ring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[82];

            }
            else if (name_ru == "Demans Ring of Power")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[93];

            }
            else if (name_ru == "Imperial Control Rings")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[86];

            }
            else if (name_ru == "The Imperial Ring of Crete")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[87];

            }
            else if (name_ru == "The Imperial Ring of Power")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[88];

            }
            else if (name_ru == "Charm Power Ring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[90];

            }
            else if (name_ru == "The Ring of Wisdom Power")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[89];

            }
            else if (name_ru == "The Ring of power of Aspiration")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[91];

            }
            else if (name_ru == "The ring of Deman luck")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[92];

            }
            else if (name_ru == "Magnificent earring of Greatness")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[109];

            }
            else if (name_ru == "The earring of the heart of the ice dragon of rage")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[114];
            }
            else if (name_ru == "Beginner earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[105];

            }
            else if (name_ru == "Lich earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[106];

            }
            else if (name_ru == "Dinasty earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[107];

            }
            else if (name_ru == "Core Earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[108];

            }
            else if (name_ru == "The earring of the heart of the ice dragon of darkness")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[113];

            }
            else if (name_ru == "Ice Dragon Heart Earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[112];

            }
            else if (name_ru == "Magnificent earring of good luck")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[111];

            }
            else if (name_ru == "Gorgeous Charm Earring")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[110];

            }
            else if (name_ru == "Beginner necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[95];

            }
            else if (name_ru == "Lich necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[97];
            }
            else if (name_ru == "Dinasty necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[98];

            }
            else if (name_ru == "Demonic Necklace of Greatness")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[99];

            }
            else if (name_ru == "Dragon Necklace of Wisdom")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[102];

            }
            else if (name_ru == "core necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[96];

            }
            else if (name_ru == "Demonic Necklace of Power")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[100];

            }
            else if (name_ru == "Demonic Necklace of Darkness")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[101];

            }
            else if (name_ru == "Dragon Charm Necklace")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[103];

            }
            else if (name_ru == "Dragon Necklace of Aspiration")
            {
                img.sprite = GameControll.instance.SpriteItemSnar[104];

            }
        }
    }

}
