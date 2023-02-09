using Web_Client.Data.UserData;
using Web_Client.Data;
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
            var sessionKey = UsersEndpoints.Login(username, password);
            Session.Key = sessionKey;
            SessionKeySerializers.SaveSessionKey();
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public static void Logout()
        {
            UsersEndpoints.Logout(Session.Key);
        }
    }
}
