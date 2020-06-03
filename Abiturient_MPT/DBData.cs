using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abiturient_MPT
{
    [Serializable]
    public class DBData
    {
        public string controlString = "ControlString";
        public bool isLocal { get; set; }
        public string dataSource { get; set; }
        public string dataBase { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        //public string iv { get; set; }
        //public DBData (string _dataSource, string _dataBase, string _user, string _pass)
        //{
        //    dataSource = _dataSource;
        //    dataBase = _dataBase;
        //    user = _user;
        //    pass = _pass;
        //}

        public int update(string _dataSource, string _dataBase, string _user, string _pass, bool _isLocal, string iv)
        {
            isLocal = _isLocal;
            dataSource = _dataSource;
            dataBase = _dataBase;
            user = _user;
            pass = _pass;
            return 0;
        }
    }
}
