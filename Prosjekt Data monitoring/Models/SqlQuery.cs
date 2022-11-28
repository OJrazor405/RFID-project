using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Prosjekt_Data_monitoring.Models
{
    public class SqlQuery : ISqlMethods
    {
        public string ConProjectDb;
        public SqlQuery(IConfiguration configuration)
        {
            ConProjectDb = configuration.GetConnectionString("ConnectionToProjectDb");
        }

        public bool CheckAccessAndLog(int userId, string password)
        {
            bool access = false;
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                SqlCommand sqlCommand = new SqlCommand("uspLoginAccess", conProjectDb);
                conProjectDb.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", password));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    access = true;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
            return access;

        }

        public int GetAccessLevel(int userId)
        {
            int accessLevel = 0;
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                SqlCommand sqlCommand = new SqlCommand("uspGetAccessLevel", conProjectDb);
                conProjectDb.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    accessLevel = Convert.ToInt32(dr[0]);
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
            return accessLevel;
        }

        public List<User> GetLog(string view)
        {
            string sqlSelect;
            List<User> userList = new List<User>();
            try
            {
                sqlSelect = "SELECT * FROM " + view + " ORDER BY TimeStamp DESC";
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                conProjectDb.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlSelect, conProjectDb);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    User user = new User();
                    user.UserId = (int)dr["UserId"];
                    user.TimeStamp = (DateTime)dr["TimeStamp"];
                    user.FirstName = (string)dr["FirstName"];
                    user.LastName = (string)dr["LastName"];
                    userList.Add(user);
                }
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
            return userList;
        }

        public int GetNextUserId()
        {
            int nextUserId = -1;
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                conProjectDb.Open();
                SqlCommand sqlCommand = new SqlCommand("uspGetNextUserId", conProjectDb);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = sqlCommand.ExecuteReader();
                dr.Read();
                nextUserId = Convert.ToInt16(dr[0]) + 1;
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
            return nextUserId;
        }

        public void CreateNewUser(User user)
        {
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                SqlCommand sqlCommand = new SqlCommand("uspCreateNewUser", conProjectDb);
                conProjectDb.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", user.UserId));
                sqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@Address", user.Address));
                sqlCommand.Parameters.Add(new SqlParameter("@PostalCode", user.PostalCode));
                sqlCommand.Parameters.Add(new SqlParameter("@AccessLevel", user.AccessLevel));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", user.Password));
                sqlCommand.Parameters.Add(new SqlParameter("@CardCode", user.CardCode));
                sqlCommand.ExecuteNonQuery();
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
        }

        public User GetUserData(int userId)
        {
            User user = new User();
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                conProjectDb.Open();
                SqlCommand sqlCommand = new SqlCommand("uspGetUserToEdit", conProjectDb);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    user.UserId = (int)dr["UserId"];
                    user.FirstName = (string)dr["FirstName"];
                    user.LastName = (string)dr["LastName"];
                    user.PhoneNumber = (int)dr["PhoneNumber"];
                    user.PostalCode = (int)dr["PostalCode"];
                    user.AccessLevel = (int)dr["LevelId"];
                    user.Address = (string)dr["Address"];
                    user.Password = (string)dr["UserPassword"];
                    user.CardCode = (string)dr["CardNumber"];
                }
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
            return user;
        }
        public void EditUser(User user)
        {
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                SqlCommand sqlCommand = new SqlCommand("uspEditUser", conProjectDb);
                conProjectDb.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", user.UserId));
                sqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@Address", user.Address));
                sqlCommand.Parameters.Add(new SqlParameter("@PostalCode", user.PostalCode));
                sqlCommand.Parameters.Add(new SqlParameter("@AccessLevel", user.AccessLevel));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", user.Password));
                sqlCommand.Parameters.Add(new SqlParameter("@CardCode", user.CardCode));
                sqlCommand.ExecuteNonQuery();
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                SqlConnection conProjectDb = new SqlConnection(ConProjectDb);
                SqlCommand sqlCommand = new SqlCommand("uspDeleteUser", conProjectDb);
                conProjectDb.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));
                sqlCommand.ExecuteNonQuery();
                conProjectDb.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
