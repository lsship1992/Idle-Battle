using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using Unity.VisualScripting;

public class Client : MonoBehaviour
{
    public static Client instance;
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
            socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);

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
            { (int)ServerPackets.regLogGoogle, ClientHandle.RegLogGoogleReciver}
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
