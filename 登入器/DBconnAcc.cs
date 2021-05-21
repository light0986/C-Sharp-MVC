using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DBconnAcc
    {
        private readonly string Connstr = "Data Source=AA122-PC70\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";

        public void CreateAcc(MS_ACCOUNT mS_ACCOUNT) //新增帳號
        {
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO MS_ACCOUNT(ACCOUNT,PASSWORD)
                VALUES(@ACCOUNT, @PASSWORD);");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ACCOUNT", mS_ACCOUNT.ACCOUNT));
            sqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", mS_ACCOUNT.PASSWORD));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool CheckUserData(string account, string password)
        {
            MS_ACCOUNT ms_account = new MS_ACCOUNT();
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM MS_ACCOUNT WHERE ACCOUNT = @ACCOUNT AND PASSWORD = @PASSWORD");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ACCOUNT", account));
            sqlCommand.Parameters.Add(new SqlParameter("@PASSWORD", password));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }
    }
}
