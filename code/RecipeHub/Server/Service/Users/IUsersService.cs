using Shared_Resources.Model.Users;

namespace Server.Service.Users
{
    /// <summary>
    /// The interface for the users service
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Creates an account.
        /// </summary>
        /// <param name="newAccount">The new account.</param>
        public void CreateAccount(NewAccount newAccount);
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The login information</returns>
        public string Login(string username, string password, string? previousSessionKey);

        /// <summary>
        /// Logs the specified session key out of the system.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        public void Logout(string sessionKey);

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public UserInfo? GetUserInfo(string sessionKey);
    }
}
