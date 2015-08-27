/*
 * 协议管理器
 * RegisterHandler 接受到服务器数据处理数据的接口
 * ReceiveMsg 在socket处 接受服务器数据
 * zhao.yabo
 * 2015-1-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace Game
{
    public class ProtocolManager 
    {

        private Dictionary<string, Action<MemoryStream>> _dictHandlers = new Dictionary<string, Action<MemoryStream>>();
        private static ProtocolManager _instance;
        public static ProtocolManager Instance
        {
            get { if (_instance == null) _instance = new ProtocolManager(); return _instance; }
        }

        /// <summary>
        /// 初始化注册器
        /// </summary>
        public void InitProtoHandler()
        {
            /*ProtocolHandleConnect.Instance.RegisterHandler();
            ProtocolHandleHero.Instance.RegisterHandler();
            ProtocolHandleWorld.Instance.RegisterHandler();*/
        }

        /// <summary>
        /// 游戏初始化的时候 注册需要接受服务器消息的接口
        /// </summary>
        /// <param name="msgName"></param>
        /// <param name="_action"></param>
        public void RegisterHandler(string msgName, Action<MemoryStream> _action)
        {
            if(_dictHandlers.ContainsKey(msgName))
            {
                Debug.Log("已经注册过该方法，请监听此消息的事件即可");
                return;
            }
            _dictHandlers.Add(msgName, _action);
        }
        /// <summary>
        /// 在接受服务端返回数据处引用
        /// </summary>
        /// <param name="msgName"></param>
        /// <param name="ms"></param>
        public void ReceiveMsg(string msgName, MemoryStream ms)
        {
            if (_dictHandlers.ContainsKey(msgName))
            {
                Action<MemoryStream> _action = _dictHandlers[msgName];
                _action(ms);
            }
            else
            {
                
            }

        }
    }
}
