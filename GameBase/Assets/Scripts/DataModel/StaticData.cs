using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
namespace Game
{
    public class StaticData
    {

        private static Dictionary<string, JsonData> _dict = new Dictionary<string, JsonData>();
        /// <summary>
        /// 获取整个数据表内容
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static JsonData GetTable(string tableName)
        {
            JsonData _jd = null;
            if(_dict.ContainsKey(tableName))
            {
                _jd = _dict[tableName];
            }else
            {
                _jd = JsonMapper.ToObject(ResourceManager.Instance.LoadTxtTable(tableName));
            }
            return _jd;
        }
        /// <summary>
        /// 获取数据表某一行的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="rowName"></param>
        /// <returns></returns>
        public static JsonData GetRow(string tableName,string rowName)
        {
            JsonData table = GetTable(tableName);
            JsonData row = table[rowName];
            return row;
        }
        /// <summary>
        /// 获取数据表某行某列的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="rowName"></param>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public static JsonData GetCell(string tableName,string rowName,string cellName)
        {
            JsonData table = GetTable(tableName);
            JsonData cell = table[rowName][cellName];
            return cell;
        }
    }
}
