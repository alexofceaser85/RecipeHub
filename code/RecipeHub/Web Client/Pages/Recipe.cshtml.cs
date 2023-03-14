using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace Web_Client.Pages
{
    /// <summary>
    /// Model for the Individual Recipe Page
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class RecipeModel : PageModel
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public RecipeViewModel ViewModel { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id{ get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Fields are set to default values.
        /// </summary>
        public RecipeModel()
        {
            this.ViewModel = new RecipeViewModel();
        }

        /// <summary>
        /// Called when the page is opened.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Values necessary for web page have been set.<br />
        /// </summary>
        /// <param name="id">The id of the individual recipe.</param>
        public void OnGet(int id)
        {
            try
            {
                this.ViewModel.Initialize(id);
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                Response.Redirect("/Index");
            }
        }


        public IActionResult OnPostAddPlannedMeal()
        {
            return this.RedirectToPage("/Recipe", new { id = this.Id });
        }
    }
}
