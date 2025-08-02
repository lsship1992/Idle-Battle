using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    public Image AvatarImg;
    public Image CoinImg;
    public Text NameText;
    public Text PriceText;
    public int Price;
    public string Name;
    public string name_ru;
    public string rank;
    public string Class;
    public int Hp;
    public int Defens;
    public int Attack;
    public int Speed;
    public string Valet;
    public string type;
    public int id;
    public int idItem;
    public Text MaxByuText;
    public int MaxByu;
    public int Byu;
    public List<Sprite> SpriteCoin = new List<Sprite>();


    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => OnClick());

    }
    public void OnClick()
    {
        if (type == "Person")
        {
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Nameru = Name;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().RangItem = rank;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Attack = Attack;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Defens = Defens;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Speed = Speed;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Hp = Hp;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().id = id;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().idItemShop = idItem;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().type = "Person";
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Valet = Valet;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Price = Price;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().MaxByu = MaxByu;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Byu = Byu;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(true);
        }
        else if (type == "Snar")
        {
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Nameru = name_ru;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().NameItem = Name;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().RangItem = rank;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Attack = Attack;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Defens = Defens;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Speed = Speed;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Hp = Hp;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().id = id;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().idItemShop = idItem;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().type = "Snar";
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Valet = Valet;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Price = Price;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().MaxByu = MaxByu;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Byu = Byu;

            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(true);

        }
    }

    private void Update()
    {
        MaxByuText.text = $"{Byu}/{MaxByu}";
        PriceText.text = Price.ToString();
        if (Valet == "serebro")
        {
            CoinImg.sprite = SpriteCoin[0];
        }
        else if (Valet == "almaz")
        {
            CoinImg.sprite = SpriteCoin[1];
        }

        if (type == "Person")
        {
            NameText.text = Name;
            if (Name == "King")
            {

                AvatarImg.sprite = GameControll.instance.AvatarPerson[0];

            }
            else if (Name == "The villain with the whip")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[10];

            }
            else if (Name == "Genos")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[4];

            }
            else if (Name == "Tatsumaki Tornado")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[17];

            }
            else if (Name == "Isamu the Cruel Emperor")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[11];

            }
            else if (Name == "Suiryu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[3];

            }
            else if (Name == "Bad Steel Bat")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[7];

            }
            else if (Name == "The master in a Tshirt")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[5];

            }
            else if (Name == "Kamikaze Atomic Samurai")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[12];

            }
            else if (Name == "Asta")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[18];

            }
            else if (Name == "Noel Silver")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[19];

            }
            else if (Name == "Yami Sukehiro")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[20];

            }
            else if (Name == "Yuno")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[21];

            }
            else if (Name == "William Wanjins")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[22];

            }
            else if (Name == "Mereoleon The Crimson Lion")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[23];

            }
            else if (Name == "Fana")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[24];

            }
            else if (Name == "Finral Rollcase")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[25];

            }

            else if (Name == "Julius Novochrono")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[26];

            }
            else if (Name == "Zora Ideare")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[27];

            }
            else if (Name == "Gomo gomo zek") 
             {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[28];

            }
            else if (Name == "Genrysay Yamamoto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[29];

            }
            else if (Name == "Retsu Unohana")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[30];

            }
            else if (Name == "Syuhey Hisagi")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[31];

            }
            else if (Name == "Chad")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[32];

            }
            else if (Name == "Kenpachi Zaraki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[33];

            }
            else if (Name == "Djushiro Ikitake")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[34];

            }
            else if (Name == "Byakuya Kuchiki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[35];

            }
            else if (Name == "Yumichka")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[36];

            }
            else if (Name == "Sandji Komamura")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[37];

            }
            else if (Name == "Yuriu Isida")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[38];

            }
            else if (Name == "Rangiku Matsumoto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[39];

            }
            else if (Name == "Ikkaku Maderame")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[40];

            }
            else if (Name == "Gin")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[41];

            }
            else if (Name == "Hirako")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[42];

            }
            else if (Name == "Aizen")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[43];

            }
            else if (Name == "Grimjou")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[44];

            }
            else if (Name == "Soy-Fon")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[45];

            }
            else if (Name == "Kurasaki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[46];

            }
            else if (Name == "Kento Nanami")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[47];

            }
            else if (Name == "Kigusaki Nabora")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[48];

            }
            else if (Name == "Zenin Maki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[49];

            }
            else if (Name == "Yuta Okkotsu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[50];

            }
            else if (Name == "Todji Fushigura")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[51];

            }
            else if (Name == "Djogo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[52];

            }
            else if (Name == "Suguru Geto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[53];

            }
            else if (Name == "Todo Ayo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[54];

            }
            else if (Name == "Kusumi Miva")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[55];

            }
            else if (Name == "Ryomen Sukuna")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[56];

            }
            else if (Name == "Satoru Godjo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[57];

            }
            else if (Name == "Mahito")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[58];

            }
            else if (Name == "Hanami")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[59];

            }
            else if (Name == "Itadori Yudji")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[60];

            }
            else if (Name == "Beng")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[61];

            }
            else if (Name == "Satoru")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[62];

            }
            else if (Name == "Sonik")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[63];

            }
            else if (Name == "May Mask")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[64];

            }
            else if (Name == "Garo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[65];

            }
            else if (Name == "Prujinyashii Us")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[66];

            }
            else if (Name == "Maskitnaya Jenshina")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[67];

            }
            else if (Name == "Choso")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[68];

            }
            else if (Name == "Fushigura Megumia")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[69];

            }
            else if (Name == "Panda")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[130];

            }
            else if (Name == "Rengoku")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[70];

            }
            else if (Name == "Sanemi")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[71];

            }
            else if (Name == "Tomioka")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[72];

            }
            else if (Name == "Nezuko")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[73];

            }
            else if (Name == "Tandjiro")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[74];

            }
            else if (Name == "Susamaru")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[75];

            }
            else if (Name == "Zenitsu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[76];

            }
            else if (Name == "Mudzan")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[77];

            }
            else if (Name == "Gyutago")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[78];

            }
            else if (Name == "Inoske")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[79];

            }
            else if (Name == "Shinobu Kocho")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[80];

            }
            else if (Name == "Toketu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[81];

            }
            else if (Name == "Gyumey")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[82];

            }
            else if (Name == "Kokushibo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[83];

            }
            else if (Name == "Tengen")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[84];

            }
            else if (Name == "Kaygaku")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[85];

            }
            else if (Name == "Reve")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[86];

            }
            else if (Name == "Gordon")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[87];

            }
            else if (Name == "Kaiser")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[88];

            }
            else if (Name == "Zarget Demon")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[89];

            }
            else if (Name == "Gosh")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[90];

            }
            else if (Name == "Langris")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[91];

            }
            else if (Name == "Lack")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[92];

            }
            else if (Name == "Vanika")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[93];

            }
            else if (Name == "Doroti")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[94];

            }
            else if (Name == "Nomu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[95];

            }
            else if (Name == "Shoto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[96];

            }
            else if (Name == "Tokoyame")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[97];

            }
            else if (Name == "Tsuyu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[98];

            }
            else if (Name == "Dabi")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[99];

            }
            else if (Name == "Bakugo")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[100];

            }
            else if (Name == "Uraraka")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[101];

            }
            else if (Name == "Gran Torino")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[102];

            }
            else if (Name == "All might")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[103];

            }
            else if (Name == "Izuki Midoriya")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[104];

            }
            else if (Name == "Himiko Toga")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[105];

            }
            else if (Name == "Muskular")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[106];

            }
            else if (Name == "Kirishima")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[107];

            }
            else if (Name == "Staratel")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[108];

            }
            else if (Name == "Shtein")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[109];

            }
            else if (Name == "Momo Yayorozu")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[110];

            }
            else if (Name == "Minoru Mineta")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[111];

            }
            else if (Name == "Mitsuki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[112];

            }
            else if (Name == "Kakashi")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[113];

            }
            else if (Name == "Orochimaru")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[114];

            }
            else if (Name == "Obito")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[115];

            }
            else if (Name == "Naruto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[116];

            }
            else if (Name == "Jiraya")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[117];

            }
            else if (Name == "Kavaki")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[118];

            }
            else if (Name == "Boruto")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[119];

            }
            else if (Name == "Mifune")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[120];

            }
            else if (Name == "Sasuke")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[121];

            }
            else if (Name == "Sarada")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[122];

            }
            else if (Name == "Madara")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[123];

            }
            else if (Name == "Kurenay")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[124];

            }
            else if (Name == "Sakura")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[125];

            }
            else if (Name == "Gaara")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[126];

            }
            else if (Name == "Hashirama")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[127];

            }
            else if (Name == "Tsunade")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[128];

            }
            else if (Name == "Itachi")
            {
                AvatarImg.sprite = GameControll.instance.AvatarPerson[129];

            }
        }
        else if (type == "Snar")
        {
            NameText.text = name_ru;
            if (Name == "Book")
            {
                if (name_ru == "The Book of Blessings of the Earth")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[72];
                }
                else if (name_ru == "The Book of Dark Power")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[77];
                }
                else if (name_ru == "Universal Book")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[71];
                }
                else if (name_ru == "The Book of Green Nature")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[74];
                }
                else if (name_ru == "The Book of Holiness")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[76];
                }
                else if (name_ru == "The book of power")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[69];
                }
                else if (name_ru == "The book of life")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[67];
                }
                else if (name_ru == "Book of protection")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[68];
                }
                else if (name_ru == "Speed book")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[70];
                }
                else if (name_ru == "The Book of Water Spirits")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[73];
                }
                else if (name_ru == "The Book of Dead Spirits")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[75];
                }

            }
            if (Name == "Helmet")
            {
                if (name_ru == "Beginner helmet")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[20];
                }
                else if (name_ru == "Dark Crystal helmet")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[21];
                }
                else if (name_ru == "Dinasty helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[24];
                }
                else if (name_ru == "Draconik helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[23];
                }
                else if (name_ru == "Majestik helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[25];
                }
                else if (name_ru == "Tallum helmett")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[22];
                }
                else if (name_ru == "Ice Helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[28];
                }
                else if (name_ru == "Imperial Helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[27];
                }
                else if (name_ru == "Golden Helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[115];
                }
                else if (name_ru == "Demonic Helmet")
                {

                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[26];
                }

            }
            if (Name == "Bots")
            {
                if (name_ru == "Beginner boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[0];

                }
                else if (name_ru == "Majestik boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[4];
                }
                else if (name_ru == "Tallum boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[5];

                }
                else if (name_ru == "Demonic Boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[6];

                }
                else if (name_ru == "Golden Shoes")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[7];

                }
                else if (name_ru == "Ice boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[9];

                }
                else if (name_ru == "Imperial Boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[8];

                }
                else if (name_ru == "Dark Crystal boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[1];

                }
                else if (name_ru == "Dinasty boots S")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[3];

                }
                else if (name_ru == "Draconik boots")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[2];

                }

            }
            if (Name == "Weapon")
            {
                if (name_ru == "Demonic Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[49];

                }
                else if (name_ru == "Demonic Two-handed Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[47];
                }
                else if (name_ru == "The Golden Wrecker")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[54];

                }
                else if (name_ru == "Golden Knife")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[56];

                }
                else if (name_ru == "Golden Peak")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[52];

                }
                else if (name_ru == "Golden Two-handed Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[53];

                }
                else if (name_ru == "The Imperial Sword of Justice")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[61];

                }
                else if (name_ru == "Golden Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[55];

                }
                else if (name_ru == "Imperial Two-handed Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[59];

                }
                else if (name_ru == "Imperial Snake Fangs")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[57];

                }
                else if (name_ru == "The Imperial Spellcaster")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[60];

                }
                else if (name_ru == "The Imperial Axe")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[58];

                }
                else if (name_ru == "Ice Knife")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[64];

                }
                else if (name_ru == "Ice Sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[63];

                }
                else if (name_ru == "Ice Caster")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[62];

                }
                else if (name_ru == "Ice Piercer")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[566];

                }
                else if (name_ru == "Ice Staff")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[65];

                }
                else if (name_ru == "The Demonic Wand")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[48];

                }
                else if (name_ru == "Demonic Staff")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[51];

                }
                else if (name_ru == "Demonic Knife")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[50];

                }
                else if (name_ru == "Killer dagger")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[46];

                }
                else if (name_ru == "Bazalt hammer")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[44];

                }
                else if (name_ru == "Bloody orich dagger")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[42];

                }
                else if (name_ru == "Cristal dagger")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[43];

                }
                else if (name_ru == "Dark legion sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[41];

                }
                else if (name_ru == "Beginner wooden sword")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[39];

                }
                else if (name_ru == "Dragon slayer")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[40];

                }
                else if (name_ru == "duals of greatness")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[45];

                }

            }
            if (Name == "Armor")
            {
                if (name_ru == "Beginner armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[29];

                }
                else if (name_ru == "Imperial Armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[37];
                }
                else if (name_ru == "Dark Crystal armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[34];

                }
                else if (name_ru == "Dinasty armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[30];

                }
                else if (name_ru == "Draconik armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[33];

                }
                else if (name_ru == "Majestik armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[32];

                }
                else if (name_ru == "Tallum armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[31];

                }
                else if (name_ru == "Demonic Armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[35];

                }
                else if (name_ru == "Golden Armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[36];

                }
                else if (name_ru == "Ice Armor")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[38];

                }
            }
            if (Name == "Gloves")
            {
                if (name_ru == "Tallum gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[11];

                }
                else if (name_ru == "Beginner gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[10];
                }
                else if (name_ru == "Demonic Gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[16];

                }
                else if (name_ru == "Dark Crystal gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[12];

                }
                else if (name_ru == "Dinasty gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[13];

                }
                else if (name_ru == "Draconik gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[15];

                }
                else if (name_ru == "Majestik gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[14];

                }
                else if (name_ru == "Golden Gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[17];

                }
                else if (name_ru == "Imperial Gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[18];

                }
                else if (name_ru == "Ice Gloves")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[19];

                }
            }
            if (Name == "Rings")
            {
                if (name_ru == "Power Core Rings")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[84];

                }
                else if (name_ru == "The Ant Ring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[85];
                }
                else if (name_ru == "Ruby Power Ring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[83];

                }
                else if (name_ru == "Beginner ring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[82];

                }
                else if (name_ru == "Demans Ring of Power")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[93];

                }
                else if (name_ru == "Imperial Control Rings")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[86];

                }
                else if (name_ru == "The Imperial Ring of Crete")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[87];

                }
                else if (name_ru == "The Imperial Ring of Power")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[88];

                }
                else if (name_ru == "Charm Power Ring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[90];

                }
                else if (name_ru == "The Ring of Wisdom Power")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[89];

                }
                else if (name_ru == "The Ring of power of Aspiration")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[91];

                }
                else if (name_ru == "The ring of Deman luck")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[92];

                }
            }
            if (Name == "Earrings")
            {
                if (name_ru == "Magnificent earring of Greatness")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[109];

                }
                else if (name_ru == "The earring of the heart of the ice dragon of rage")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[114];
                }
                else if (name_ru == "Beginner earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[105];

                }
                else if (name_ru == "Lich earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[106];

                }
                else if (name_ru == "Dinasty earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[107];

                }
                else if (name_ru == "Core Earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[108];

                }
                else if (name_ru == "The earring of the heart of the ice dragon of darkness")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[113];

                }
                else if (name_ru == "Ice Dragon Heart Earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[112];

                }
                else if (name_ru == "Magnificent earring of good luck")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[111];

                }
                else if (name_ru == "Gorgeous Charm Earring")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[110];

                }
            }
            if (Name == "Necklace")
            {
                if (name_ru == "Beginner necklace")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[95];

                }
                else if (name_ru == "Lich necklace")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[97];
                }
                else if (name_ru == "Dinasty necklace")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[98];

                }
                else if (name_ru == "Demonic Necklace of Greatness")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[99];

                }
                else if (name_ru == "Dragon Necklace of Wisdom")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[102];

                }
                else if (name_ru == "core necklace")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[96];

                }
                else if (name_ru == "Demonic Necklace of Power")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[100];

                }
                else if (name_ru == "Demonic Necklace of Darkness")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[101];

                }
                else if (name_ru == "Dragon Charm Necklace")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[103];

                }
                else if (name_ru == "Dragon Necklace of Aspiration")
                {
                    AvatarImg.sprite = GameControll.instance.SpriteItemSnar[104];

                }
            }

        }
    }
}
