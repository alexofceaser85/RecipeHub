using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.ViewModel.Users;

namespace Web_Client.Pages
{
    /// <summary>
    /// Empty Page for purposes of redirecting back to the index.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class LogoutModel : PageModel
    {
        private UsersViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutModel"/> class.
        /// </summary>
        public LogoutModel()
        {
            this.viewModel = new UsersViewModel();
        }

        /// <summary>
        /// Called when [get].
        /// </summary>
        /// <returns>A redirect to the Index.</returns>
        public IActionResult OnGet()
        {
            this.viewModel.Logout();
            return RedirectToPage("Index");
        }
    }
}
