using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Model.Ingredients;
using Web_Client.Model.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace Web_Client.Pages
{
    /// <summary>
    /// The model for the ingredients web page
    /// </summary>
    public class IngredientsModel : PageModel
    {
        private readonly IngredientsViewModel viewModel;

        /// <summary>
        /// The data binding model for the ingredient being added.
        /// </summary>
        [BindProperty]
        public IngredientBindingModel? AddedIngredient { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="IngredientsModel"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public IngredientsModel()
        {
            this.viewModel = new IngredientsViewModel();
        }

        /// <summary>
        /// Sends a request to add a new ingredient based, returning the page model afterwards.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostAddIngredient()
        {
            this.AddedIngredient!.Name = Request.Form["name"];
            this.AddedIngredient.Amount = int.Parse(Request.Form["amount"]!);
            this.AddedIngredient.MeasurementType = (MeasurementType) int.Parse(Request.Form["measurement"]!);
            this.viewModel.AddIngredient(new Ingredient(this.AddedIngredient.Name!, this.AddedIngredient.Amount,
                this.AddedIngredient.MeasurementType));
            return this.Page();
        }

        /// <summary>
        /// Sends a request to remove a selected ingredient, returning the page model afterwards.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostDeleteIngredient()
        {
            var name = Request.Form["Name"];
            this.viewModel.RemoveIngredient(new Ingredient(name!, 0, MeasurementType.Quantity));
            return this.Page();
        }

        /// <summary>
        /// Sends a request to update a selected ingredient, returning the page model afterwards<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostUpdateIngredient()
        {
            var name = Request.Form["Name"];
            var amount = int.Parse(Request.Form["Amount"]!);
            this.viewModel.EditIngredient(new Ingredient(name.ToString(), amount, MeasurementType.Quantity));
            return this.Page();
        }

        /// <summary>
        /// Sends a request to delete all ingredients for a user, returning the page model afterwards.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostDeleteAllIngredients()
        {
            this.viewModel.RemoveAllIngredients();
            return this.Page();
        }
    }
}