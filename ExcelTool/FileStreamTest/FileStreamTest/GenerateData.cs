using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace FileStreamTest
{
    public class GenerateData
    {
        public static void TestActivator()
        {
            object obj = Assembly.GetExecutingAssembly().CreateInstance("TT");
            Type t = obj.GetType();
            for (int i = 0; i < 1; i++)
            {
                object o = Activator.CreateInstance(t);
                FieldInfo[] fields = t.GetFields();
                for (int j = 0; j < fields.Length; j++)
                {
                    string fieldName = fields[j].Name;
                    FieldInfo fi = fields[j];
                    fi.SetValue(o, j);
                }
            }
            Type tt = Assembly.GetExecutingAssembly().GetType("TT");
            //Dictionary<int, tt> _dict = GeneDic<tt>();
        }

        public static void Generate()
        {
            string directory_url = @"E:\tables\";
            DirectoryInfo _directoryInfo = new DirectoryInfo(directory_url);
            FileInfo[] arrFiles = _directoryInfo.GetFiles("*.xlsx", SearchOption.TopDirectoryOnly);
            for (int l = 0; l < arrFiles.Length; l++)
            {
                string fullName = arrFiles[l].FullName;
                string className = arrFiles[l].Name.Substring(0, arrFiles[l].Name.Length - 5);
                FileStream fs = File.Open(fullName, FileMode.Open);
                IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                DataSet ds = dataReader.AsDataSet();

                object obj = Assembly.GetExecutingAssembly().CreateInstance("Game." + className);
                Type t = Assembly.GetExecutingAssembly().GetType("Game." + className);

                int rowCount = ds.Tables[0].Rows.Count;
                for (int i = 2; i < rowCount; i++)
                {
                    object o = Activator.CreateInstance(t);

                    object[] _classData = ds.Tables[0].Rows[i].ItemArray;
                    for (int j = 0; j < _classData.Length; j++)
                    {

                        object value = _classData[j];
                        string key = ds.Tables[0].Rows[0][j].ToString();
                        string type = ds.Tables[0].Rows[1][j].ToString();
                        Console.WriteLine("key : " + key + "  type : " + type + "  value : " + value);
                        FieldInfo fi = t.GetField(key);
                        if (fi != null && value != null)
                        {
                            if (type == "int")
                            {
                                fi.SetValue(o, Convert.ToInt16(value));
                            }
                            else if (type == "string")
                            {
                                fi.SetValue(o, value.ToString());
                            }
                        }
                    }

                    List<object> _list;
                    if (_dict.ContainsKey(className))
                    {
                        _list = _dict[className];
                    }
                    else
                    {
                        _list = new List<object>();
                        _dict.Add(className, _list);
                    }

                    _list.Add(o);

                    Dictionary<int, object> _dictSub;
                    if(_dict2.ContainsKey(className))
                    {
                        _dictSub = _dict2[className];
                    }
                    else
                    {
                        _dictSub = new Dictionary<int, object>();
                        _dict2.Add(className, _dictSub);
                    }
                    _dictSub.Add((int)o.GetType().GetField("id").GetValue(o),o);
                }
            }

            name n = GetData<name>(0);
            Console.WriteLine(">>>>>>>>>>>>>>>>> : " + n.nameDes);

            tips tip = GetData2<tips>(19);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> : " + _dict2.ToString());

            //_dict2.ToString()
        }

        private static Dictionary<string, List<object>> _dict = new Dictionary<string, List<object>>();
        private static Dictionary<string, Dictionary<int, object>> _dict2 = new Dictionary<string, Dictionary<int, object>>();

        public static T GetData<T>(int id)
        {
            string type = typeof(T).Name;
            T t = (T)_dict[type][id];
            return t;
        }

        public static T GetData2<T>(int id)
        {
            string type = typeof(T).Name;
            Dictionary<int,object> _d = _dict2[type];
            T t = (T)_d[id];
            return t;
        }

        public static Dictionary<int,object> GetAllRow<T>()
        {
            string type = typeof(T).Name;
            Dictionary<int, object> _d = _dict2[type];
            return _d;
        }
    }
}
