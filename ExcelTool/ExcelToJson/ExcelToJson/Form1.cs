using Excel;
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
using LitJson;

namespace ExcelToJson
{
    public partial class Form1 : Form
    {

        private static bool isXls = false;
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("start build ");
            //ExcelToJson();
        }
        //第一列 第三行 第四行是注释
        private static void ConvertExcel(string fullPath, string fileName)
        {
            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader dataReader;
            if (isXls)
            {
                dataReader = ExcelReaderFactory.CreateBinaryReader(fs);
            }
            else
            {
                dataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            }
            DataSet ds = dataReader.AsDataSet();
            string tableName = ds.Tables[0].TableName;
            DataTable dt = ds.Tables[0];
            int row = dt.Rows.Count;
            int col = dt.Columns.Count;

            JsonData jd_root = new JsonData();
            //jd_root["name"] = tableName;
            //for (int i = 2; i < row; i++)
            for (int i = 4; i < row; i++)
            {
                JsonData sub_jd = new JsonData();
                //for (int j = 0; j < col; j++)
                for (int j = 1; j < col; j++)
                {
                    object value = dt.Rows[i][j];
                    if (value == null || value.ToString() == "")
                    {
                        break;
                    }
                    string key = dt.Rows[0][j].ToString();
                    string type = dt.Rows[1][j].ToString();
                    if (type == "int")
                    {
                        sub_jd[key] = Convert.ToInt32(value);
                    }
                    else if (type == "string")
                    {
                        sub_jd[key] = value.ToString();
                    }else if(type == "float")
                    {
                        sub_jd[key] = Convert.ToSingle(value);
                    }
                }
                string id = ds.Tables[0].Rows[i][1].ToString();
                if (id == "") break;
                jd_root[id] = sub_jd;
            }

            WriteToJson(tableName, jd_root.ToJson());

        }

        private static void WriteToJson(string fileName, string json)
        {
            if (Directory.Exists(@"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data") == false)
            {
                Directory.CreateDirectory(@"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data");
            }
            string fn = fileName + ".txt";
            string path = @"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data\" + fn;
            //string path = "E://tables//json/" + fn;
            

            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(json);
            sw.Close();
            sw.Dispose();

            /*StreamWriter sw1 = new StreamWriter("E://tables//json//aa.txt", false, Encoding.UTF8);
            sw1.Write(json);
            sw1.Close();*/


            /*FileStream fs = File.Open("E://tables//json//b.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string s = "use filestream write 使用 fileStream 创建文件";
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(s);
            fs.Write(bs, 0, bs.Length);
            fs.Close();*/
        }

        public static void ExcelToJson()
        {
            //string directory_url = "E:\\tables\\";
            string directory_url = @"E:\work_A\design\03数值设计\00data";
            DirectoryInfo _directoryInfo = new DirectoryInfo(directory_url);
            string extend = isXls ? "*.xls" : "*.xlsx";
            FileInfo[] arrFiles = _directoryInfo.GetFiles(extend, SearchOption.TopDirectoryOnly);
            for (int l = 0; l < arrFiles.Length; l++)
            {
                Console.WriteLine("file name : " + arrFiles[l].Name);
                ConvertExcel(arrFiles[l].FullName, arrFiles[l].Name);
            }
        }
    }
}
