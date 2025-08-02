using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        if (SceneManager.GetActiveScene().name == "Game")
        {
            ClientGame.instance.tcp.SendData(_packet);
        }
        else
        {
            Client.instance.tcp.SendData(_packet);

        }

    }
    #region Packets

    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                _packet.Write(ClientGame.instance.myId);

            }
            else
            {
                _packet.Write(Client.instance.myId);

            }

            _packet.Write("Подключение");
            

            SendTCPData(_packet);
        }
        
    }

    public static void Register()
    {
        using (Packet _packet = new Packet((int)ClientPackets.registerResiver))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(menu.instance.UsernameField.text);
            _packet.Write(menu.instance.PassswordField.text);
            _packet.Write(menu.instance.ip);

            SendTCPData(_packet);
            
        }

    }
    public static void ServerSerch()
    {
        using (Packet _packet = new Packet((int)ClientPackets.serverSearchResiver))
        {
            _packet.Write(Client.instance.myId);
            

            SendTCPData(_packet);

        }

    }
    public static void PersonSearchUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.persons_userResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));


            SendTCPData(_packet);

        }

    }


    public static void UpdateAstralCount()
    {
        using (Packet _packet = new Packet((int)ClientPackets.UpdateAstralCountResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));


            SendTCPData(_packet);

        }

    }

    public static void SelectAstralShop()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SelectAstralShopResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            SendTCPData(_packet);

        }

    }

    public static void BuyAstral(int AstralCount, string type)
    {

        using (Packet _packet = new Packet((int)ServerPackets.BuyAstral))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(AstralCount);
            _packet.Write(type);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));

            SendTCPData(_packet);
        }
    }

    public static void CheckPayments(string InvId)
    {

        using (Packet _packet = new Packet((int)ServerPackets.CheckPayments))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(InvId);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));

            SendTCPData(_packet);
        }
    }

    public static void LinkInvateCreate(int Count, int Price)
    {

        using (Packet _packet = new Packet((int)ServerPackets.CreateBuy))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(Count);
            _packet.Write(Price);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));

            SendTCPData(_packet);
        }
    }

    public static void UpdateAvatar(byte[] Byte)
    {

        using (Packet _packet = new Packet((int)ServerPackets.SendPhoto))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(Byte.Length);
            _packet.Write(Byte);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));

            SendTCPData(_packet);
        }
    }


    public static void SelectAvatar()
    {

        using (Packet _packet = new Packet((int)ServerPackets.SelectAvatar))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));

            SendTCPData(_packet);
        }
    }


    public static void MailUpdate()
    {
        using (Packet _packet = new Packet((int)ClientPackets.MailUpdateResiver))
        {
            while (GameControll.instance.MailPanel.GetComponent<Mail>().FatherMail.transform.childCount > 0)
            {
                DestroyImmediate(GameControll.instance.MailPanel.GetComponent<Mail>().FatherMail.transform.GetChild(0).gameObject);
            }
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));


            SendTCPData(_packet);

        }

    }
    public static void DeleteMailAll()
    {
        using (Packet _packet = new Packet((int)ClientPackets.MailSeDeleteAllResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));


            SendTCPData(_packet);

        }

    }

    public static void UpdateLevelUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.UpdateLevelUserResiver))
        {
            Debug.Log("fdgsfg");
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));


            SendTCPData(_packet);

        }

    }


    public static void ValuteUpdate(int Count, string type, string operation)
    {
        using (Packet _packet = new Packet((int)ClientPackets.ValuteUpdateResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(Count);
            _packet.Write(type);
            _packet.Write(operation);


            SendTCPData(_packet);

        }

    }
    public static void LevelUpUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.LevelUpUserResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));


            SendTCPData(_packet);

        }

    }

    public static void CreateClen(string name,string description,int level,int sila)
    {
        using (Packet _packet = new Packet((int)ClientPackets.ClanCreateResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(name);
            _packet.Write(description);
            _packet.Write(level);
            _packet.Write(sila);


            SendTCPData(_packet);

        }

    }
    //id - id скила с персонажа
    //type - тип skill1,skill2,skill3 и т.д
    //idSlot - id слота спавнера на котором находится персонаж
    public static void SearchSkillPerson(int id,string type,int idSlot)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchSkilsPersonResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(id);
            _packet.Write(type);
            _packet.Write(idSlot);


            SendTCPData(_packet);

        }

    }


    //id - id скила с персонажа
    //type - тип skill1,skill2,skill3 и т.д
    //idSlot - id слота спавнера на котором находится персонаж
    public static void SearchSkillPersonEnemy(int id, string type, int idSlot)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchSkilsPersonEnemyResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(id);
            _packet.Write(type);
            _packet.Write(idSlot);
            Debug.Log("Gbpljc");

            SendTCPData(_packet);

        }

    }

    public static void SearchGildia()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchGildiaResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            SendTCPData(_packet);

        }

    }
    public static void InventorySearchUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.item_inventoriResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            Debug.Log("Инвентори");

            SendTCPData(_packet);

        }

    }

    public static void SearchKlanUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchKlanUserResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));

            SendTCPData(_packet);

        }

    }

    public static void VstupitInKlanUser(string nameKlan)
    {
        using (Packet _packet = new Packet((int)ClientPackets.VstupitInKlanUserResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(nameKlan);

            SendTCPData(_packet);

        }

    }

    public static void QuitKlanUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.QuitKlanUserResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));

            SendTCPData(_packet);

        }

    }

    public static void PvpStart()
    {
        using (Packet _packet = new Packet((int)ClientPackets.PvpStartResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));

            SendTCPData(_packet);

        }

    }

    public static void PvpWinUser(string mailEnemy,int Gold,int scoreUser,int ScoreEnemy)
    {
        using (Packet _packet = new Packet((int)ClientPackets.PvpWinUserResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(mailEnemy);
            _packet.Write(scoreUser);
            _packet.Write(ScoreEnemy);
            SendTCPData(_packet);

        }

    }

    public static void SearchItemPersonBattle(int idPerson, int idSlot, string typePerson)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchItemPersonBattleResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(idPerson);
            _packet.Write(idSlot);
            _packet.Write(typePerson);
            SendTCPData(_packet);

        }

    }
    public static void InventoryMaterialSearchUser()
    {
        using (Packet _packet = new Packet((int)ClientPackets.InventoryMaterialResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            Debug.Log("Инвентори");

            SendTCPData(_packet);

        }

    }
    public static void SearchShopPerson()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchPersonShopResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    
    public static void SearchShopSnar()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchSnarShopResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    public static void SearchShopPredmet()
    {
        using (Packet _packet = new Packet((int)ClientPackets.PredmetShopResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    public static void SearchKlanMoney()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchKlanMoneyResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void SearchKlanShopMaterial()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchKlanMaterialResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void PrizivAdd(string rank, string Name, string name_ru, string type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.prizivItemResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(rank);
            _packet.Write(Name);
            _packet.Write(name_ru);
            _packet.Write(type);
            SendTCPData(_packet);

        }

    }
    public static void WinBossKvest(int level)
    {
        using (Packet _packet = new Packet((int)ClientPackets.WinBossKvestResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(level);
            SendTCPData(_packet);

        }

    }
    public static void BuyShopPerson(int _id, int _id_shop, bool klanShop = false)
    {
        using (Packet _packet = new Packet((int)ClientPackets.BuyShopPersonResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(_id);
            _packet.Write(_id_shop);
            _packet.Write(klanShop);
            SendTCPData(_packet);

        }

    }
    public static void MaterialMinus(int _id, int Count, string znak)
    {
        using (Packet _packet = new Packet((int)ClientPackets.materialMinusResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(_id);
            _packet.Write(Count);
            _packet.Write(znak);
            SendTCPData(_packet);

        }

    }
    public static void BuyShopSnar(int _id, int _id_shop,bool klanShop = false)
    {
        using (Packet _packet = new Packet((int)ClientPackets.BuyShopSnarResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(_id);
            _packet.Write(_id_shop);
            _packet.Write(klanShop);
            SendTCPData(_packet);

        }

    }

    public static void UserAddMateralAcc(int Count, string type, int idShop, bool klanShop = false)
    {
        using (Packet _packet = new Packet((int)ClientPackets.UserAddMaterialAccResiver))
        {
            Debug.Log("Хуйня");
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(Count);
            _packet.Write(type);
            _packet.Write(idShop);
            _packet.Write(klanShop);
            SendTCPData(_packet);

        }

    }

    public static void BuyShopPredmet(int _id, int _id_shop,bool klanShop = false)
    {
        using (Packet _packet = new Packet((int)ClientPackets.PredmetShopByuResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(_id);
            _packet.Write(_id_shop);
            _packet.Write(klanShop);
            SendTCPData(_packet);

        }

    }
    public static void AddStroiPerson(int idStroi, int IdPerson,string Name,string type,string znak)
    {
        using (Packet _packet = new Packet((int)ClientPackets.addStroiPersonResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(idStroi);
            _packet.Write(IdPerson);
            _packet.Write(Name);
            _packet.Write(type);
            _packet.Write(znak);
            SendTCPData(_packet);

        }

    }

    public static void SearchPveCount(string type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchPveCountResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(type);
            SendTCPData(_packet);

        }

    }

    public static void SearchPveUserAtack()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchPveUserAttackResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void SearchPvpUserReiting()
    {
        using (Packet _packet = new Packet((int)ClientPackets.PvpReitingResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void VischetMoney(int Value, string type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.VichetMoneyResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(Value);
            _packet.Write(type);
            SendTCPData(_packet);

        }

    }

    public static void SearchStroiPerson(string type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchStroiResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(type);
            SendTCPData(_packet);

        }

    }
    public static void AddPersonPve(string type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.AddPersonPveResiver))
        {
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonidListSlot.Clear();
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Clear();
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(type);
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void AddCvestKlanBoss()
    {
        using (Packet _packet = new Packet((int)ClientPackets.BossAddKvestKlanResiver))
        {
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().EnemyPersonidListSlot.Clear();
            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().ListSpeedPersonEnemy.Clear();
            _packet.Write(ClientGame.instance.myId);
            SendTCPData(_packet);

        }

    }

    public static void AddPersonEnemyPvp(string type,string idUser)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchUserEnemyPvpResiver))
        {
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Clear();
            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemy.Clear();
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(type);
            _packet.Write(idUser);
            SendTCPData(_packet);

        }

    }

    public static void SearchLevelBatlePve()
    {
        using (Packet _packet = new Packet((int)ClientPackets.InfoLevelBatlePveResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    public static void GlavReitingUserKvestKlan(string KlanName)
    {
        using (Packet _packet = new Packet((int)ClientPackets.GlavReitingKvestKlanResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(KlanName);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void GetUpPanel()
    {
        using (Packet _packet = new Packet((int)ClientPackets.SetUpPanelResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void WinRewerdKvestKlan(int level)
    {
        using (Packet _packet = new Packet((int)ClientPackets.WinRewerdKvestKlanResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(level);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    public static void SendMsgChat(string msg)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SendMsgChatResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(msg);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }

    public static void UpdateChatMsg()
    {
        using (Packet _packet = new Packet((int)ClientPackets.UpdateChatMsgResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            SendTCPData(_packet);

        }

    }

    public static void SearchPersonEnemy(string name)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchPersonEnemyPveResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(name);
            SendTCPData(_packet);

        }

    }
    public static void EndBattleKvestKlan(string KlanName,int Damage)
    {
        using (Packet _packet = new Packet((int)ClientPackets.EndBattleKvestKLanResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(KlanName);
            _packet.Write(Damage);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            SendTCPData(_packet);

        }

    }
    public static void ListUserKlan(string KlanName)
    {
        using (Packet _packet = new Packet((int)ClientPackets.ListUserKlanResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(KlanName);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            SendTCPData(_packet);

        }

    }

    public static void KickUserKlan(string mail, string IpServer)
    {
        using (Packet _packet = new Packet((int)ClientPackets.KickUserKlanResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(IpServer);
            _packet.Write(mail);
            SendTCPData(_packet);

        }

    }

    public static void SearchPersonPanel(int id)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchSkillPersonPanel))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(id);
            SendTCPData(_packet);

        }

    }

    public static void SearcSkillStrPersonPanel(int idSkill,string skillName)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SearchSkillPersonPanelStrResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(idSkill);
            _packet.Write(skillName);
            SendTCPData(_packet);

        }

    }

    public static void SkilSmen(int idSkill1, int idSkill2,int idPerson, int type)
    {
        using (Packet _packet = new Packet((int)ClientPackets.SkilSmenPersonResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(idSkill1);
            _packet.Write(idSkill2);
            _packet.Write(idPerson);
            _packet.Write(type);
            SendTCPData(_packet);

        }

    }


    public static void ItemPersonUserUpdate(int _idItem, int _idPerson)
    {
        using (Packet _packet = new Packet((int)ClientPackets.itemPersonUpdateResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(_idItem);
            _packet.Write(_idPerson);
            

            SendTCPData(_packet);

        }

    }
    public static void UpdateLevelPerson(int _level, int _idPerson)
    {
        using (Packet _packet = new Packet((int)ClientPackets.UpdateLevelResiveer))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(PlayerPrefs.GetString("GameServerIp"));
            _packet.Write(PlayerPrefs.GetString("mail"));
            _packet.Write(_level);
            _packet.Write(_idPerson);


            SendTCPData(_packet);

        }

    }
    public static void LoginTo()
    {
        using (Packet _packet = new Packet((int)ClientPackets.loginResiver))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(menu.instance.MailFieldLogin.text);
            _packet.Write(menu.instance.PasswordlFieldLogin.text);
            _packet.Write(menu.instance.ip);

            SendTCPData(_packet);

        }

    }

    public static void GoustRegLog()
    {
        using (Packet _packet = new Packet((int)ClientPackets.regLogGoustResiver))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UnityEngine.Device.SystemInfo.deviceUniqueIdentifier);
            _packet.Write(menu.instance.ip);
            PlayerPrefs.SetString("mail", UnityEngine.Device.SystemInfo.deviceUniqueIdentifier);
            SendTCPData(_packet);

        }
    }
    public static void GoogleRegLog()
    {
        using (Packet _packet = new Packet((int)ClientPackets.regLogGoogleResiver))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(menu.instance.IdUserGooglePlay);
            PlayerPrefs.SetString("mail", UnityEngine.Device.SystemInfo.deviceUniqueIdentifier);
            _packet.Write(menu.instance.ip);

            SendTCPData(_packet);

        }
    }

    public static void EvalutionSend()
    {

        using (Packet _packet = new Packet((int)ClientPackets.evalutionSendResiver))
        {
            _packet.Write(ClientGame.instance.myId);
            _packet.Write(GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
            List<int> list = new List<int>();
            list.AddRange(GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id);
            list.AddRange(GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id);
            _packet.Write(list.Count);
            Debug.Log(list[0].GetType());
            for (int i = 0; i < list.Count; i++)
            {
                _packet.Write(list[i]);
                //byte[] bytes = Encoding.Unicode.GetBytes(_msg[i]);
                //_packet.Write(Convert.ToString( bytes));
                //byte[] bytes = Encoding.Unicode.GetBytes(_msg[i]);
                //string a = Encoding.Unicode.GetString(bytes);
                //Console.WriteLine(a);
                //Console.WriteLine(bytes);

                //Console.WriteLine(_msg[i]);
            }

            // _packet.Write(_msg);
            

            SendTCPData(_packet);
        }
    }

    #endregion
}
