using System.Net;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
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
    }
}
