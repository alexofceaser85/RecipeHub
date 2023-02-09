using System.Net;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Service.Users;

namespace Server.Controllers.Users
{
    [ApiController]
    public class UsersController
    {

        [HttpGet]
        [Route("LoginUser")]
        public LoginResponseModel Login(string username, string password, string? previousSessionKey)
        {
            try
            {
                return new LoginResponseModel(HttpStatusCode.OK, UsersService.Login(username, password, previousSessionKey));
            }
            catch (Exception ex)
            {
                return new LoginResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserInfo")]
        public UserInfoResponseModel GetUserInfo(string sessionKey)
        {
            try
            {
                return new UserInfoResponseModel(HttpStatusCode.OK, "Returned Okay", UsersService.GetUserInfo(sessionKey));
            }
            catch (Exception ex)
            {
                return new UserInfoResponseModel(HttpStatusCode.InternalServerError, ex.Message, null);
            }
        }

        [HttpPost]
        [Route("LogoutUser")]
        public LoginResponseModel Logout(string sessionKey)
        {
            try
            {
                UsersService.Logout(sessionKey);
                return new LoginResponseModel(HttpStatusCode.OK, string.Empty);
            }
            catch (Exception ex)
            {
                return new LoginResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
