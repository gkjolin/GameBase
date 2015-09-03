using Excel;
using LitJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileStreamTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ExcelToJson();
            TestType.Test2();
        }

        private T ConvertExcel<T>(string fullPath, string fileName)
        {
            T t=Activator.CreateInstance<T>();
            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            DataSet ds = dataReader.AsDataSet();
            int row = ds.Tables[0].Rows.Count;
            JsonData jd_root = new JsonData();
            jd_root["name"] = fileName.Substring(0, fileName.Length - 5);
            for (int i = 2; i < row; i++)
            {
                JsonData sub_jd = new JsonData();
                var obj = ds.Tables[0].Rows[i];
                object[] arr_objs = obj.ItemArray;
                for (int j = 0; j < arr_objs.Length; j++)
                {
                    object value = arr_objs[j];
                    string key = ds.Tables[0].Rows[0][j].ToString();
                    string type = ds.Tables[0].Rows[1][j].ToString();

                    //t.GetType()

                    if (type == "int")
                    {
                        sub_jd[key] = Convert.ToInt32(value);
                    }
                    else if (type == "string")
                    {
                        sub_jd[key] = Convert.ToString(value);
                    }
                }
                jd_root[ds.Tables[0].Rows[i][0].ToString()] = sub_jd;
            }

            WriteToJson(fileName, JsonMapper.ToJson(jd_root));

            return t;
        }

        private void WriteToJson(string fileName, string json)
        {
            string fn = fileName.Replace("xlsx", "json");
            if (Directory.Exists("E://tables//json/") == false)
            {
                Directory.CreateDirectory("E://tables//json/");
            }
            string path = "E://tables//json/" + fn;
            FileInfo fi = new FileInfo(path);
            StreamWriter sw = fi.CreateText();
            sw.Write(json);
            sw.Close();
            sw.Dispose();
        }

        private void WriteToCS(string fileName,string content)
        {
            string fn = fileName.Replace("xlsx", "cs");
            if (Directory.Exists("E://tables//class/") == false)
            {
                Directory.CreateDirectory("E://tables//class/");
            }
            string path = "E://tables//class/" + fn;
            FileInfo fi = new FileInfo(path);
            StreamWriter sw = fi.CreateText();
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }

        private void ExcelToJson()
        {
            string directory_url = "E:\\tables\\";
            DirectoryInfo _directoryInfo = new DirectoryInfo(directory_url);
            FileInfo[] arrFiles = _directoryInfo.GetFiles("*.xlsx", SearchOption.TopDirectoryOnly);
            for (int l = 0; l < arrFiles.Length; l++)
            {
                Console.WriteLine("file name : " + arrFiles[l].Name);
                //ConvertExcel(arrFiles[l].FullName, arrFiles[l].Name);
                ExcelToCS(arrFiles[l].FullName, arrFiles[l].Name);
            }
        }

        private void ExcelToCS( string fullPath, string fileName)
        {

            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            DataSet ds = dataReader.AsDataSet();

            object[] _files = ds.Tables[0].Rows[0].ItemArray;
            object[] _types = ds.Tables[0].Rows[1].ItemArray;
            string filed = "";
            for (int i = 0; i < _files.Length; i++)
            {
                filed += "public " + _types[i] + " " + _files[i] + ";";
            }

            string className = @"public class " + fileName.Substring(0, fileName.Length - 5) + " {";
            string content = @"" + strHead + className + filed + "} }";
            Console.WriteLine("content  : " + content);
            WriteToCS(fileName, content);
        }
        private string strHead = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
"; 

    }
}


/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class TableName
    {
        public int id;
        public string name;
    }
}
*/