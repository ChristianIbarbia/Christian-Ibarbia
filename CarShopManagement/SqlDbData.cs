using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopManagementModels;



namespace CarShopManagementData
{
    public class SqlDbData
    {
        string connectionString = "Data Source=LAPTOP-ISOMLGVB\\SQLEXPRESS; Initial Catalog=CarShopManagementSystem; Integrated Security=True;";
        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT brand, model, status FROM users";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                User readUser = new User();
                readUser.brand = reader["brand"].ToString();
                readUser.model = reader["model"].ToString();
                readUser.status = Convert.ToInt32(reader["status"]);

                users.Add(readUser);
            }

            sqlConnection.Close();
            return users;
        }

        public int AddUser(string brand, string model)
        {
            int success;
            string insertStatement = "INSERT INTO users (brand, model, status) VALUES (@brand, @model, @status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@brand", brand);
            insertCommand.Parameters.AddWithValue("@model", model);
            insertCommand.Parameters.AddWithValue("@status", 1);

            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string brand)
        {
            int success;
            string deleteStatement = "DELETE FROM users WHERE brand = @brand";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@brand", brand);

            sqlConnection.Open();
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string brand, string model, int status)
        {
            int success;
            string updateStatement = "UPDATE users SET model = @model, status = @status WHERE brand = @brand";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@brand", brand);
            updateCommand.Parameters.AddWithValue("@model", model);
            updateCommand.Parameters.AddWithValue("@status", status);

            sqlConnection.Open();
            success = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        internal int UpdateUser(string brand, string model)
        {
            throw new NotImplementedException();
        }
    }

}





