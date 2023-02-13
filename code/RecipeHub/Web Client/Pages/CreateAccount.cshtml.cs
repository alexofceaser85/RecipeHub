using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.Model.Users;
using Web_Client.ViewModel.Users;

namespace Web_Client.Pages
{
    /// <summary>
    /// The create account model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
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
        /// Gets or sets the binding model.
        /// </summary>
        /// <value>
        /// The binding model.
        /// </value>
        [BindProperty]
        public NewAccountInfoBindingModel BindingModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountModel"/> class.
        /// </summary>
        public CreateAccountModel()
        {
            this.viewModel = new UsersViewModel();
            this.BindingModel = new NewAccountInfoBindingModel();
        }

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Called when [post submit].
        /// </summary>
        /// <param name="bindingModel">The binding model.</param>
        /// <returns>The redirect result</returns>
        public RedirectToPageResult? OnPostSubmit(NewAccountInfoBindingModel bindingModel)
        {
            try
            {
                this.BindingModel = bindingModel;
                this.viewModel.CreateAccount(bindingModel.Username ?? "", bindingModel.Password ?? "", bindingModel.VerifyPassword ?? "",
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

        /// <summary>
        /// Called when [post cancel].
        /// </summary>
        /// <returns>The redirect result</returns>
        public RedirectToPageResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
