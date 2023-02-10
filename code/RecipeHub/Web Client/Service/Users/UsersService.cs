using Shared_Resources.Data.IO;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Users;
using Shared_Resources.Utils.Hashing;
using Web_Client.Endpoints.Users;

namespace Web_Client.Service.Users
{
    /// <summary>
    /// The service methods for the users
    /// </summary>
    public static class UsersService
    {
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public static void Login(string? username, string? password)
        {
            //TODO Extract error messages
            if (username == null)
            {
                throw new ArgumentException("username cannot be null");
            }

            if (password == null)
            {
                throw new ArgumentException("password cannot be null");
            }

            var hashedPassword = Hashes.HashToSha512(password);
            var previousSessionKey = SessionKeySerializers.LoadSessionKey();
            var sessionKey = UsersEndpoints.Login(username, hashedPassword, previousSessionKey);
            Session.Key = sessionKey;
            SessionKeySerializers.SaveSessionKey(sessionKey);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public static void Logout()
        {
            //TODO Extract error messages
            if (Session.Key == null)
            {
                throw new ArgumentException("Session cannot be null");
            }
            UsersEndpoints.Logout(Session.Key);
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        /// <returns>The user data</returns>
        public static UserInfo GetUserData()
        {
            if (Session.Key == null)
            {
                throw new ArgumentException("Session key cannot be null");
            }
            return UsersEndpoints.GetUserInfo(Session.Key);
        }
    }
}
