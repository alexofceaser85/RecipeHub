using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Users;
using Microsoft.VisualBasic.ApplicationServices;
using Shared_Resources.Model.Users;

namespace Desktop_Client.ViewModel.Users
{
    /// <summary>
    /// The view model for the users
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
        /// Gets the user information.
        /// </summary>
        /// <returns>The user information</returns>
        public static UserInfo GetUserInfo()
        {
            return UsersService.GetUserInfo();
        }
    }
}
