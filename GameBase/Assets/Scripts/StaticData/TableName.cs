using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Game
{
    public class TableSkill
    {
        public int name;
        public int id;
    }


    public class TestReflection
    {
        public static void TestActivator()
        {
            LoadTxt();
        }
        /// <summary>
        /// 数据表结构， 第一行 为字段，第二行为 类型， 第一列为 id，唯一的
        /// </summary>
        /// <param name="tableName"></param>
        public static void LoadTxt(string tableName = "Name")
        {
            string txt = ResourceManager.Instance.LoadTxtTable(tableName);
            string[] aa = txt.Split(splitN, StringSplitOptions.None);
            string[] fields = aa[0].Split(splitT, StringSplitOptions.None);
            string[] types = aa[1].Split(splitT, StringSplitOptions.None);

            Dictionary<int, object> _d = new Dictionary<int, object>();
            _dict.Add(tableName, _d);

            List<object> _list = new List<object>();
            for (int i = 2; i < aa.Length - 1; i++)
            {
                string[] bb = aa[i].Split(splitT, StringSplitOptions.None);
                object o = CreatObj(tableName, fields, types, bb);
                _list.Add(o);
                _d.Add(Convert.ToInt32(o.GetType().GetField("id").GetValue(o)), o);
            }
        }

        private static Dictionary<string, Dictionary<int, object>> _dict = new Dictionary<string, Dictionary<int, object>>();

        public static Dictionary<int,object> GetTables<T>()
        {
            string tableName = typeof(T).Name;
            return _dict[tableName];
        }

        public static T GetTables<T>(int id)
        {
            string tableName = typeof(T).Name;
            T obj = (T)_dict[tableName][id];
            return obj;
        }

        private static object CreatObj(string className, string[] fields, string[] types, string[] values)
        {
            object obj = Assembly.GetExecutingAssembly().CreateInstance(className);
            Type t = obj.GetType();
            FieldInfo fiSex = t.GetField("sex");
            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                object value = values[i];
                string type = types[i];
                FieldInfo info = t.GetField(field);
                if (info != null)
                {
                    if (type == "int")
                    {
                        info.SetValue(obj, Convert.ToInt32(value));
                    }
                    else if (type == "string")
                    {
                        info.SetValue(obj, (string)value);
                    }
                }
                else
                {
                    Debug.Log("can not find field : " +  field  +"   " + field.Equals("sex"));
                }
            }
            return obj;
        }

        private static string[] splitN = new string[1] { "\r\n" };
        private static string[] splitT = new string[1] { "\t" };
    }
}
public class Name
{
    public string sex;
    public int id;
}
