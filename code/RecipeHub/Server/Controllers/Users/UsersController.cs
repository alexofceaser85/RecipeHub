using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.Service.Users;

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
        /// </summary>
        /// <param name="usersService">The users service.</param>
        public UsersController(IUsersService usersService)
        {


            this.service = usersService;
        }

        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The server response</returns>
        [HttpGet]
        [Route("LoginUser")]
        public LoginResponseModel Login(string username, string password, string? previousSessionKey)
        {
            try
            {
                return new LoginResponseModel(HttpStatusCode.OK, this.service.Login(username, password, previousSessionKey));
            }
            catch (Exception ex)
            {
                return new LoginResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Logs the user with the specified session key out of the system.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The server response</returns>
        [HttpPost]
        [Route("LogoutUser")]
        public LoginResponseModel Logout(string sessionKey)
        {
            try
            {
                this.service.Logout(sessionKey);
                return new LoginResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);
            }
            catch (Exception ex)
            {
                return new LoginResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key of the user to get.</param>
        /// <returns>The server response</returns>
        [HttpGet]
        [Route("GetUserInfo")]
        public UserInfoResponseModel GetUserInfo(string sessionKey)
        {
            try
            {
                return new UserInfoResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage, this.service.GetUserInfo(sessionKey));
            }
            catch (Exception ex)
            {
                return new UserInfoResponseModel(HttpStatusCode.InternalServerError, ex.Message, null);
            }
        }
    }
}
