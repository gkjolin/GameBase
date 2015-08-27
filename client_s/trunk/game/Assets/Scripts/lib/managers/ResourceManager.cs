using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public class ResourceManager
    {

        /// <summary>
        /// 资源容器
        /// </summary>
        private static Dictionary<string, GameObject> _resourceRoom = new Dictionary<string, GameObject>();

        /// <summary>
        /// 单例
        /// </summary>
        private static ResourceManager _instance = null;


        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static ResourceManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new ResourceManager();
            }
            return _instance;
        }


        /// <summary>
        /// 添加一个资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool addResource(string name, GameObject obj)
        {
            //如果已经存在同名资源，返回添加失败
            if (_resourceRoom.ContainsKey(name))
            {
                return false;
            }

            //根据key把obj添加到关联数组
            _resourceRoom.Add(name, obj);

            return true;
        }

        /// <summary>
        /// 根据资源名取得资源
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject getResource(string name)
        {
            if (_resourceRoom.ContainsKey(name))
            {
                return _resourceRoom[name];
            }
            return null;
        }

        /// <summary>
        /// 根据资源名移除资源
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool removeResource(string name)
        {
            if (_resourceRoom.ContainsKey(name))
            {
                _resourceRoom.Remove(name);
                return true;
            }

            return false;
        }


        /// <summary>
        /// 移除所有资源
        /// </summary>
        /// <returns></returns>
        public bool removeAll()
        {
            foreach (string key in _resourceRoom.Keys)
            {
                _resourceRoom.Remove(key);
            }

            return _resourceRoom.Count <= 0;
        }


        /// <summary>
        /// 取得预制件
        /// </summary>
        /// <param name="prefabName">预制件名</param>
        /// <returns></returns>
        public GameObject getGameObject(string prefabName)
        {
            GameObject gameObj = Resources.Load<GameObject>(prefabName);
            if (gameObj == null)
            {
                int a = 0;
            }
            return GameObject.Instantiate(gameObj) as GameObject;
        }

    }
}
