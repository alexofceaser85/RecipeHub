using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.Service.Users;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace Server.Controllers.Users
{
    /// <summary>
    /// The controller for the users methods
    /// </summary>
    [ApiController]
    public class UsersController
    {
        private readonly IUsersService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public UsersController()
        {
            this.service = new UsersService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        ///
        /// Precondition: usersServer != null
        /// Postcondition: None
        /// </summary>
        /// <param name="usersService">The users service.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public UsersController(IUsersService usersService)
        {
            if (usersService == null)
            {
                throw new ArgumentException(UsersControllerErrorMessages.UsersServiceCannotBeNull);
            }

            this.service = usersService;
        }

        /// <summary>
        /// Creates the account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="verifiedPassword">The verified password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <returns>The server response</returns>
        [HttpPost]
        [Route("CreateAccount")]
        public BaseResponseModel CreateAccount(string username, string password, string verifiedPassword,
            string firstName, string lastName, string email)
        {
            try
            {
                this.service.CreateAccount(new NewAccount(username, password, verifiedPassword, firstName, lastName,
                    email));
                return new BaseResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Logins the specified username and password combination.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The server response</returns>
        [HttpGet]
        [Route("LoginUser")]
        public BaseResponseModel Login(string username, string password, string? previousSessionKey)
        {
            try
            {
                return new BaseResponseModel(HttpStatusCode.OK,
                    this.service.Login(username, password, previousSessionKey));
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Logs the user with the specified session key out of the system.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The server response</returns>
        [HttpPost]
        [Route("LogoutUser")]
        public BaseResponseModel Logout(string sessionKey)
        {
            try
            {
                this.service.Logout(sessionKey);
                return new BaseResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key of the user to get.</param>
        /// <returns>The server response</returns>
        [HttpGet]
        [Route("GetUserInfo")]
        public UserInfoResponseModel GetUserInfo(string sessionKey)
        {
            try
            {
                return new UserInfoResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetUserInfo(sessionKey));
            }
            catch (Exception ex)
            {
                return new UserInfoResponseModel(HttpStatusCode.InternalServerError, ex.Message, null);
            }
        }
    }
}