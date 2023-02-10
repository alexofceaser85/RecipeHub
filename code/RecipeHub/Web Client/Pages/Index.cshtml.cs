using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using Web_Client.Model.Users;
using Web_Client.ViewModel.Users;

namespace Web_Client.Pages
{
    /// <summary>
    /// The model for the index page
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Determines if the client should show an error message
        /// </summary>
        public bool ShouldThrowError;
        /// <summary>
        /// Determines if the client should show the succeed message
        /// </summary>
        public bool ShouldSucceed;
        /// <summary>
        /// The text of the exception
        /// </summary>
        public string ExceptionText = "";

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Called when [post submit].
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns>The result of the page redirect</returns>
        public RedirectToPageResult? OnPostSubmit(UserInfoBindingModel userInfo)
        {
            try
            {
                UsersViewModel.Login(userInfo.Username, userInfo.Password);
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

        /// <summary>
        /// Logouts this instance.
        /// </summary>
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
                Console.WriteLine("");
            }
        }
    }
}