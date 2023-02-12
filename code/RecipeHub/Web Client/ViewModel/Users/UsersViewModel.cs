using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;
using Web_Client.Service.Users;

namespace Web_Client.ViewModel.Users
{
    /// <summary>
    /// The view model for the users
    /// </summary>
    public class UsersViewModel
    {
        private readonly IUsersService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
        /// </summary>
        public UsersViewModel()
        {
            this.service = new UsersService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public UsersViewModel(IUsersService service)
        {
            if (service == null)
            {
                throw new ArgumentException(UsersServiceViewModelErrorMessages.UsersServiceCannotBeNull);
            }

            this.service = service;
        }

        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password)
        {
            this.service.Login(username, password);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public void Logout()
        {
            this.service.Logout();
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo()
        {
            return this.service.GetUserInfo();
        }
    }
}
