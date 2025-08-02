using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class evalutionPanelScript : MonoBehaviour
{
    public List<Sprite> spriteUpdateEvo = new List<Sprite>();
    public Image isEvol;
    public Image inEvol;
    public Text levelEvolText;
    public int level;
    public int EvoLevel;
    public GameObject Person1;
    public GameObject Person2;
    public GameObject material;
    public int Person1Col;
    public int Person2Col;
    public int materialCol;
    public GameObject HpPlus;
    public GameObject AttackPlus;
    public GameObject DefensPlus;
    public GameObject SpeedPlus;
    public int Hp;
    public int Attack;
    public int Defens;
    public int Speed;
    public Text HpText;
    public Text AttackText;
    public Text DefensText;
    public Text SpeedText;
    public string Rang;
    public GameObject UsePersonPanel;
    public int ViborPerson;
    public List<int> Person1Id = new List<int>();
    public List<int> Person2Id = new List<int>();
    public Text Person1Text;
    public Text Person2Text;
    public Text materialText;
    public Image ImagePerson1;
    public int Material;
    public int IdMaterial;
    private void Awake()
    {
        Person1.GetComponent<Button>().onClick.AddListener(() => Person1Void());
        Person2.GetComponent<Button>().onClick.AddListener(() => Person2Void());
    }
    public void evalutionBtn()
    {
        if (Person1Id.Count == Person1Col && Person2Id.Count == Person2Col && Material >= materialCol)
        {
            Material -= materialCol;
            ClientSend.MaterialMinus(IdMaterial, materialCol, "-");
            ClientSend.EvalutionSend();
            ClientSend.InventoryMaterialSearchUser();

        }
    }
    public void Person1Void()
    {
        ViborPerson = 1;
        while (GameControll.instance.PersonsUseFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.PersonsUseFather.transform.GetChild(0).gameObject);
        }
        UsePersonPanel.SetActive(true);
        ClientSend.PersonSearchUser();
    }
    public void Person2Void()
    {
        ViborPerson = 2;
        while (GameControll.instance.PersonsUseFather.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.PersonsUseFather.transform.GetChild(0).gameObject);
        }
        UsePersonPanel.SetActive(true);
        ClientSend.PersonSearchUser();
    }
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "King")
        {

            ImagePerson1.sprite = GameControll.instance.AvatarPerson[0];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "The villain with the whip")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[10];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Genos")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[4];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tatsumaki Tornado")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[17];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Isamu the Cruel Emperor")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[11];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Suiryu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[3];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Bad Steel Bat")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[7];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "The master in a Tshirt")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[5];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kamikaze Atomic Samurai")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[12];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Asta")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[18];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Noel Silver")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[19];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Yami Sukehiro")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[20];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Yuno")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[21];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "William Wanjins")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[22];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Mereoleon The Crimson Lion")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[23];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Fana")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[24];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Finral Rollcase")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[25];

        }

        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Julius Novochrono")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[26];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Zora Ideare")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[27];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gomo gomo zek")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[28];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Genrysay Yamamoto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[29];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Retsu Unohana")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[30];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Syuhey Hisagi")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[31];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Chad")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[32];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kenpachi Zaraki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[33];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Djushiro Ikitake")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[34];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Byakuya Kuchiki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[35];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Yumichka")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[36];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sandji Komamura")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[37];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Yuriu Isida")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[38];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Rangiku Matsumoto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[39];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Ikkaku Maderame")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[40];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gin")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[41];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Hirako")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[42];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Aizen")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[43];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Grimjou")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[44];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Soy-Fon")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[45];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kurasaki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[46];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kento Nanami")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[47];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kigusaki Nabora")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[48];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Zenin Maki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[49];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Yuta Okkotsu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[50];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Todji Fushigura")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[51];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Djogo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[52];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Suguru Geto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[53];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Todo Ayo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[54];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kusumi Miva")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[55];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Ryomen Sukuna")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[56];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Satoru Godjo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[57];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Mahito")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[58];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Hanami")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[59];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Itadori Yudji")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[60];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Beng")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[61];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Satoru")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[62];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sonik")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[63];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "May Mask")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[64];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Garo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[65];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Prujinyashii Us")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[66];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Maskitnaya Jenshina")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[67];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Choso")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[68];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Fushigura Megumia")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[69];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Panda")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[130];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Rengoku")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[70];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sanemi")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[71];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tomioka")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[72];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Nezuko")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[73];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tandjiro")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[74];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Susamaru")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[75];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Zenitsu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[76];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Mudzan")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[77];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gyutago")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[78];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Inoske")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[79];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Shinobu Kocho")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[80];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Toketu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[81];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gyumey")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[82];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kokushibo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[83];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tengen")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[84];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kaygaku")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[85];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Reve")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[86];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gordon")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[87];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kaiser")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[88];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Zarget Demon")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[89];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gosh")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[90];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Langris")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[91];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Lack")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[92];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Vanika")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[93];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Doroti")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[94];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Nomu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[95];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Shoto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[96];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tokoyame")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[97];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tsuyu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[98];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Dabi")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[99];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Bakugo")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[100];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Uraraka")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[101];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gran Torino")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[102];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "All might")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[103];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Izuki Midoriya")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[104];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Himiko Toga")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[105];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Muskular")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[106];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kirishima")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[107];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Staratel")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[108];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Shtein")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[109];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Momo Yayorozu")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[110];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Minoru Mineta")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[111];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Mitsuki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[112];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kakashi")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[113];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Orochimaru")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[114];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Obito")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[115];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Naruto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[116];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Jiraya")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[117];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kavaki")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[118];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Boruto")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[119];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Mifune")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[120];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sasuke")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[121];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sarada")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[122];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Madara")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[123];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Kurenay")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[124];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Sakura")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[125];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Gaara")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[126];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Hashirama")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[127];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Tsunade")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[128];

        }
        else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().name == "Itachi")
        {
            ImagePerson1.sprite = GameControll.instance.AvatarPerson[129];

        }

        Person1Text.text = $"{Person1Id.Count}/{Person1Col}";
        Person2Text.text = $"{Person2Id.Count}/{Person2Col}";
        materialText.text = $"{Material}/{materialCol}";
        HpText.text = Hp.ToString();
        AttackText.text = Attack.ToString();
        DefensText.text = Defens.ToString();
        SpeedText.text = Speed.ToString();
        if (Rang == "A")
        {
            if (EvoLevel == 0)
            {
                levelEvolText.text = "0 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 1;
                Person2Col = 4;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[0];
                inEvol.sprite = spriteUpdateEvo[1];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.SetActive(false);
                SpeedPlus.SetActive(false);
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
            }
            else if (EvoLevel == 1)
            {
                levelEvolText.text = "1 Ёво";
                Person1.SetActive(false);
                Person2.SetActive(true);
                material.SetActive(false);
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 0;
                Person2Col = 6;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[1];
                inEvol.sprite = spriteUpdateEvo[2];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.SetActive(false);
                SpeedPlus.SetActive(false);
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
            }
            else if (EvoLevel == 2)
            {
                levelEvolText.text = "2 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 1;
                Person2Col = 4;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[2];
                inEvol.sprite = spriteUpdateEvo[3];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 3)
            {
                levelEvolText.text = "3 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[2];
                Person1Col = 2;
                Person2Col = 1;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[3];
                inEvol.sprite = spriteUpdateEvo[4];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 4)
            {
                levelEvolText.text = "4 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[3];
                Person1Col = 1;
                Person2Col = 1;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[4];
                inEvol.sprite = spriteUpdateEvo[5];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
        }
        else
        {
            if (EvoLevel == 0)
            {
                levelEvolText.text = "0 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 1;
                Person2Col = 4;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[0];
                inEvol.sprite = spriteUpdateEvo[1];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.SetActive(false);
                SpeedPlus.SetActive(false);
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
            }
            else if (EvoLevel == 1)
            {
                levelEvolText.text = "1 Ёво";
                Person1.SetActive(false);
                Person2.SetActive(true);
                material.SetActive(false);
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 0;
                Person2Col = 6;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[1];
                inEvol.sprite = spriteUpdateEvo[2];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.SetActive(false);
                SpeedPlus.SetActive(false);
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
            }
            else if (EvoLevel == 2)
            {
                levelEvolText.text = "2 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person1Col = 1;
                Person2Col = 4;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[2];
                inEvol.sprite = spriteUpdateEvo[3];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 3)
            {
                levelEvolText.text = "3 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[2];
                Person1Col = 2;
                Person2Col = 1;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[3];
                inEvol.sprite = spriteUpdateEvo[4];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 4)
            {
                levelEvolText.text = "4 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[3];
                Person1Col = 1;
                Person2Col = 1;
                materialCol = 0;
                isEvol.sprite = spriteUpdateEvo[4];
                inEvol.sprite = spriteUpdateEvo[5];
                HpPlus.GetComponent<Text>().text = "+ 50%";
                AttackPlus.GetComponent<Text>().text = "+ 40%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 5)
            {
                levelEvolText.text = "5 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(true);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[3];
                Person1Col = 2;
                Person2Col = 1;
                materialCol = 1;
                isEvol.sprite = spriteUpdateEvo[5];
                inEvol.sprite = spriteUpdateEvo[6];
                HpPlus.GetComponent<Text>().text = "+ 30%";
                AttackPlus.GetComponent<Text>().text = "+ 20%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 6)
            {
                levelEvolText.text = "6 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(true);
                Person1Col = 2;
                Person2Col = 1;
                materialCol = 4;
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[4];
                isEvol.sprite = spriteUpdateEvo[6];
                inEvol.sprite = spriteUpdateEvo[7];
                HpPlus.GetComponent<Text>().text = "+ 30%";
                AttackPlus.GetComponent<Text>().text = "+ 20%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 7)
            {
                levelEvolText.text = "7 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(true);
                Person1Col = 2;
                Person2Col = 2;
                materialCol = 10;
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[4];
                isEvol.sprite = spriteUpdateEvo[7];
                inEvol.sprite = spriteUpdateEvo[8];
                HpPlus.GetComponent<Text>().text = "+ 30%";
                AttackPlus.GetComponent<Text>().text = "+ 20%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 8)
            {
                levelEvolText.text = "8 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(true);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[2];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[4];
                Person1Col = 1;
                Person2Col = 3;
                materialCol = 10;
                isEvol.sprite = spriteUpdateEvo[8];
                inEvol.sprite = spriteUpdateEvo[9];
                HpPlus.GetComponent<Text>().text = "+ 30%";
                AttackPlus.GetComponent<Text>().text = "+ 20%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            else if (EvoLevel == 9)
            {
                levelEvolText.text = "9 Ёво";
                Person1.SetActive(true);
                Person2.SetActive(true);
                material.SetActive(false);
                Person1.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[3];
                Person2.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[4];
                Person1Col = 1;
                Person2Col = 4;
                materialCol = 10;
                isEvol.sprite = spriteUpdateEvo[9];
                inEvol.sprite = spriteUpdateEvo[10];
                HpPlus.GetComponent<Text>().text = "+ 30%";
                AttackPlus.GetComponent<Text>().text = "+ 20%";
                DefensPlus.GetComponent<Text>().text = "+ 150";
                SpeedPlus.GetComponent<Text>().text = "+ 50";
                HpPlus.SetActive(true);
                AttackPlus.SetActive(true);
                DefensPlus.SetActive(true);
                SpeedPlus.SetActive(true);
            }
            
        }
        
    }
}
