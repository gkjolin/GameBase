using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// Excel二进制数值读取功能类
    /// @author CJC
    /// @date 2015-07
    /// </summary>
    public class XLExcelReadAble
    {
        /// <summary>
        /// bin文件所在目录
        /// </summary>
        private static readonly string BIN_DIR = "Bin/";

        /// <summary>
        /// 读取excel的数据VO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool readVO<T>(IList<T> list, string name)
        {
            TextAsset ta;
            MemoryStream fs = null;
            BinaryReader br = null;

            try
            {
                ta = (TextAsset)Resources.Load(BIN_DIR + name);
                fs = new MemoryStream(ta.bytes);
                br = new BinaryReader(fs);

                int rowCount = br.ReadInt32();
                int colCount = br.ReadInt32();

                for (int r = 0; r < rowCount; r++)
                {
                    // 获取当前程序集 
                    Assembly assembly = Assembly.GetExecutingAssembly();

                    //根据对象名创建对象
                    XLExcelBinBase vo = assembly.CreateInstance(name) as XLExcelBinBase;

                    // 读取数据
                    vo.read(br);

                    // 添加到结果list中
                    T t = (T)vo;
                    list.Add(t);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return false;
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

            return true;
        }
    }
}
