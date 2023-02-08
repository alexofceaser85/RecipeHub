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
        //TODO This whole method is a service level
        public static string Login(string username, string password)
        {
            var userId = verifyUserNameAndPasswordCombination(username, password);
            if (userId == null)
            {
                throw new ArgumentException("user name and password combo is wrong");
            }

            if (!verifyNoCurrentUserSessions(userId.Value))
            {
                throw new ArgumentException("Session already exists");
            }
            var sessionKey = generateNewSessionKey();
            addUserSession(userId.Value, sessionKey);
            return sessionKey;
        }

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

        public static int? verifyUserNameAndPasswordCombination(string username, string password)
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

        public static bool verifyNoCurrentUserSessions(int userId)
        {
            var query = "select \"Sessions\".userId from \"Sessions\" where \"Sessions\".userId = @userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            return command.ExecuteScalar() == null;
        }

        public static void addUserSession(int userId, string sessionKey)
        {
            var query = "insert into Sessions(sessionKey, userId) values(@sessionkey, @userId)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionkey", SqlDbType.VarChar).Value = sessionKey;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            command.ExecuteNonQuery();
        }

        private static string generateNewSessionKey()
        {
            var random = new Random();
            var length = 50;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomKey = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var hashedKey = hashPassword(randomKey);

            if (!VerifySessionKeyDoesNotExist(hashedKey))
            {
                return generateNewSessionKey();
            }

            return hashedKey;
        }

        private static string hashPassword(string passwordToHash)
        {
            using HashAlgorithm algorithm = SHA512.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
            var builder = new StringBuilder();
            foreach (var passwordByte in bytes)
            {
                builder.Append(passwordByte.ToString("x2"));
            }
            var hashedPassword = builder.ToString();
            return hashedPassword;
        }
    }
}
