﻿using Server.DAL.Users;
using Shared_Resources.Data.Settings;
using Shared_Resources.Model.Users;
using Shared_Resources.Utils.Hashing;

namespace Server.Service.Users
{
    /// <summary>
    /// Holds the service methods for the user
    /// </summary>
    public class UsersService
    {
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The new session key for the user</returns>
        /// <exception cref="System.ArgumentException">user name and password combo is wrong</exception>
        public static string Login(string username, string password, string? previousSessionKey)
        {
            var userId = UsersDal.VerifyUserNameAndPasswordCombination(username, password);
            if (userId == null)
            {
                throw new ArgumentException("user name and password combo is wrong");
            }

            var sessionKey = generateNewSessionKey();
            if (previousSessionKey != null)
            {
                UsersDal.RemoveSessionKey(previousSessionKey);
            }

            UsersDal.AddUserSession(userId.Value, sessionKey);

            return sessionKey;
        }

        /// <summary>
        /// Log outs the specified user's session.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        public static void Logout(string sessionKey)
        {
            UsersDal.RemoveSessionKey(sessionKey);
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns></returns>
        public static UserInfo? GetUserInfo(string sessionKey)
        {
            return UsersDal.GetUserInfo(sessionKey);
        }

        private static string generateNewSessionKey()
        {
            var random = new Random();

            var randomKey = new string(Enumerable.Repeat(SessionKeySettings.SessionKeyCharacters, SessionKeySettings.SessionKeyLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var hashedKey = Hashes.HashToSha512(randomKey);

            if (!UsersDal.VerifySessionKeyDoesNotExist(hashedKey))
            {
                return generateNewSessionKey();
            }

            return hashedKey;
        }
    }
}
