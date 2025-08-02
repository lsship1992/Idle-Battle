using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using Unity.VisualScripting;

public class ClientGame : MonoBehaviour
{
    public static ClientGame instance;
    public static int dataBufferSize = 4096;

    private bool isConnected = false;
    private delegate void PacketHandle(Packet _packet);
    private static Dictionary<int, PacketHandle> packetHadlers;

    private string ip = "109.73.206.253";

    public int port = 26950;
    public int myId = 0;
    public TCP tcp;

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
        
    }
    
    private void Start()
    {
        tcp = new TCP();
        ConnectToServer();
    }
    public void ConnectToServer()
    {
        
        InitializeClientData();
        isConnected = true;
        tcp.Connect();

    }
    public class TCP 
    {
        public TcpClient socket;
        private Packet receivedData;
        private NetworkStream stream;
        private byte[] receiveBuffer;
        public void Connect()
        {
            socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
                
            };
            receiveBuffer = new byte[dataBufferSize];
            instance.ip = PlayerPrefs.GetString("GameServerIp");
            Debug.Log(PlayerPrefs.GetString("GameServerIp"));
            socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
            Debug.Log("Test");


        }
        private void ConnectCallback(IAsyncResult _result)
        {
            socket.EndConnect(_result);
            if (!socket.Connected)
            {
                menu.instance.ErrorText.text = "Ошибка подключени";
                return;
            }
            stream = socket.GetStream();
            receivedData = new Packet();
            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

        }

        public void SendData(Packet _packet)
        {
            try
            {
                if (socket != null)
                {
                    stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null,null);
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error sending data to server via TCP: {_ex}");
            }
        }
        private void ReceiveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    instance.Disconnect();
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer, _data,_byteLength);

                receivedData.Reset(HandleData(_data));
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch (Exception _ex) 
            {
                Disconnect();

            }
        }
        private bool HandleData(byte[] _data)
        {
            int _packetLenght = 0;

            receivedData.SetBytes(_data);
            if (receivedData.UnreadLength() >= 4)
            {
                _packetLenght = receivedData.ReadInt();
                if (_packetLenght <= 0)
                {
                    return true;
                }

                
            }
            while (_packetLenght > 0 && _packetLenght <= receivedData.UnreadLength())
            {
                byte[] _packetBytes = receivedData.ReadBytes(_packetLenght);
                ThreadManager.ExecuteOnMainThread(() => {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        packetHadlers[_packetId](_packet);
                    }
                });
                _packetLenght = 0;
                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLenght = receivedData.ReadInt();
                    if (_packetLenght <= 0)
                    {
                        return true;
                    }


                }
            }
            if (_packetLenght <= 1)
            {
                return true;
            }
            return false;
        }
        public void Disconnect()
        {
            instance.Disconnect();
            stream = null;
            receivedData = null;
            receiveBuffer = null;
            socket = null;
            
        }

    }
    private void InitializeClientData()
    {
        packetHadlers = new Dictionary<int, PacketHandle>()
        {
            { (int)ServerPackets.welcome, ClientHandle.Welcome },
            { (int)ServerPackets.register, ClientHandle.RegisterRecived },
            { (int)ServerPackets.serverSearch, ClientHandle.ServerSearchReceiver },
            { (int)ServerPackets.login, ClientHandle.LoginReceived},
            { (int)ServerPackets.regLogGoust, ClientHandle.RegLogGoustReciver},
            { (int)ServerPackets.regLogGoogle, ClientHandle.RegLogGoogleReciver},
            { (int)ServerPackets.persons_user, ClientHandle.PersonSearchUserReceiver},
            { (int)ServerPackets.item_inventori, ClientHandle.ItemSearchUserReceiver},
            { (int)ServerPackets.itemPersonUpdate, ClientHandle.ItemPersonUserUpdateReceiver},
            { (int)ServerPackets.UpdateLevel, ClientHandle.UpdateLevelPersonReceiver},
            { (int)ServerPackets.evalutionSend, ClientHandle.EvlutionLevelPersonResiver},
            { (int)ServerPackets.SearchPersonShop, ClientHandle.ItemShopPerson},
            { (int)ServerPackets.SearchSnarShop, ClientHandle.ItemShopSnar},
            { (int)ServerPackets.BuyShopPerson, ClientHandle.BuyShopPersonResiver},
            { (int)ServerPackets.BuyShopSnar, ClientHandle.BuyShopSnarResiver},
            { (int)ServerPackets.prizivItem, ClientHandle.prizivAddResiver},
            { (int)ServerPackets.InventoryMaterial, ClientHandle.MaterailSearchUserReceiver},
            { (int)ServerPackets.materialMinus, ClientHandle.MaterialMinusResiver},
            { (int)ServerPackets.PredmetShop, ClientHandle.ItemShopPredmet},
            { (int)ServerPackets.PredmetShopByu, ClientHandle.BuyShopPredmetResiver},
            { (int)ServerPackets.addStroiPerson, ClientHandle.AddStroiPersonResiver},
            { (int)ServerPackets.SearchStroi, ClientHandle.SearchstroiResiver},
            { (int)ServerPackets.AddPersonPve, ClientHandle.AddPersonUserPveResiver},
            { (int)ServerPackets.InfoLevelBatlePve, ClientHandle.InfoBattlePveResiver},
            { (int)ServerPackets.SearchPersonEnemyPve, ClientHandle.AddPersonEnemyPveResiver},
            { (int)ServerPackets.WinBossKvest, ClientHandle.WinBossKvestResiver},
            { (int)ServerPackets.SearchItemPersonBattle, ClientHandle.SearchItemPersonBattleResiver},
            { (int)ServerPackets.SearchSkilsPerson, ClientHandle.SearchSkillPersonResiver},
            { (int)ServerPackets.SearchSkilsPersonEnemy, ClientHandle.SearchSkillPersonEnemyResiver},
            { (int)ServerPackets.SearchSkillPersonPanel, ClientHandle.AddSkillPersonPanel},
            { (int)ServerPackets.SearchSkillPersonPanelStr, ClientHandle.AddSkillPersonPanelStr},
            { (int)ServerPackets.SkilSmenPerson, ClientHandle.SkillSmenPerson},
            { (int)ServerPackets.SearchPveCount, ClientHandle.SearchCountPveResiver},
            { (int)ServerPackets.SearchPveUserAttack, ClientHandle.SearchUserPveAttckResiver},
            { (int)ServerPackets.SearchUserEnemyPvp, ClientHandle.AddPersonUserEnemyPvPResiver},
            { (int)ServerPackets.PvpWinUser, ClientHandle.PvpWinUserResiver},
            { (int)ServerPackets.PvpStart, ClientHandle.PvpStartResiver},
            { (int)ServerPackets.PvpReiting, ClientHandle.SearchPvpReitingResiver},
            { (int)ServerPackets.ClanCreate, ClientHandle.CreatClanResiver},
            { (int)ServerPackets.SearchGildia, ClientHandle.SearchGildiaResiver},
            { (int)ServerPackets.SearchKlanUser, ClientHandle.SearchKlanUserResiver},
            { (int)ServerPackets.VstupitInKlanUser, ClientHandle.VstupitInKlanUserResiver},
            { (int)ServerPackets.QuitKlanUser, ClientHandle.QuitKlanResiver},
            { (int)ServerPackets.UserAddMaterialAcc, ClientHandle.UserAddMaterialAccResiver},
            { (int)ServerPackets.SearchKlanMaterialResiver, ClientHandle.SearchKlanShop},
            { (int)ServerPackets.SearchKlanMoney, ClientHandle.SearchKlanMoneyResiver},
            { (int)ServerPackets.VichetMoney, ClientHandle.VischetMoneyResiver},
            { (int)ServerPackets.BossAddKvestKlan, ClientHandle.AddBossKvestKlanResiver},
            { (int)ServerPackets.EndBattleKvestKLan, ClientHandle.EndBattleKvestKlan},
            { (int)ServerPackets.GlavReitingKvestKlan, ClientHandle.GlavReitingKvestKlanUser},
            { (int)ServerPackets.WinRewerdKvestKlan, ClientHandle.WinRewerdKvestKlanREsiver},
            { (int)ServerPackets.ListUserKlan, ClientHandle.ListUserKlan},
            { (int)ServerPackets.KickUserKlan, ClientHandle.KickKlanResiver},
            { (int)ServerPackets.SendMsgChat, ClientHandle.SendMsgChatResiver},
            { (int)ServerPackets.UpdateChatMsg, ClientHandle.UpdateMsgChatResiver},
            { (int)ServerPackets.UpdateLevelUser, ClientHandle.UpdateUserLevelResiver},
            { (int)ServerPackets.LevelUpUser, ClientHandle.LevelUpUserResiver},
            { (int)ServerPackets.MailUpdate, ClientHandle.MailUpdateResiver},
            { (int)ServerPackets.MailSeDeleteAll, ClientHandle.MailDeleteResiver},
            { (int)ServerPackets.UpdateAstralCount, ClientHandle.UpdateAstralCountResiver},
            { (int)ServerPackets.SelectAstralShop, ClientHandle.SelectAstralShopResiver},
            { (int)ServerPackets.BuyAstral, ClientHandle.BuyAstralResiver},
            { (int)ServerPackets.CreateBuy, ClientHandle.CreateLinkInvoceResiver},
            { (int)ServerPackets.CheckPayments, ClientHandle.CheckPaymentsResiver},
            { (int)ServerPackets.SendPhoto, ClientHandle.UpdateAvatarResiver},
            { (int)ServerPackets.SelectAvatar, ClientHandle.SelectAvatarResiver},
            { (int)ServerPackets.SetUpPanel, ClientHandle.GetUpPanelResiver},
            { (int)ServerPackets.ValuteUpdate, ClientHandle.ValuteUpdateResiver},
        };
        Debug.Log("Initial packet");
    }
    public void Disconnect()
    {
        if (isConnected)
        {
            isConnected = false;
            tcp.socket.Close();

            Debug.Log("Disconnect from server.");
        }
    }
}
