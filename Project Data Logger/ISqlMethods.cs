using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data_Logger
{
    internal interface ISqlMethods
    {
        public bool CheckAccessAndLog(string cardCode);

    }
}
