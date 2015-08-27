using UnityEngine;

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 字典类
    /// @author CJC
    /// @date 2015-08
    /// </summary>
    public class XLDictionary
    {
        private string[] _texts;

        public XLDictionary(string name) 
        {
            load(name);
        }

        public string getText(int textIdx) 
        {
            if (textIdx < 0 || textIdx >= _texts.GetLength(0))
            {
                return null;
            }

            return _texts[textIdx];
        }

#if true
        private void load(string name) 
        {
#if false
            // for debug
            texts = new string[10];
            for(int i=0;i<texts.GetLength(0);i++)
            {
                texts[i] = "text" + i;            
            }
#else
            // 真实逻辑
            TextAsset ta;
            MemoryStream fs = null;
            BinaryReader br = null;

            try
            {
                ta = (TextAsset)Resources.Load(XLDictionaryMgr.DICTIONARY_PATH + name);
                fs = new MemoryStream(ta.bytes);
                br = new BinaryReader(fs);

                int textCount = br.ReadInt32();
                _texts = new string[textCount];

                for (int i = 0; i < _texts.GetLength(0); i++)
                {
                    _texts[i] = XLStreamTools.readJavaUTF(br);
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
#endif
        }
#endif

    }
}
