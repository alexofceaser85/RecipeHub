using Microsoft.Data.SqlClient;
using System.Data;
using Server.Data.Database;
using Shared_Resources.Model.Users;

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

        public static void RemoveSessionKey(string sessionKey)
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

        public static UserInfo GetUserInfo(string sessionKey)
        {
            var query = "select Users.userName, Users.firstName, Users.lastName, Users.email from \"Sessions\", Users where \"Sessions\".sessionKey = @sessionKey and Users.userId = \"Sessions\".userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionKey", SqlDbType.VarChar).Value = sessionKey;
            connection.Open();

            using var reader = command.ExecuteReader();

            var userNameOrdinal = reader.GetOrdinal("userName");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var emailOrdinal = reader.GetOrdinal("email");
            while (reader.Read())
            {
                var userName = reader.GetString(userNameOrdinal);
                var firstName = reader.GetString(firstNameOrdinal);
                var lastName = reader.GetString(lastNameOrdinal);
                var email = reader.GetString(emailOrdinal);

                return new UserInfo(userName, firstName, lastName, email);
            }

            return null;
        }
    }
}
