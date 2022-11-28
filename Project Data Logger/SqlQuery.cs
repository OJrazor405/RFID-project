using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data_Logger
{
    internal abstract class SqlQuery : ISqlMethods
    {
        //Get connection string with IConfigurtion
        public string connectionStrings = ConfigurationManager.ConnectionStrings["conProsjekt_245031"].ConnectionString;

        public bool CheckAccessAndLog(string cardCode)
        {
            bool access = false;

            try
            {
                SqlConnection conProject_245031 = new SqlConnection(connectionStrings);
                SqlCommand sqlCommand = new SqlCommand("uspLogAccess", conProject_245031);
                conProject_245031.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CardCode", cardCode));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    access = true;
                }
                else
                {
                    throw new Exception("User not found");
                }
                conProject_245031.Close();
            }
            catch (Exception err)
            {
                
            }

            return access;

        }
    }
}
