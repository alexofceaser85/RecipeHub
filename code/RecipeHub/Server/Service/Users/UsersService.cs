using Server.DAL.Users;
using System.Security.Cryptography;
using System.Text;
using Shared_Resources.Model.Users;

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

            //TODO move into a props file
            var length = 50;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomKey = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var hashedKey = hashPassword(randomKey);

            if (!UsersDal.VerifySessionKeyDoesNotExist(hashedKey))
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
