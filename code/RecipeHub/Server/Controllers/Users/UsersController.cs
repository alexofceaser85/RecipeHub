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
        public LoginResponseModel Login(string username, string password)
        {
            try
            {
                return new LoginResponseModel(HttpStatusCode.OK, UsersService.Login(username, password));
            }
            catch (Exception ex)
            {
                return new LoginResponseModel(HttpStatusCode.InternalServerError, ex.Message);
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
