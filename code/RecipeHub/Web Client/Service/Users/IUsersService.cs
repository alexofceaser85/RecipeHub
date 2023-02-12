using Shared_Resources.Model.Users;

namespace Web_Client.Service.Users
{
    /// <summary>
    /// The interface for the users service
    /// </summary>
    public interface IUsersService
    {

        public void CreateAccount(string username, string password, string verifyPassword, string firstName,
            string lastName, string email);
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password);
        /// <summary>
        /// Logs the current user out.
        /// </summary>
        public void Logout();
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo();
    }
}
