using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Project_Data_Logger
{
    internal class DBhandler : SqlQuery
    { 

        public bool AccessBool { get; set; }

        public string CardCode { get; set; }

        public DBhandler(string cardCode)
        {
            CardCode = cardCode;  
            AccessBool = CheckAccessAndLog(cardCode);
        }
    }
}
