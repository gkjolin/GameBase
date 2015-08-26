using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class DataSource
    {
        private static DataSource _instance;

        public static DataSource Instance
        {
            get { if (_instance == null) { _instance = new DataSource(); } return _instance; }
        }

        private DataMall _dataMall;

        public DataMall DataMall
        {
            get { if (_dataMall == null) { _dataMall = new DataMall(); } return _dataMall;}
        }

        private DataLoadingTips _dataLoadingTips;

        public DataLoadingTips DataLoadingTips
        {
            get { if (_dataLoadingTips == null) { _dataLoadingTips = new DataLoadingTips(); } return _dataLoadingTips; }
        }

        public void InitData()
        {

        }
    }
}
