/*
 *消息处理基类 
 * zhao.yabo
 * creat  2014-12-8
 * modefy 2014-12-8
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ProtoBuf;
using System.IO;
namespace Game
{
    public class ProtocolHandleBase<T>
    {
        private static T _instance;

        public static T Instance
        {
            get { if (_instance == null) { _instance = Activator.CreateInstance<T>(); } return _instance; }
        }

        /// <summary>
        /// 需要子类 重写此方法， 注册需要接受服务器数据的方法
        /// </summary>
        public virtual void RegisterHandler() { }

        /// <summary>
        /// 集中错误处理  统一错误提示
        /// 如果需要对错误进行操作， 监听这个错误码事件
        /// DataEventSource.Instance.AddEventListener(DataNetMessageEvent.GET_ERROR_CODE, (errorCode) => { });
        /// </summary>
        /// <param name="code"></param>
        public void OnErrorCode(int code)
        {
            //LoRServer.ErrorType type = (LoRServer.ErrorType)code;
            //Debug.Log("错误消息码 OnErrorCode : " + type);
            //DataEventSource.Instance.FireEvent(DataNetMessageEventName.GET_ERROR_CODE, code);
        }
        /// <summary>
        ///  序列化proto 
        /// </summary>
        /// <typeparam name="TT"></typeparam>
        /// <param name="_tt"> S2C proto</param>
        /// <returns></returns>
        public MemoryStreamEx ProtobufSerialize<TT>(TT _tt)
        {
            MemoryStreamEx ms = new MemoryStreamEx();
            Serializer.Serialize<TT>(ms, _tt);

            //byte[] _bytes = new byte[2];
            MemoryStream mss = new MemoryStream();
            return ms;
        }
    }
}
