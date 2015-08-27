using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib
{
    /// <summary>
    /// 字典管理器类
    /// @author CJC
    /// @date 2015-08
    /// </summary>
    public class XLDictionaryMgr
    {
        /// <summary>
        /// 字典路径
        /// </summary>
        public static readonly string DICTIONARY_PATH = "Bin/Dictionary/";

        /// <summary>
        /// 一个bin能拥有字符串数目的最大值
        /// </summary>
        private static int MAX_TEXT_COUNT_PER_DICTIONARY = 10000;

        /// <summary>
        /// 单例对象
        /// </summary>
        private static XLDictionaryMgr g_instance = null;

        /// <summary>
        /// 字典数量
        /// </summary>
        private int _dictionaryCount;

        /// <summary>
        /// 全部字典的名称
        /// </summary>
        private string[] _dictionaryNames;

        /// <summary>
        /// 全部字典
        /// </summary>
        private XLDictionary[] _dictionarys;

        /// <summary>
        /// 获取单利对象
        /// </summary>
        /// <returns></returns>
        public static XLDictionaryMgr getInstance()
        {
            if (g_instance==null)
            {
                g_instance = new XLDictionaryMgr();
            }
            
            return g_instance;
        }

        /// <summary>
        /// 构造
        /// </summary>
        private XLDictionaryMgr()
        {
            // 真实逻辑
            TextAsset ta;
            MemoryStream fs = null;
            BinaryReader br = null;

            try
            {
                ta = (TextAsset)Resources.Load(XLDictionaryMgr.DICTIONARY_PATH + "DictionaryMgr");
                fs = new MemoryStream(ta.bytes);
                br = new BinaryReader(fs);

                _dictionaryCount = br.ReadInt32();
                _dictionaryNames = new string[_dictionaryCount];
                _dictionarys = new XLDictionary[_dictionaryCount];

                for (int i = 0; i < _dictionaryCount; i++)
                {
                    _dictionaryNames[i] = XLStreamTools.readJavaUTF(br);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            finally
            {
                if (br != null)
                {
                    br.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 根据id获取字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getTextById(int id)
        {
            if(id < 0)
            {
                Debug.Log("id must more than 0");
                return null;
            }

            int dictionaryIdx = id / MAX_TEXT_COUNT_PER_DICTIONARY;
            if (dictionaryIdx >= _dictionaryCount)
            {
                Debug.Log("id is too big");
                return null;
            }

            int textIdx = id % MAX_TEXT_COUNT_PER_DICTIONARY;
            if(_dictionarys[dictionaryIdx] == null) 
            {
                if(!loadDictionary(dictionaryIdx))
                {
                    return null;
                }
            }

            return _dictionarys[dictionaryIdx].getText(textIdx);
        }

        /// <summary>
        /// 载入字典
        /// </summary>
        /// <param name="dictionaryIdx"></param>
        /// <returns></returns>
        private bool loadDictionary(int dictionaryIdx) 
        {
            string name = _dictionaryNames[dictionaryIdx];
            _dictionarys[dictionaryIdx] = new XLDictionary(name);
            return true;
        }

        /// <summary>
        /// 释放字典
        /// </summary>
        /// <param name="dictionaryIdx"></param>
        /// <returns></returns>
        public bool releaseDictionary(int dictionaryIdx) 
        {
            _dictionarys[dictionaryIdx] = null;
            return true;
        }
    }

}
