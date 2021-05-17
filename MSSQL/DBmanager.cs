using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DBmanager
    {
        private readonly string Connstr = "Data Source=AA122-PC70\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";

        public List<MS_PRODUCT> GetPRODUCTs()
        {
            List<MS_PRODUCT> ms_products = new List<MS_PRODUCT>();
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MS_PRODUCT");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MS_PRODUCT ms_product = new MS_PRODUCT
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        NAME = reader.GetString(reader.GetOrdinal("NAME")),
                        PRICE = reader.GetInt32(reader.GetOrdinal("PRICE")),
                        QUANTITY = reader.GetInt32(reader.GetOrdinal("QUANTITY")),
                    };
                    ms_products.Add(ms_product);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return ms_products;
        }

        public void Create(MS_PRODUCT mS_PRODUCT)
        {
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO MS_PRODUCT(ID, NAME, PRICE, QUANTITY)
                VALUES(@ID, @NAME, @PRICE, @QUANTITY);");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ID", mS_PRODUCT.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@NAME", mS_PRODUCT.NAME));
            sqlCommand.Parameters.Add(new SqlParameter("@PRICE", mS_PRODUCT.PRICE));
            sqlCommand.Parameters.Add(new SqlParameter("@QUANTITY", mS_PRODUCT.QUANTITY));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public MS_PRODUCT GetID(int id)
        {
            MS_PRODUCT ms_product = new MS_PRODUCT();
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MS_PRODUCT WHERE ID = @ID");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ms_product = new MS_PRODUCT
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    NAME = reader.GetString(reader.GetOrdinal("NAME")),
                    PRICE = reader.GetInt32(reader.GetOrdinal("PRICE")),
                    QUANTITY = reader.GetInt32(reader.GetOrdinal("QUANTITY"))
                };
            }
            sqlConnection.Close();
            return ms_product;
        }

        public void UpdateProduct(MS_PRODUCT mS_PRODUCT)
        {
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE MS_PRODUCT SET NAME = @NAME, PRICE = @PRICE, QUANTITY = @QUANTITY WHERE ID = @ID");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@NAME", mS_PRODUCT.NAME));
            sqlCommand.Parameters.Add(new SqlParameter("@PRICE", mS_PRODUCT.PRICE));
            sqlCommand.Parameters.Add(new SqlParameter("@QUANTITY", mS_PRODUCT.QUANTITY));
            sqlCommand.Parameters.Add(new SqlParameter("@ID", mS_PRODUCT.ID));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        
        public void DeleteProduct(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(Connstr);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM MS_PRODUCT WHERE ID = @ID");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ID", id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
