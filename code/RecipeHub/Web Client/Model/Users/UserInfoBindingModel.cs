using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Model.Users
{
    public class UserInfoBindingModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

    }
}
