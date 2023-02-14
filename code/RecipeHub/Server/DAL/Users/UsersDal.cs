using Microsoft.Data.SqlClient;
using System.Data;
using Server.Data.Settings;
using Shared_Resources.Model.Users;

namespace Server.DAL.Users
{
    /// <summary>
    /// The data access layer for the users methods
    /// </summary>
    public class UsersDal : IUsersDal
    {
        /// <summary>
        /// Creates an account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="accountToCreate">The account to create.</param>
        public void CreateAccount(NewAccount accountToCreate)
        {
            var query = "INSERT INTO Users(userName, firstName, lastName, email) " +
                        "VALUES(@username, @firstName, @lastName, @email);" +
                        "INSERT INTO Passwords " +
                        "VALUES((SELECT SCOPE_IDENTITY()), @password);";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = accountToCreate.Username;
            command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = accountToCreate.FirstName;
            command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = accountToCreate.LastName;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = accountToCreate.Email;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = accountToCreate.Password;

            connection.Open();
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Verifies the user name does not exist.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// Whether or not the username exists
        /// </returns>
        public bool CheckIfUserNameExists(string userName)
        {
            var query = "select \"Users\".username from \"Users\" where \"Users\".username = @username";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;

            connection.Open();
            return command.ExecuteScalar() != null;
        }

        /// <summary>
        /// Verifies the session key does not exist.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>Whether or not the session key exists</returns>
        public bool VerifySessionKeyDoesNotExist(string sessionKey)
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
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key to remove.</param>
        public void RemoveSessionKey(string sessionKey)
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
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Whether or not the user and password combination exists</returns>
        public int? VerifyUserNameAndPasswordCombination(string username, string password)
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
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="sessionKey">The session key.</param>
        public void AddUserSession(int userId, string sessionKey)
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
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public UserInfo? GetUserInfo(string sessionKey)
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

        /// <inheritdoc/>
        public bool UserIdExists(int userId)
        {
            var query = "SELECT userId FROM Users WHERE userId = @userId";
            
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();

            return command.ExecuteNonQuery() != 0;
        }

        /// <inheritdoc/>
        public int? GetIdForSessionKey(string sessionKey)
        {
            var query = "SELECT userId FROM Sessions WHERE sessionKey = @sessionKey";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@sessionKey", SqlDbType.VarChar).Value = sessionKey;

            connection.Open();
            var reader = command.ExecuteReader();
            var userIdOrdinal = reader.GetOrdinal("userId");

            while (reader.Read())
            {
                var userId = reader.GetInt32(userIdOrdinal);
                return userId;
            }

            return null;
        }
    }
}
