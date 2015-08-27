/*
 * BlueTorch Mobile Net Core
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
#if !UNITY_WEBPLAYER
using System.Net.NetworkInformation;
#endif

namespace Game
{
    public class CClientNetworkCtrl
    {
        private static CClientNetworkCtrl _instance;

        private IAsyncResult m_ar_Recv;
        private IAsyncResult m_ar_Send;
        private IAsyncResult m_ar_Connect;
        private Socket m_ClientSocket;
        private string m_strRomoteIP = "127.0.0.1";
        private ushort m_uRemotePort;
        private INetMessageReader m_Reader;
        private INetMessageWriter m_Writer;
        private dNetWorkStateCallBack m_StateCallBack;
        private MemoryStreamEx m_ComunicationMem = new MemoryStreamEx();
        private object m_eNetWorkState = EClientNetWorkState.E_CNWS_NOT_UNABLE;
        private Queue<byte[]> m_SendQueue = new Queue<byte[]>();


        public CClientNetworkCtrl()
        {
            CNetStreamReader reader = new CNetStreamReader();
            CNetStreamReaderHandler handleMessage = new CNetStreamReaderHandler();
            reader.HandleMessage = handleMessage;
            this.Reader = reader;
        }

        public static CClientNetworkCtrl Instance
        {
            get { if (_instance == null) { _instance = new CClientNetworkCtrl(); } return _instance; }
        }

        public INetMessageReader Reader
        {
            set
            {
                this.m_Reader = value;
            }
        }
        public INetMessageWriter Writer
        {
            set
            {
                this.m_Writer = value;
            }
        }
        public bool IsConnected()
        {
            return this.m_ClientSocket != null && this.m_ClientSocket.Connected;
        }
        public void RegisterNetWorkStateLister(dNetWorkStateCallBack callback)
        {
            if (this.m_StateCallBack == null)
            {
                this.m_StateCallBack = new dNetWorkStateCallBack(callback.Invoke);
            }
            else
            {
                this.m_StateCallBack = (dNetWorkStateCallBack)Delegate.Combine(this.m_StateCallBack, callback);
            }
        }
        public void UnRegisterNetWorkStateLister(dNetWorkStateCallBack callback)
        {
            if (this.m_StateCallBack != null)
            {
                this.m_StateCallBack = (dNetWorkStateCallBack)Delegate.Remove(this.m_StateCallBack, callback);
            }
        }
        public bool Connect(string a_strRomoteIP, ushort a_uPort)
        {
            //a_strRomoteIP = "192.168.18.200";
            if (this.m_ClientSocket == null)
            {
                try
                {
                    this.m_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress address = IPAddress.Parse(a_strRomoteIP);
                    this.m_ar_Connect = this.m_ClientSocket.BeginConnect(address, (int)a_uPort, new AsyncCallback(this.ConnectCallback), this.m_ClientSocket);
                    this.m_strRomoteIP = a_strRomoteIP;
                    this.m_uRemotePort = a_uPort;
                }
                catch (Exception message)
                {
                    DidConnectError(message);
                }

                return true;
            }
            return false;
        }
        public bool DisConnect()
        {
            this.ReleaseSocket();
            return true;
        }
        public bool ReConnect()
        {
            if (this.m_strRomoteIP != null)
            {
                this.ReleaseSocket();
                return this.Connect(this.m_strRomoteIP, this.m_uRemotePort);
            }
            return false;
        }
        public bool SendMessage(MemoryStream data)
        {
            if (this.m_Writer != null)
            {
                byte[] array = this.m_Writer.MakeStream(data);
                Queue<byte[]> sendQueue = this.m_SendQueue;
                Monitor.Enter(sendQueue);
                try
                {
                    bool result;
                    if (this.m_SendQueue.Count == 0)
                    {
                        result = this.Send(array);
                        return result;
                    }
                    this.m_SendQueue.Enqueue(array);
                    result = true;
                    return result;
                }
                finally
                {
                    Monitor.Exit(sendQueue);
                }
            }
            return false;
        }
        public void ReleaseSocket()
        {
            if (this.m_ar_Recv != null)
            {
                this.m_ar_Recv.AsyncWaitHandle.Close();
            }
            if (this.m_ar_Send != null)
            {
                this.m_ar_Send.AsyncWaitHandle.Close();
            }
            if (this.m_ar_Connect != null)
            {
                this.m_ar_Connect.AsyncWaitHandle.Close();
            }
            if (this.m_ClientSocket != null)
            {
                if (this.m_ClientSocket.Connected)
                {
                    try
                    {
                        this.m_ClientSocket.Shutdown(SocketShutdown.Both);
                    }
                    catch (Exception message)
                    {
                        // 						MonoBehaviour.print(message);
                    }
                    finally
                    {
                        this.m_ClientSocket.Close();
                        this.m_ClientSocket = null;
                    }
                }
                else
                {
                    this.m_ClientSocket = null;
                }
            }
            this.m_eNetWorkState = EClientNetWorkState.E_CNWS_NOT_UNABLE;
            if (this.m_Reader != null)
            {
                this.m_Reader.Reset();
            }
            if (this.m_Writer != null)
            {
                this.m_Writer.Reset();
            }
        }
        public void Update()
        {
            MemoryStreamEx comunicationMem = this.m_ComunicationMem;
            Monitor.Enter(comunicationMem);
            try
            {
                if (this.m_ComunicationMem.Length > 0L)
                {
                    if (this.m_Reader != null)
                    {
                        this.m_Reader.DidReadData(this.m_ComunicationMem.GetBuffer(), (int)this.m_ComunicationMem.Length);
                    }
                    this.m_ComunicationMem.Clear();
                }
            }
            finally
            {
                Monitor.Exit(comunicationMem);
            }
            object eNetWorkState = this.m_eNetWorkState;
            Monitor.Enter(eNetWorkState);
            try
            {
                EClientNetWorkState eClientNetWorkState = (EClientNetWorkState)((int)this.m_eNetWorkState);
                if (eClientNetWorkState == EClientNetWorkState.E_CNWS_CONNECTED)
                {
                    this.CallBackNetState(eClientNetWorkState);
                    m_eNetWorkState = EClientNetWorkState.E_CNWS_NORMAL;
                }
                if (eClientNetWorkState > EClientNetWorkState.E_CNWS_NORMAL && this.m_ClientSocket != null)
                {
                    this.ReleaseSocket();
                    this.CallBackNetState(eClientNetWorkState);
                }
            }
            finally
            {
                Monitor.Exit(eNetWorkState);
            }
        }
        private void CallBackNetState(EClientNetWorkState a_eState)
        {
            try
            {
                if (this.m_StateCallBack != null)
                {
                    this.m_StateCallBack(a_eState, this.m_strRomoteIP, this.m_uRemotePort);
                }
            }
            catch (Exception e)
            {
                this.DidConnectError(e);
            }
        }
        public void SetSocketSendNoDeley(bool nodelay)
        {
            if (this.m_ClientSocket != null)
            {
                this.m_ClientSocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, (!nodelay) ? 0 : 1);
            }
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                ar.AsyncWaitHandle.Close();
                this.m_ar_Connect = null;
                Socket socket = (Socket)ar.AsyncState;
                socket.EndConnect(ar);
                socket.Blocking = false;
                if (this.m_ClientSocket != null)
                {
                    this.m_ClientSocket.ReceiveTimeout = 3000;
                    this.m_ClientSocket.SendTimeout = 3000;
                }
                this.Receive();
                m_eNetWorkState = EClientNetWorkState.E_CNWS_CONNECTED;
            }
            catch (Exception e)
            {
                this.DidConnectError(e);
            }
        }
        private void DidConnectError(Exception e)
        {
            object eNetWorkState = this.m_eNetWorkState;
            Monitor.Enter(eNetWorkState);
            try
            {
                this.m_eNetWorkState = EClientNetWorkState.E_CNWS_ON_CONNECTED_FAILED;
            }
            finally
            {
                Monitor.Exit(eNetWorkState);
            }
        }
        private void DidDisconnect(Exception e)
        {
            object eNetWorkState = this.m_eNetWorkState;
            Monitor.Enter(eNetWorkState);
            try
            {
                this.m_eNetWorkState = EClientNetWorkState.E_CNWS_ON_DISCONNECTED;
            }
            finally
            {
                Monitor.Exit(eNetWorkState);
            }
        }
        private void Receive()
        {
            try
            {
                StateObjectForRecvData stateObjectForRecvData = new StateObjectForRecvData();
                stateObjectForRecvData.workSocket = this.m_ClientSocket;
                this.m_ar_Recv = this.m_ClientSocket.BeginReceive(stateObjectForRecvData.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), stateObjectForRecvData);
            }
            catch (Exception e)
            {
                this.DidDisconnect(e);
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                ar.AsyncWaitHandle.Close();
                this.m_ar_Recv = null;
                StateObjectForRecvData stateObjectForRecvData = (StateObjectForRecvData)ar.AsyncState;
                Socket workSocket = stateObjectForRecvData.workSocket;
                int num = workSocket.EndReceive(ar);
                if (num > 0)
                {
                    MemoryStreamEx comunicationMem = this.m_ComunicationMem;
                    Monitor.Enter(comunicationMem);
                    try
                    {
                        this.m_ComunicationMem.Write(stateObjectForRecvData.buffer, 0, num);
                    }
                    finally
                    {
                        Monitor.Exit(comunicationMem);
                    }
                }
                this.m_ar_Recv = workSocket.BeginReceive(stateObjectForRecvData.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), stateObjectForRecvData);
            }
            catch (Exception e)
            {
                this.DidDisconnect(e);
            }
        }
        private bool Send(byte[] byteData)
        {
            try
            {
                this.m_ar_Send = this.m_ClientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), this.m_ClientSocket);
                return true;
            }
            catch (Exception e)
            {
                this.DidDisconnect(e);
            }
            return false;
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                ar.AsyncWaitHandle.Close();
                this.m_ar_Send = null;
                Socket socket = (Socket)ar.AsyncState;
                socket.EndSend(ar);
                this.OnSendSuccess();
            }
            catch (Exception e)
            {
                this.DidDisconnect(e);
            }
        }
        private void OnSendSuccess()
        {
            Queue<byte[]> sendQueue = this.m_SendQueue;
            Monitor.Enter(sendQueue);
            try
            {
                if (this.m_SendQueue.Count > 0)
                {
                    this.Send(this.m_SendQueue.Dequeue());
                }
            }
            finally
            {
                Monitor.Exit(sendQueue);
            }
        }
        public static IPAddress GetLocalIP()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
            return (hostAddresses.Length <= 0) ? null : hostAddresses[0];
        }
        public static string GetLocalIPString()
        {
            IPAddress localIP = CClientNetworkCtrl.GetLocalIP();
            return (localIP == null) ? "127.0.0.1" : localIP.ToString();
        }
        public static string GetAdapterMAC()
        {
#if !UNITY_WEBPLAYER && !UNITY_ANDROID
            IPAddress localIP = CClientNetworkCtrl.GetLocalIP();
            if (localIP != null)
            {
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                NetworkInterface[] array = allNetworkInterfaces;
                for (int i = 0; i < array.Length; i++)
                {
                    NetworkInterface networkInterface = array[i];
                    IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection unicastAddresses = iPProperties.UnicastAddresses;
                    for (int j = 0; j < unicastAddresses.Count; j++)
                    {
                        if (unicastAddresses[j].Address.Equals(localIP))
                        {
                            return networkInterface.GetPhysicalAddress().ToString();
                        }
                    }
                }
            }
#endif
            return "000000000000";
        }
        public static string GetAdapterMacIOS()
        {
#if !UNITY_WEBPLAYER
            string empty = string.Empty;
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface[] array = allNetworkInterfaces;
            for (int i = 0; i < array.Length; i++)
            {
                NetworkInterface networkInterface = array[i];
                PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                if (physicalAddress.ToString() != string.Empty)
                {
                    return physicalAddress.ToString();
                }
            }
#endif
            return "000000000000";
        }
        public static List<string> GetAllMacAddress()
        {
#if !UNITY_WEBPLAYER
            List<string> list = new List<string>();
            IPAddress localIP = CClientNetworkCtrl.GetLocalIP();
            if (localIP != null)
            {
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                NetworkInterface[] array = allNetworkInterfaces;
                for (int i = 0; i < array.Length; i++)
                {
                    NetworkInterface networkInterface = array[i];
                    IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection unicastAddresses = iPProperties.UnicastAddresses;
                    for (int j = 0; j < unicastAddresses.Count; j++)
                    {
                        list.Add(networkInterface.GetPhysicalAddress().ToString());
                    }
                }
            }
            return list;
#else
            return null;
#endif
        }
        public void Ping(string server)
        {
        }
    }
}
