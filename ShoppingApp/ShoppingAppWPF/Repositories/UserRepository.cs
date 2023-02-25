using Chevalier.Utility.Authentication;
using Microsoft.Data.SqlClient;
using ShoppingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.Repositories
{
    class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["StoreDatabase"].ConnectionString;
        }

        public bool UserExists(string username)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(Username) from dbo.Users WHERE Username = @Username";

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public User GetUser(string username)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Username, PasswordSalt, PasswordHash, Name "
                + "FROM dbo.Users WHERE Username = @Username";

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextUser(reader);
            return null;
        }

        private User ReadNextUser(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            byte[] salt = (byte[])reader.GetValue(2);
            byte[] hash = (byte[])reader.GetValue(3);
            string name = reader.GetString(4);

            HashedPassword password = new HashedPassword(salt, hash);
            return new User(username, password, name);
        }
    }
}
