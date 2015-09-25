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
            //for (int i = 2; i < row; i++)
            for (int i = 4; i < row; i++)
            {
                JsonData sub_jd = new JsonData();
                //for (int j = 0; j < col; j++)
                for (int j = 1; j < col; j++)
                {
                    var value = dt.Rows[i][j];
                    if (value == null || value.ToString() == "")
                    {
                        continue;
                    }
                    string key = dt.Rows[0][j].ToString();
                    string type = dt.Rows[1][j].ToString();

                    if (type != "int")
                    {
                        value = value.ToString().Replace('，', ',');  //中文 逗号转为 英文逗号
                    }

                    if (type == "int")
                    {
                        sub_jd[key] = Convert.ToInt32(value);
                    }
                    else if (type == "string")
                    {
                        sub_jd[key] = value.ToString();
                    }
                    else if (type == "float")
                    {
                        sub_jd[key] = Convert.ToSingle(value);
                    }
                    else if (type == "string[]" || type == "int[]")
                    {
                        JsonData d = JsonMapper.ToObject(value.ToString());
                        sub_jd[key] = d;
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
                //ConvertExcel(arrFiles[l].FullName, arrFiles[l].Name);
                ExcelToCS(arrFiles[l].FullName, arrFiles[l].Name);
                ConvertExcelToTxt(arrFiles[l].FullName, arrFiles[l].Name);
            }
        }

        public static void WriteToTxt(string fileName, string content)
        {
            if (Directory.Exists(@"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data\txt\") == false)
            {
                Directory.CreateDirectory(@"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data\txt\");
            }
            string fn = "Table_"+fileName + ".txt";
            string path = @"E:\work_A\tech\ClientNew\AProject\Assets\Resources\Data\txt\" + fn;
            //string path = "E://tables//json/" + fn;
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }

        private static void ConvertExcelToTxt(string fullPath, string fileName)
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
            string tableContent = "";
            for (int i = 0; i < row; i++)
            {
                if (i == 2 || i == 3)
                {
                    continue;
                }
                for (int j = 1; j < col; j++)
                {
                    string value = dt.Rows[i][j].ToString();
                    value = value.ToString().Replace('，', ',');  //中文 逗号转为 英文逗号
                    if (j == col - 1)
                    {
                        tableContent = tableContent + value;
                    }
                    else
                    {
                        tableContent = tableContent + value + "\t";
                    }
                }
                if (dt.Rows[i][1].ToString() == "")
                {
                    break;
                }
                else
                {
                    tableContent = tableContent + "\r\n";
                }
            }
            WriteToTxt(tableName, tableContent);
            //Console.WriteLine("--------------- " + tableContent);
            // WriteToJson(tableName, jd_root.ToJson());
        }


        private static void WriteToCS(string fileName, string content)
        {
            //string fn = fileName.Replace("xlsx", "cs");
            string path = @"E:\work_A\tech\ClientNew\AProject\Assets\Scripts\Tables\";
            string fn = fileName + ".cs";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            string csPath = path + fn;
            FileInfo fi = new FileInfo(csPath);
            StreamWriter sw = fi.CreateText();
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }
        private static void ExcelToCS(string fullPath, string fileName)
        {

            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read);
            IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            DataSet ds = dataReader.AsDataSet();
            string tableName = "Table_" + ds.Tables[0].TableName;
            object[] _files = ds.Tables[0].Rows[0].ItemArray;
            object[] _types = ds.Tables[0].Rows[1].ItemArray;
            string filed = "";

            List<string> aaa = new List<string>();

            for (int i = 1; i < _files.Length; i++)
            {

                string type = _types[i].ToString();
                if (type == "" || (_files[i].ToString())=="")
                {
                    continue;
                    Console.WriteLine("-----------------------*********************");
                }
                if (type.Contains("[]"))
                {
                    string arrType = type.Replace("[]", "");
                    filed += "\r\n\t\tpublic List<" + arrType + "> " + _files[i] + " = new List<" + arrType + ">();";
                }
                else
                {
                    filed += "\r\n\t\tpublic " + _types[i].ToString() + " " + _files[i].ToString() + ";";
                }
            }

            string className = "\tpublic class " + tableName + " \r\n\t{";
            string content = "" + strHead + className + filed + "\r\n\t} \r\n}";
            //Console.WriteLine("content  : " + content);
            WriteToCS(tableName, content);
        }
        private static string strHead = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
";
    }
}
