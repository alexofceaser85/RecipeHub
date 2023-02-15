using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private const string RecipesAddress = "/Recipes";
        private const string CreateAccountAddress = "/CreateAccount";
        private UsersViewModel usersViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        public IndexModel()
        {
            this.usersViewModel = new UsersViewModel();
        }

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
                this.usersViewModel.Login(userInfo.Username ?? "", userInfo.Password ?? "");
                this.ShouldSucceed = true;
                this.ExceptionText = "";
                return RedirectToPage("/RecipeList");
            }
            catch (Exception e)
            {
                this.ShouldThrowError = true;
                this.ExceptionText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Called when [post create account].
        /// </summary>
        /// <returns>The redirect result</returns>
        public RedirectToPageResult OnPostCreateAccount()
        {
            return RedirectToPage(CreateAccountAddress);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        public void Logout()
        {
            this.usersViewModel.Logout();
            this.ShouldSucceed = true;
            this.ExceptionText = "";
        }
    }
}