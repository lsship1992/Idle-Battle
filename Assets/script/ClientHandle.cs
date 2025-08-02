using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEngine.UI;
using UnityEngine.XR;
using Unity.Mathematics;
public class ClientHandle : MonoBehaviour
{
    readonly static System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);
    readonly static System.Text.Encoding UTF8 = Encoding.UTF8;
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        //Debug.Log(_msg);
        if (SceneManager.GetActiveScene().name == "Game")
        {
            ClientGame.instance.myId = _myId;

        }
        else
        {
            Client.instance.myId = _myId;

        }
        
        ClientSend.WelcomeReceived();
    }
    public static void RegisterRecived(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        menu.instance.RegisterAll = _msg;
        if (menu.instance.RegisterAll == false)
        {
            
            menu.instance.UsernameField.interactable = false;
            menu.instance.PassswordField.interactable = false;
            menu.instance.ButtonReg.interactable = false;
            Client.instance.Disconnect();
            menu.instance.LoadSceneAsync("Game");


        }
        else
        {
            menu.instance.LoginNo.SetActive(true);
            menu.instance.Invoke("RegisterNo", 2);
        }
        
        

        
    }

    public static void EndBattleKvestKlan(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (_msg)
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().newRecord.GetComponent<Text>().text = $"Новый рекорд: {GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().DamageAll}";
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().newRecord.SetActive(true);
        }
        else
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().newRecord.SetActive(false);

        }



    }

    public static void LoginReceived(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        
        if (_msg == true)
        {
            
            menu.instance.MailFieldLogin.interactable = false;
            menu.instance.PasswordlFieldLogin.interactable = false;
            menu.instance.ButtonLogin.interactable = false;
            Client.instance.Disconnect();
            menu.instance.LoadSceneAsync("Game");
        }
        else
        {
            menu.instance.NoAuth.SetActive(true);
            menu.instance.Invoke("RegisterNo", 2);
        }




    }

    public static void PvpWinUserResiver(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _score = _packet.ReadInt();
        int _myId = _packet.ReadInt();

        if (_msg == true)
        {
            GameObject ButtonSearch = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().WinNagrandaPrefab);
            ButtonSearch.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().WinNagrandaFather.transform, false);
            ButtonSearch.GetComponent<NagradaWinBossKvest>().type = "UserSerebro";
            ButtonSearch.GetComponent<NagradaWinBossKvest>().Count = 50;
            ButtonSearch.GetComponent<NagradaWinBossKvest>().Name = "Золото";

            GameObject ButtonSearch1 = Instantiate(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().WinNagrandaPrefab);
            ButtonSearch1.transform.SetParent(GameControll.instance.PvePanel.GetComponent<PvePanelScript>().WinNagrandaFather.transform, false);
            ButtonSearch1.GetComponent<NagradaWinBossKvest>().type = "score";
            ButtonSearch1.GetComponent<NagradaWinBossKvest>().Count = _score;
            ButtonSearch1.GetComponent<NagradaWinBossKvest>().Name = "Рейтинг";


            Debug.Log("Награда");
            
        }
        else
        {
            
        }




    }
    public static void PvpStartResiver(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();

        if (_msg == true)
        {
            
            Debug.Log("Вычет");

        }
        else
        {

        }




    }
    public static void ListUserKlan(Packet _packet)
    {
        List<String> _list = new List<String>();
        string ownerMail = _packet.ReadString();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            string avStr = server_info[4];
            
           
            if (ownerMail == PlayerPrefs.GetString("mail"))
            {

                GameControll.AddListUserKlan(server_info[0], true, server_info[1], avStr);
            }
            else
            {
                GameControll.AddListUserKlan(server_info[0], false, server_info[1], avStr);
            }
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);




    }
    public static void ServerSearchReceiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            
            menu.AddServerSearch(i, server_info[0], server_info[1]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();
        
        
        int _myId = _packet.ReadInt();
        
        //Debug.Log(b);




    }
    public static void GlavReitingKvestKlanUser(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().mesto = "Нет данных";
        GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().Damage = "Нет данных";
        GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().username = "Нет данных";

        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            int mest = i;
            string avStr = server_info[5];
            byte[] ava = Convert.FromBase64String(avStr);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(ava);
            if (!string.IsNullOrEmpty(avStr))
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().AvatarImage.gameObject.SetActive(true);
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().AvatarImage.texture = texture;
            }
            else
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().AvatarImage.gameObject.SetActive(false);

            }

            if (Convert.ToString(server_info[0]) == PlayerPrefs.GetString("mail") && Convert.ToString(server_info[1]) == PlayerPrefs.GetString("GameServerIp") && Convert.ToString(server_info[2]) == GameControll.instance.KlanUser.GetComponent<KlanUser>().NameKlan)
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().mesto = $"{mest + 1}";
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().Damage = server_info[3];
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().username = server_info[4];
            }
            else
            {
                
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().mesto = "Нет данных";
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().Damage = "Нет данных";
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingUser.GetComponent<ReitingUserKvestKlan>().username = "Нет данных";
            }
            GameObject ButtonSearch = Instantiate(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().ReitingPrefab);
            ButtonSearch.transform.SetParent(GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().FatherReiting.transform, false);
            if (!string.IsNullOrEmpty(avStr))
            {
                ButtonSearch.GetComponent<ReitingUserKvestKlan>().AvatarImage.gameObject.SetActive(true);
                ButtonSearch.GetComponent<ReitingUserKvestKlan>().AvatarImage.texture = texture;
            }
            else
            {
                ButtonSearch.GetComponent<ReitingUserKvestKlan>().AvatarImage.gameObject.SetActive(false);

            }
            ButtonSearch.GetComponent<ReitingUserKvestKlan>().username = server_info[4];
            ButtonSearch.GetComponent<ReitingUserKvestKlan>().Damage = server_info[3];
            ButtonSearch.GetComponent<ReitingUserKvestKlan>().mesto = $"{mest + 1}";
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();


    }
    public static void SearchGildiaResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');

            GameControll.SearchSpisokGildia(server_info[0], server_info[3],Convert.ToInt32(server_info[1]), Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[5]));
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void WinRewerdKvestKlanREsiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddNagradaKvestKlan(server_info[2],Convert.ToInt32(server_info[3]), server_info[1]);
            //Логика Добавления наград на экран
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void ItemShopPerson(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddShopItemPerson(server_info[0], server_info[1], server_info[2], server_info[3], Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[9]), Convert.ToInt32(server_info[10]), Convert.ToInt32(server_info[11]), Convert.ToInt32(server_info[12]));
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void ItemShopPredmet(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddShopItemPredmet(server_info[0], server_info[1], Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[3]), Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), server_info[7]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void SearchKlanShop(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddShopItemPredmet(server_info[0], server_info[1], Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[3]), Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), server_info[7]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }


    public static void ItemShopSnar(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddShopItemSnar(server_info[0], server_info[1], server_info[2], server_info[3], Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[9]), Convert.ToInt32(server_info[10]), Convert.ToInt32(server_info[11]), Convert.ToInt32(server_info[12]));
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void WinBossKvestResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddNagradaBossWin(server_info[3], Convert.ToInt32(server_info[4]), server_info[2]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void AddPersonUserPveResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            
            string[] server_info = _msg.Split(',');
            GameControll.AddPersonBattle(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]), Convert.ToInt32(server_info[30]), server_info[9], server_info[10], server_info[11], server_info[12], server_info[13]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void AddBossKvestKlanResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();

            string[] server_info = _msg.Split(',');
            Debug.Log("Залупа" + server_info[24]);
            GameControll.AddPersonBossKLan(i, server_info[0],server_info[25], server_info[1],server_info[13], server_info[2],Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[3]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[14]), Convert.ToInt32(server_info[15]), Convert.ToInt32(server_info[16]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), server_info[7], server_info[8], server_info[9], server_info[10], server_info[11]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void AddPersonUserEnemyPvPResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            Debug.Log(_msg);
            string[] server_info = _msg.Split(',');
            GameControll.AddPersonEnemyUserBattle(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]), Convert.ToInt32(server_info[30]), server_info[9], server_info[10], server_info[11], server_info[12], server_info[13]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void AddSkillPersonPanel(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddSkillPersonPanel(server_info[0], server_info[1], server_info[2], server_info[3], server_info[4]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void AddSkillPersonPanelStr(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        string skillName = _packet.ReadString();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddSkillPersonPanelStrF(server_info[0], server_info[1],skillName);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }


    public static void SearchSkillPersonResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        string type = _packet.ReadString();
        int IdSlot = _packet.ReadInt();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            
            string _msg = _packet.ReadString();
            if (GameControll.instance.PvePanel.activeSelf == true)
            {
                if (type == "skill1")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
            {
                if (type == "skill1")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            else
            {
                if (type == "skill1")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            string[] server_info = _msg.Split(',');
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void SearchSkillPersonEnemyResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        string type = _packet.ReadString();
        int IdSlot = _packet.ReadInt();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {

            string _msg = _packet.ReadString();
            if (GameControll.instance.PvePanel.activeSelf == true)
            {
                if (type == "skill1")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
            {
                if (type == "skill1")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            else
            {
                if (type == "skill1")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver = _msg;

                }
                else if (type == "skill2")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver = _msg;

                }
                else if (type == "skill3")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver = _msg;

                }
                else if (type == "skill4Passiv")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill4PasivResiver = _msg;
                }
                else if (type == "skill5Passiv")
                {
                    GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill5PasivResiver = _msg;
                }
            }
            
            string[] server_info = _msg.Split(',');
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void AddPersonEnemyPveResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddPersonEmenyBattle(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]), server_info[9], server_info[10], server_info[11], server_info[12], server_info[13]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void InfoBattlePveResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int Level = _packet.ReadInt();
        GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Level = Level;
        GameControll.instance.BattlePveInfoLevel.Clear();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            GameControll.instance.BattlePveInfoLevel.Add(_msg);
            string[] server_info = _msg.Split(',');
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().MaxRaund = Convert.ToInt32(server_info[0]);
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void SearchItemPersonBattleResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int IdSlot = _packet.ReadInt();
        string typePerson = _packet.ReadString();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.SearchPersonItemBattle(IdSlot, Convert.ToInt32(server_info[3]), Convert.ToInt32(server_info[0]), Convert.ToInt32(server_info[1]), Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[4]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]));
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();
        if (GameControll.instance.PvePanel.activeSelf == true)
        {
            if (typePerson == "UserPerson")
            {
                if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject != null)
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateLevelDef();

                }
            }
            else if (typePerson == "Enemy")
            {
                if (GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject != null)
                {
                    GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateLevelDef();

                }
            }
            
        }
        else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
        {
            if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject != null)
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateLevelDef();

            }
        }
        else
        {
            if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject != null)
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonSpavn[IdSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateLevelDef();

            }
        }
        
        int _myId = _packet.ReadInt();
        
        //Debug.Log(b);
    }
    public static void SearchCountPveResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().CountPve = Convert.ToInt32(server_info[0]);
        }
        

        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void SearchUserPveAttckResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            Debug.Log(_msg);
            string[] server_info = _msg.Split(',');
            Debug.Log(server_info[4]);
            GameControll.SearchUserAttackPve(server_info[0], Convert.ToInt32(server_info[1]), Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[3]),i + 1, server_info[4]);
        }


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }


    public static void SearchPvpReitingResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        Debug.Log(b);
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            Debug.Log(_msg);
            string[] server_info = _msg.Split(',');
            GameControll.SearchPvpReiting(server_info[0], Convert.ToInt32(server_info[1]), Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[3]), i + 1, server_info[4]);
        }


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }

    public static void SearchstroiResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        GameControll.instance.StroiLoad.Clear();
        //string[] a = new string[b];
        for (int i = 0; i < b; i++)
        {

            string _msg = _packet.ReadString();
            GameControll.instance.StroiLoad.Add(_msg);
            string[] server_info = _msg.Split(',');
            int count = 0;
            while (GameControll.instance.stroiFatherList.transform.childCount > 0)
            {
                if (GameControll.instance.stroiFatherList.transform.GetChild(count).gameObject.GetComponent<PersonPrefabScript>().id == Convert.ToInt32(server_info[0]))
                {
                    GameObject peron = GameControll.instance.stroiFatherList.transform.GetChild(count).gameObject;
                    peron.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                    GameObject a = peron.transform.Find("Image").gameObject;
                    GameObject evo = peron.transform.Find("evo").gameObject;
                    a.GetComponent<RectTransform>().sizeDelta = new Vector2(115, 115);
                    evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.71f, 34.71f);
                    peron.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[Convert.ToInt32(server_info[1]) - 1].gameObject.transform, false);
                    GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[Convert.ToInt32(server_info[1]) - 1].GetComponent<stroiObj>().name = peron.GetComponent<PersonPrefabScript>().name;
                    GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[Convert.ToInt32(server_info[1]) - 1].GetComponent<stroiObj>().idPerson = Convert.ToInt32(server_info[0]);
                    peron.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[Convert.ToInt32(server_info[1]) - 1].transform.position;
                    GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(peron.GetComponent<PersonPrefabScript>().name);
                    break;

                }
                else
                {
                    count++;
                }

            }



            GameControll.instance.stroi.GetComponent<stroiScript>().UpdateBs();
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);
    }
    public static void ItemPersonUserUpdateReceiver(Packet _packet)
    {
        
        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Обновилось");
        }




    }

    public static void LevelUpUserResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (msg)
        {
            ClientSend.UpdateLevelUser();
        }
    }
    public static void UpdateUserLevelResiver(Packet _packet)
    {

        int exp = _packet.ReadInt();
        int level = _packet.ReadInt();
        int _myId = _packet.ReadInt();
        Debug.Log(exp);
        GameControll.instance.Level.GetComponent<LevelUser>().level = level;
        GameControll.instance.Level.GetComponent<LevelUser>().exp = exp;
        GameControll.instance.Level.GetComponent<LevelUser>().UpdateBool = false;
    }
    public static void SearchKlanUserResiver(Packet _packet)
    {

        string msg = _packet.ReadString();
        bool bl = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (msg != "0" && bl == true)
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().NameKlan = msg;
            GameControll.instance.KlanUser.SetActive(true);
        }
        else
        {
            while (GameControll.instance.Gildia.GetComponent<GildiaPanel>().FatherSpisokGildia.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.Gildia.GetComponent<GildiaPanel>().FatherSpisokGildia.transform.GetChild(0).gameObject);
            }
            ClientSend.SearchGildia();
            GameControll.instance.Gildia.SetActive(true);
        }




    }
    public static void VstupitInKlanUserResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        string nameKlan = _packet.ReadString();
        int _myId = _packet.ReadInt();
        if (msg == true)
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().NameKlan = nameKlan;
            GameControll.instance.Gildia.SetActive(false);
            GameControll.instance.KlanUser.SetActive(true);
        }
        else
        {

        }
    }
    public static void QuitKlanResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (msg == true)
        {
            GameControll.instance.Gildia.SetActive(true);
            GameControll.instance.KlanUser.SetActive(false);
        }
        else
        {

        }





    }

    public static void KickKlanResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (msg == true)
        {
            while (GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.KlanUser.GetComponent<KlanUser>().FatherListUser.transform.GetChild(0).gameObject);
            }
            ClientSend.ListUserKlan(GameControll.instance.KlanUser.GetComponent<KlanUser>().NameKlan);
            GameControll.instance.KlanUser.GetComponent<KlanUser>().YesKick.SetActive(false);

        }
        else
        {

        }
    }
    public static void SendMsgChatResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (msg == true)
        {
            ClientSend.UpdateChatMsg();
        }
       
    }

    public static void UserAddMaterialAccResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Добавлены данные для переменой пользователя");
        }
        else
        {

        }
    }


    public static void CreatClanResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Создал Клан");
        }
        else
        {
            GameControll.instance.Gildia.GetComponent<GildiaPanel>().CreatGildia.GetComponent<CreatGildia>().NoNameClanYshe();


        }

    }
    

    public static void prizivAddResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Добавилось");
        }




    }

    public static void SkillSmenPerson(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            ClientSend.SearchPersonPanel(GameControll.instance.personPanel.gameObject.GetComponent<PersControlScript>().id);
        }
    }

    public static void BuyShopPredmetResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
            {
                Debug.Log("1232434");
                DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
            }
            if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Snar")
            {
                Debug.Log("Кал 2");
                ClientSend.SearchShopSnar();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Person")
            {
                ClientSend.SearchShopPerson();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "predmet")
            {
                ClientSend.SearchShopPredmet();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "KlanShop")
            {
                ClientSend.SearchKlanShopMaterial();
            }
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(false);
        }

    }
    public static void BuyShopPersonResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
            {
                Debug.Log("1232434");
                DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
            }
            if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Snar")
            {
                Debug.Log("Кал 2");
                ClientSend.SearchShopSnar();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Person")
            {
                ClientSend.SearchShopPerson();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "predmet")
            {
                ClientSend.SearchShopPredmet();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "KlanShop")
            {
                ClientSend.SearchKlanShopMaterial();
            }
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(false);
        }

    }
    public static void BuyShopSnarResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Покупка 1");
            while (GameControll.instance.ItemShopPersonFather.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.ItemShopPersonFather.transform.GetChild(0).gameObject);
            }
            
            if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Snar")
            {
                Debug.Log("Кал 2");
                ClientSend.SearchShopSnar();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "Person")
            {
                ClientSend.SearchShopPerson();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "predmet")
            {
                ClientSend.SearchShopPredmet();
            }
            else if (GameControll.instance.ShopPanel.GetComponent<Shop>().steanica == "KlanShop")
            {
                ClientSend.SearchKlanShopMaterial();
            }
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(false);
        }

    }
    public static void UpdateLevelPersonReceiver(Packet _packet)
    {
        
        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Обновилось");
        }
    }


    public static void SearchKlanMoneyResiver(Packet _packet)
    {

        int msg = _packet.ReadInt();
        int _myId = _packet.ReadInt();
        if (msg != null)
        {
            GameControll.instance.ShopPanel.GetComponent<Shop>().KlanMoney = msg;
        }
    }

    public static void UpdateAstralCountResiver(Packet _packet)
    {

        int msg = _packet.ReadInt();
        int _myId = _packet.ReadInt();
        if (msg != null)
        {
            GameControll.instance.AstralShop.GetComponent<ShopAstral>().MaxAstral = msg;
        }
    }


    public static void VischetMoneyResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            ClientSend.SearchKlanMoney();
        }
    }


    public static void AddStroiPersonResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("добавилось");
        }




    }
    public static void MaterialMinusResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            Debug.Log("Обновление материлов");
        }




    }

    public static void BuyAstralResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            ClientSend.UpdateAstralCount();
            ClientSend.GetUpPanel();
            GameControll.instance.AstralShop.GetComponent<ShopAstral>().zoloto.GetComponent<ObmenAstralGold>().astralSlider.value = 0;
            GameControll.instance.AstralShop.GetComponent<ShopAstral>().almaz.GetComponent<ObmenAstralAlmaz>().astralSlider.value = 0;

        }
    }

    public static void CreateLinkInvoceResiver(Packet _packet)
    {

        string Link = _packet.ReadString();
        string InvId = _packet.ReadString();
        int _myId = _packet.ReadInt();
        GameControll.instance.StartCorPayments(InvId);
        Application.OpenURL(Link);
        

    }

    
    public static void CheckPaymentsResiver(Packet _packet)
    {

        
        string msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        if (msg == "YES")
        {
            GameControll.instance.AstralShop.GetComponent<ShopAstral>().AcceptPay.SetActive(true);
            ClientSend.UpdateAstralCount();
            
        }




    }

    public static void UpdateAvatarResiver(Packet _packet)
    {


        int _Leight = _packet.ReadInt();
        byte[] Byte = _packet.ReadBytes(_Leight);
        int _myId = _packet.ReadInt();

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(Byte);
        GameControll.instance.SettingsPanel.GetComponent<Settings>().avatarImage.texture = texture;
        ClientSend.GetUpPanel();

    }
    public static void GetUpPanelResiver(Packet _packet)
    {


        int _Leight = _packet.ReadInt();
        byte[] Byte = _packet.ReadBytes(_Leight);
        int gold = _packet.ReadInt();
        int almaz = _packet.ReadInt();
        string username = _packet.ReadString();
        int opitPerson = _packet.ReadInt();
        int _myId = _packet.ReadInt();

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(Byte);
        GameControll.instance.Avatar.texture = texture;
        GameControll.instance.gold = gold;
        GameControll.instance.almazInt = almaz;
        GameControll.instance.UsernameText.text = username;
        GameControll.instance.personPanel.GetComponent<PersControlScript>().opitAll = opitPerson;
        GameControll.instance.personPanel.GetComponent<PersControlScript>().goldAll = gold;
    }

    public static void SelectAvatarResiver(Packet _packet)
    {


        int _Leight = _packet.ReadInt();
        byte[] Byte = _packet.ReadBytes(_Leight);
        int _myId = _packet.ReadInt();
        if (Byte != null)
        {
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(Byte);
            GameControll.instance.SettingsPanel.GetComponent<Settings>().avatarImage.texture = texture;
        }
        else
        {
            GameControll.instance.SettingsPanel.GetComponent<Settings>().avatarImage.gameObject.SetActive(false);
        }

    }

    public static void EvlutionLevelPersonResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.gameObject.SetActive(false);
            GameControll.instance.personPanel.GetComponent<PersControlScript>().levelEvo += 1;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Clear();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Clear();
        }




    }
    public static void ValuteUpdateResiver(Packet _packet)
    {

        bool msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        if (!msg)
        {
            ClientSend.GetUpPanel();
        }

    }
    public static void PersonSearchUserReceiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        GameControll.instance.persLoad.Clear();
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();



            GameControll.instance.persLoad.Add(_msg);


            GameControll.instance.debug.text = _msg;

            string[] server_info = _msg.Split(',');
            if (GameControll.instance.Persons.activeSelf == true)
            {
                GameControll.AddPersonSearch(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]));

            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.activeSelf == true)
            {
                

                GameControll.AddPersonSearchUse(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]));
            }
            else if (GameControll.instance.stroi.activeSelf == true)
            {


                GameControll.AddPersonSearchsSroi(i, server_info[1], server_info[0], server_info[2], server_info[3], Convert.ToInt32(server_info[15]), server_info[4], Convert.ToInt32(server_info[7]), Convert.ToInt32(server_info[5]), Convert.ToInt32(server_info[6]), Convert.ToInt32(server_info[8]), Convert.ToInt32(server_info[17]), Convert.ToInt32(server_info[18]), Convert.ToInt32(server_info[19]), Convert.ToInt32(server_info[20]), Convert.ToInt32(server_info[21]), Convert.ToInt32(server_info[22]), Convert.ToInt32(server_info[23]), Convert.ToInt32(server_info[24]), Convert.ToInt32(server_info[25]), Convert.ToInt32(server_info[26]), Convert.ToInt32(server_info[27]));
            }
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);




    }
    public static void MaterailSearchUserReceiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        GameControll.instance.MaterialLoad.Clear();
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();


            

            GameControll.instance.MaterialLoad.Add(_msg);


            GameControll.instance.debug.text = _msg;

            string[] server_info = _msg.Split(',');
            GameControll.AddInventoryMaterial(server_info[0], Convert.ToInt32(server_info[1]), Convert.ToInt32(server_info[2]));
        }
        int _myId = _packet.ReadInt();
        foreach (var st in GameControll.instance.MaterialLoad)
        {
            string[] server_info = st.Split(',');
            if (server_info[0] == "svitok")
            {
                GameControll.instance.priziv.GetComponent<prizav>().Svitok = Convert.ToInt32(server_info[2]);
                GameControll.instance.priziv.GetComponent<prizav>().idSvitok = Convert.ToInt32(server_info[1]);

            }
            else
            {
                GameControll.instance.priziv.GetComponent<prizav>().Svitok = 0;
                GameControll.instance.priziv.GetComponent<prizav>().idSvitok = 0;
            }
        }
    }
    public static void UpdateMsgChatResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        while (GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.GetChild(0).gameObject);
        }
        
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddChatMsg(server_info[1], server_info[0], server_info[2], Convert.ToInt32(server_info[3]));
        }
        GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.position = new Vector3(GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.position.x, (125 * GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.childCount), GameControll.instance.ChatPanel.GetComponent<chat>().FatherChat.transform.position.z);

        int _myId = _packet.ReadInt();
        
    }

    public static void SelectAstralShopResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        while (GameControll.instance.AstralShop.GetComponent<ShopAstral>().FatherShop.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.AstralShop.GetComponent<ShopAstral>().FatherShop.transform.GetChild(0).gameObject);
        }
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.SelectAstralShopItem(Convert.ToInt32(server_info[0]), Convert.ToInt32(server_info[2]), Convert.ToInt32(server_info[1]));
        }
        int _myId = _packet.ReadInt();

    }


    public static void MailUpdateResiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            string[] server_info = _msg.Split(',');
            GameControll.AddMail(server_info[0], server_info[1], server_info[2], server_info[3]);
        }
        
        Debug.Log(GameControll.instance.MailPanel.GetComponent<Mail>().FatherMail.transform.childCount);
        int _myId = _packet.ReadInt();

    }

    public static void ItemSearchUserReceiver(Packet _packet)
    {
        List<String> _list = new List<String>();
        int b = _packet.ReadInt();
        //string[] a = new string[b];
        GameControll.instance.ItemLoad.Clear();
        GameControll.instance.Inventory.GetComponent<InventoryControlScripts>().vkladka = "Snar";
        for (int i = 0; i < b; i++)
        {
            string _msg = _packet.ReadString();
            GameControll.instance.ItemLoad.Add(_msg);


            GameControll.instance.debug.text = _msg;

            string[] server_info = _msg.Split(',');
            if (GameControll.instance.personPanel.activeSelf == true)
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == server_info[0])
                {
                    if (server_info[10] == "")
                    {
                        int attack = 0;
                        int defens = 0;
                        int speed = 0;
                        int hp = 0;
                        int attack_proc = 0;
                        int hp_proc = 0;
                        int defens_proc = 0;
                        int speed_proc = 0;
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
                        try
                        {
                            defens_proc = Convert.ToInt32(server_info[14]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            speed_proc = Convert.ToInt32(server_info[15]);
                        }
                        catch
                        {

                        }
                        GameControll.AddInventoryItem(i, server_info[0], server_info[1], attack, defens, speed, hp, attack_proc, hp_proc, CritDamage, DamageBonus, Convert.ToInt32(server_info[11]), server_info[12], server_info[13], defens_proc, speed_proc);
                    }
                }
            }
            else
            {
                if (server_info[10] == "")
                {
                    int attack = 0;
                    int defens = 0;
                    int speed = 0;
                    int hp = 0;
                    int attack_proc = 0;
                    int hp_proc = 0;
                    int CritDamage = 0;
                    int DamageBonus = 0;
                    int defens_proc = 0;
                    int speed_proc = 0;
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
                    try
                    {
                        defens_proc = Convert.ToInt32(server_info[14]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        speed_proc = Convert.ToInt32(server_info[15]);
                    }
                    catch
                    {

                    }
                    GameControll.AddInventoryItem(i, server_info[0], server_info[1], attack, defens, speed, hp, attack_proc, hp_proc, CritDamage, DamageBonus, Convert.ToInt32(server_info[11]), server_info[12], server_info[13], defens_proc, speed_proc);
                }
            }
            
            
            //_list.Add(_packet.ReadString());
            //Debug.Log(a[i]);
        }
        //string _msg = _packet.ReadString();


        int _myId = _packet.ReadInt();

        //Debug.Log(b);




    }

    public static void RegLogGoustReciver(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        menu.instance.RegisterAll = _msg;
        if (menu.instance.RegisterAll == true)
        {
            

            menu.instance.UsernameField.interactable = false;
            menu.instance.PassswordField.interactable = false;
            menu.instance.ButtonReg.interactable = false;
            
        }
        
    }

    public static void MailDeleteResiver(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        Debug.Log(_msg);
        int _myId = _packet.ReadInt();
        if (_msg == false)
        {
            ClientSend.MailUpdate();

        }

    }

    public static void RegLogGoogleReciver(Packet _packet)
    {
        bool _msg = _packet.ReadBool();
        int _myId = _packet.ReadInt();
        menu.instance.RegisterAll = _msg;
        if (menu.instance.RegisterAll == true)
        {
            

            menu.instance.UsernameField.interactable = false;
            menu.instance.PassswordField.interactable = false;
            menu.instance.ButtonReg.interactable = false;

        }

    }

}
