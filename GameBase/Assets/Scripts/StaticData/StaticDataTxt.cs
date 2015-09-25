using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Game
{
    public class StaticDataTxt
    {
        private static Dictionary<string, Dictionary<int, object>> _dict = new Dictionary<string, Dictionary<int, object>>();
        public static Dictionary<int, object> GetTables<T>()
        {
            string tableName = typeof(T).Name;
            Dictionary<int, object> _d;
            if (!_dict.ContainsKey(tableName))
            {
                _d = LoadTxt(tableName);
            }
            else
            {
                _d = _dict[tableName];
            }

            return _d;
        }

        public static T GetTableRow<T>(int id)
        {
            Dictionary<int, object> _d = GetTables<T>();
            T obj = (T)_d[id];
            return obj;
        }

        public static void TestActivator()
        {
            //LoadTxt();
            //Table_Character cha = GetTableRow<Table_Character>(13)
            //GameInput.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>????? " + cha.description);
        }
        /// <summary>
        /// 数据表结构， 第一行 为字段，第二行为 类型， 第一列为 id，唯一的
        /// </summary>
        /// <param name="tableName"></param>
        private static Dictionary<int, object> LoadTxt(string tableName = "Name")
        {
            string txt = ResourceManager.Instance.LoadTxtTable("txt/" + tableName);
            string[] aa = txt.Split(splitN, StringSplitOptions.None);
            string[] fields = aa[0].Split(splitT, StringSplitOptions.None);
            string[] types = aa[1].Split(splitT, StringSplitOptions.None);

            Dictionary<int, object> _d = new Dictionary<int, object>();
            _dict.Add(tableName, _d);


            for (int i = 2; i < aa.Length - 1; i++)
            {
                string[] bb = aa[i].Split(splitT, StringSplitOptions.None);
                if (bb[0] == "")
                {
                    continue;
                }
                object o = CreatObj(tableName, fields, types, bb);
                _d.Add(Convert.ToInt32(o.GetType().GetField("id").GetValue(o)), o);
            }
            return _d;
        }


        private static object CreatObj(string className, string[] fields, string[] types, string[] values)
        {
            object obj = Assembly.GetExecutingAssembly().CreateInstance("Game." + className);
            Type t = obj.GetType();
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
                    else if (type == "float")
                    {
                        info.SetValue(obj, Convert.ToSingle(value));
                    }
                    else if (type == "int[]")
                    {
                        List<int> _list = new List<int>();
                        string[] arr = value.ToString().Split('|');
                        for (int ii = 0; ii < arr.Length; i++)
                        {
                            int v = Convert.ToInt32(arr[ii]);
                            _list.Add(v);
                        }
                        info.SetValue(obj, _list);
                    }
                    else if (type == "string[]")
                    {
                        List<string> _list = new List<string>();
                        string[] arr = value.ToString().Split('|');
                        for (int ii = 0; ii < arr.Length; i++)
                        {
                            string v = arr[ii].ToString();
                            _list.Add(v);
                        }
                        info.SetValue(obj, _list);
                    }
                    else if (type == "float[]")
                    {
                        List<float> _list = new List<float>();
                        string[] arr = value.ToString().Split('|');
                        for (int ii = 0; ii < arr.Length; i++)
                        {
                            float v = Convert.ToSingle(arr[ii]);
                            _list.Add(v);
                        }
                        info.SetValue(obj, _list);
                    }
                }
            }
            return obj;
        }

        private static string[] splitN = new string[1] { "\r\n" };
        private static string[] splitT = new string[1] { "\t" };
    }
}
