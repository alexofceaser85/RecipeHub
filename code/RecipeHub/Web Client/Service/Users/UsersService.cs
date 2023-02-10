﻿using Shared_Resources.Data.IO;
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
        public static void Login(string username, string password)
        {
            var hashedPassword = Hashes.HashToSha512(password);
            var sessionKey = UsersEndpoints.Login(username, hashedPassword);
            Session.Key = sessionKey;
            SessionKeySerializers.SaveSessionKey(sessionKey);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public static void Logout()
        {
            UsersEndpoints.Logout(Session.Key);
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        /// <returns>The user data</returns>
        public static UserInfo GetUserData()
        {
            return UsersEndpoints.GetUserInfo(Session.Key);
        }
    }
}
