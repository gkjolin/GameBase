using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
namespace Game
{
    public class DataLoadingTips
    {
        private JsonData _data;

        public JsonData Data
        {
            get
            {
                if (_data == null)
                {
                    _data = StaticData.GetTable("LoadingTips");
                }
                return _data;
            }
        }

        public string GetRandomTip()
        {
            JsonData _jd = Data["tips"];
            string s = String.Empty;
            int count = _jd.Count;
            Random r = new Random();
            int randomNum = r.Next(0, count);
            s = _jd[randomNum].ToString();
            return s;
        }
    }
}
