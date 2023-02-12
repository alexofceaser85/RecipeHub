using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.Model.Users;
using Web_Client.ViewModel.Users;

namespace Web_Client.Pages
{
    public class CreateAccountModel : PageModel
    {
        private UsersViewModel viewModel;

        /// <summary>
        /// Determines if the client should show an error message
        /// </summary>
        public bool ShouldThrowError;

        /// <summary>
        /// The text of the exception
        /// </summary>
        public string ExceptionText = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountModel"/> class.
        /// </summary>
        public CreateAccountModel()
        {
            this.viewModel = new UsersViewModel();
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult? OnPostSubmit(NewAccountInfoBindingModel bindingModel)
        {
            try
            {
                this.viewModel.CreateAccount(bindingModel.Username ?? "", bindingModel.Password ?? "", bindingModel.VerifiedPassword ?? "",
                    bindingModel.FirstName ?? "", bindingModel.LastName ?? "", bindingModel.Email ?? "");
                this.ExceptionText = "";
                return RedirectToPage("/Index");
            }
            catch (Exception e)
            {
                this.ShouldThrowError = true;
                this.ExceptionText = e.Message;
                return null;
            }
        }

        public RedirectToPageResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
