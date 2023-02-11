using Shared_Resources.Model.Users;

namespace Web_Client.Endpoints.Users
{
    /// <summary>
    /// The interface for the 
    /// </summary>
    public interface IUsersEndpoints
    {
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The login information</returns>
        public string Login(string username, string password, string previousSessionKey);
        /// <summary>
        /// Logs the user out.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The logout information</returns>
        public string Logout(string sessionKey);
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo(string sessionKey);
    }
}
