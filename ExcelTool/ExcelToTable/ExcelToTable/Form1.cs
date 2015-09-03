using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;
using System.IO;
using LitJson;

namespace ExcelToTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("start build ");
            return;
            ExcelToJson();
        }

        private void ConvertExcel(string fullPath, string fileName)
        {
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

        }

        private void WriteToJson(string fileName, string json)
        {
            string fn = fileName.Replace("xlsx", "json");
            if (Directory.Exists("E://tables//json/") == false)
            {
                Directory.CreateDirectory("E://tables//json/");
            }
            string path = "D://tables//json/" + fn;
            FileInfo fi = new FileInfo(path);
            StreamWriter sw = fi.CreateText();
            sw.Write(json);
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
                ConvertExcel(arrFiles[l].FullName, arrFiles[l].Name);
            }
        }

        private void JsonToClass(JsonData _jsonData)
        {

        }

    }
}
