using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// @Description: 数据管理器
    /// @author WSG
    /// @date 2015-0513
    /// </summary>
    public class DataManager
    {

        /// <summary>
        /// 数据容器
        /// </summary>
        private static Dictionary<string, DataBase> _dataRoom = new Dictionary<string, DataBase>();

        /// <summary>
        /// 单例
        /// </summary>
        private static DataManager _instance = null;


        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static DataManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dataKey">数据的键</param>
        /// <param name="dataValue">数据</param>
        /// <returns>是否添加成功</returns>
        public bool addData(string dataKey, DataBase dataValue)
        {
            if (_dataRoom.ContainsKey(dataKey))
            {
                return false;
            }

            _dataRoom.Add(dataKey, dataValue);

            return true;
        }


        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="dataKey">数据的键</param>
        /// <returns>取得数据</returns>
        public DataBase getData(string dataKey)
        {
            if (_dataRoom.ContainsKey(dataKey))
            {
                return _dataRoom[dataKey];
            }
            return null;
        }


        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="dataKey">数据的键</param>
        /// <returns>是否移除成功</returns>
        public bool removeData(string dataKey)
        {
            if (_dataRoom.ContainsKey(dataKey))
            {
                _dataRoom.Remove(dataKey);
                return true;
            }

            return false;
        }


        /// <summary>
        /// 移除所有数据
        /// </summary>
        /// <returns>是否移除成功</returns>
        public bool removeAll()
        {
            foreach (string key in _dataRoom.Keys)
            {
                _dataRoom.Remove(key);
            }

            return _dataRoom.Count <= 0;
        }
    }
}
