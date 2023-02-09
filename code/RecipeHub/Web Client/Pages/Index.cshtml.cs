using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using Web_Client.Model.Users;
using Web_Client.Service.Users;
using Web_Client.ViewModel.Users;

namespace Web_Client.Pages
{
    public class IndexModel : PageModel
    {
        public bool ShouldThrowError;
        public bool ShouldSucceed;

        public string ExceptionText = "";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            this.
            _logger = logger;
        }

        public void OnGet()
        {

        }

        //TODO Change code
        public RedirectToPageResult OnPostSubmit(UserInfoBindingModel userInfo)
        {
            try
            {
                UsersViewModel.Login(userInfo.Username, hashPassword(userInfo.Password));
                this.ShouldSucceed = true;
                this.ExceptionText = "";
                //TODO Extract
                return RedirectToPage("/Recipes");
            }
            catch (Exception e)
            {
                this.ShouldThrowError = true;
                this.ExceptionText = e.Message;
                return null;
            }
        }

        public void Logout()
        {
            try
            {
                UsersViewModel.Logout();
                this.ShouldSucceed = true;
                this.ExceptionText = "";
            }
            catch (Exception)
            {
                System.Console.WriteLine("");
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