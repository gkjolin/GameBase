using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Game
{
    public class ProtocolHandleConnect:ProtocolHandleBase<ProtocolHandleConnect>
    {
        public override void RegisterHandler()
        {
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_CONNECT_SERVER, ReceiveConnectServer);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_CONNECT_SERVER, ReceiveGameServerList);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_LOGIN, ReceiveLogin);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_REGISTER, ReceiveRegister);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_ENTER_GAME, ReceiveEnterGame);
        }
        //连接服务器
        public void RequestConnectServer()
        {
            CClientNetworkCtrl.Instance.Connect(NetClient.host, NetClient.port);
        }

        private void ReceiveConnectServer(MemoryStream ms)
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CONNECT_SERVER, ms);
        }
        //请求游戏服务器列表
        public void RequestGameServerList()
        {

        }

        private void ReceiveGameServerList(MemoryStream ms)
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_GAME_SERVER_LIST, null);
        }
        //登陆
        public void RequestLogin(string name,string password)
        {
            if (NetClient.IsOffline)
            {
               /* Server_login sl = new Server_login();
                sl.id = 1;
                DataEventSource.Instance.FireEvent(ProtocolEventName.GET_LOGIN, sl);*/

            }else
            {

            }

        }

        private void ReceiveLogin(MemoryStream ms)
        {
            /*Server_login sl = Serializer.Deserialize<Server_login>(ms);
            DataEventSource.Instance.FireEvent(ProtocolEventName.GET_LOGIN,sl);*/
        }
        //注册
        public void RequestRegister()
        {

        }

        private void ReceiveRegister(MemoryStream ms)
        {

        }
        //请求进入游戏
        public void RequestEnterGame()
        {
            if(NetClient.IsOffline)
            {
                //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_ENTER_GAME, null);
            }else
            {

            }
        }
        private void ReceiveEnterGame(MemoryStream ms)
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_ENTER_GAME, null);
        }

    }
}
