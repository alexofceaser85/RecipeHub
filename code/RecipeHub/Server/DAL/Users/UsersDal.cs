using Microsoft.Data.SqlClient;
using System.Data;
using Server.Data.Database;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Server.DAL.Users
{
    public static class UsersDal
    {
        public static bool VerifySessionKeyDoesNotExist(string sessionKey)
        {
            var query = "select \"Sessions\".sessionKey from \"Sessions\" where \"Sessions\".sessionKey = @sessionKey";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionKey", SqlDbType.VarChar).Value = sessionKey;

            connection.Open();
            return command.ExecuteScalar() == null;
        }

        public static void Logout(string sessionKey)
        {
            var query =
                "delete from \"Sessions\" where \"Sessions\".sessionKey = @sessionKey";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionKey", SqlDbType.VarChar).Value = sessionKey;
            connection.Open();
            command.ExecuteNonQuery();
        }

        public static int? VerifyUserNameAndPasswordCombination(string username, string password)
        {
            var query =
                "select " +
                "  Users.userId " +
                "from Users " +
                "where " +
                "   Users.userName=@username " +
                "and exists (" +
                "               select " +
                "                   Passwords.userId " +
                "               from Passwords " +
                "               where " +
                "                   Passwords.userId = Users.userId " +
                "                   and Passwords.\"password\" = @password" +
                "           )";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            connection.Open();
            using var reader = command.ExecuteReader();

            var userIdOrdinal = reader.GetOrdinal("userId");
            while (reader.Read())
            {
                return reader.GetInt32(userIdOrdinal);
            }

            return null;
        }

        public static bool VerifyNoCurrentUserSessions(int userId)
        {
            var query = "select \"Sessions\".userId from \"Sessions\" where \"Sessions\".userId = @userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            return command.ExecuteScalar() == null;
        }

        public static void AddUserSession(int userId, string sessionKey)
        {
            var query = "insert into Sessions(sessionKey, userId) values(@sessionkey, @userId)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionkey", SqlDbType.VarChar).Value = sessionKey;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
