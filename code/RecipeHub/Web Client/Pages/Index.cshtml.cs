using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using Web_Client.Endpoints.Users;
using Web_Client.Model.Users;

namespace Web_Client.Pages
{
    public class IndexModel : PageModel
    {
        public bool ShouldThrowError = false;
        public bool ShouldSucceed = false;

        public string ExceptionText = "";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPostSubmit(UserInfoBindingModel userInfo)
        {
            try
            {
                UsersEndpoints.Login(userInfo.Username, hashPassword(userInfo.Password));
                this.ShouldSucceed = true;
                this.ExceptionText = "";
            }
            catch (Exception e)
            {
                this.ShouldThrowError = true;
                this.ExceptionText = e.Message;
            }
        }

        static string hashPassword(string passwordToHash)
        {
            using HashAlgorithm algorithm = SHA512.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
            var builder = new StringBuilder();
            foreach (var passwordByte in bytes)
            {
                builder.Append(passwordByte.ToString("x2"));
            }
            var hashedPassword = builder.ToString();
            return hashedPassword;
        }
    }
}