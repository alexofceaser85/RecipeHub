using Microsoft.Data.SqlClient;
using System.Data;
using Server.Data.Database;
using Shared_Resources.Model.Users;

namespace Server.DAL.Users
{
    /// <summary>
    /// The data access layer for the users methods
    /// </summary>
    public static class UsersDal
    {
        /// <summary>
        /// Verifies the session key does not exist.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>Whether or not the session key exists</returns>
        public static bool VerifySessionKeyDoesNotExist(string sessionKey)
        {
            var query = "select \"Sessions\".sessionKey from \"Sessions\" where \"Sessions\".sessionKey = @sessionKey";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionKey", SqlDbType.VarChar).Value = sessionKey;

            connection.Open();
            return command.ExecuteScalar() == null;
        }

        /// <summary>
        /// Removes the session key.
        /// </summary>
        /// <param name="sessionKey">The session key to remove.</param>
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

        /// <summary>
        /// Checks that the user name and password combination exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Whether or not the user and password combination exists</returns>
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

        /// <summary>
        /// Adds a user session.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="sessionKey">The session key.</param>
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

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public static UserInfo? GetUserInfo(string sessionKey)
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
