using Shared_Resources.Model.Users;
using Web_Client.Service.Users;

namespace Web_Client.ViewModel.Users
{
    /// <summary>
    /// The view model for the users methods
    /// </summary>
    public static class UsersViewModel
    {
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public static void Login(string username, string password)
        {
            UsersService.Login(username, password);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public static void Logout()
        {
            UsersService.Logout();
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        public static UserInfo GetUserData()
        {
            return UsersService.GetUserData();
        }

    }
}
