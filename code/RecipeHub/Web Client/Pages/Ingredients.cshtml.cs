using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Json;
using Web_Client.Model.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace Web_Client.Pages
{
    /// <summary>
    /// The model for the ingredients web page
    /// </summary>
    public class IngredientsModel : PageModel
    {
        private const int NumberOfSuggestions = 5;
        private readonly IngredientsViewModel viewModel;

        /// <summary>
        /// The data binding model for the ingredient being added.
        /// </summary>
        [BindProperty]
        public IngredientBindingModel? AddedIngredient { get; set; }
        
        /// <summary>
        /// The list of ingredients for the page.
        /// </summary>
        public IList<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the suggestions.
        /// </summary>
        /// <value>
        /// The suggestions.
        /// </value>
        [BindProperty]
        public string[]? Suggestions { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="IngredientsModel"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public IngredientsModel()
        {
            this.viewModel = new IngredientsViewModel();
            this.Ingredients = this.viewModel.GetAllIngredientsForUser();
            this.Suggestions = Array.Empty<string>();
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
            return RedirectToPage("Ingredients");
        }

        /// <summary>
        /// Called when the ingredients are gotten from the server.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>JSON containing the suggested ingredients.</returns>
        public IActionResult OnPostGetIngredientsSuggestions(string searchText)
        {
            string[] suggestions = this.viewModel.GetSuggestions(searchText);
            this.Suggestions = suggestions.Take(NumberOfSuggestions).ToArray();
            return Content(JsonSerializer.Serialize(this.Suggestions), "application/json");
        }

        /// <summary>
        /// Called when [post delete ingredient].
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostDeleteIngredientAsync()
        {
            string name = Request.Form["Name"][0]!;
            this.viewModel.RemoveIngredient(new Ingredient(name!, 0, MeasurementType.Quantity));
            return RedirectToPage("Ingredients");
        }

        /// <summary>
        /// Sends a request to update a selected ingredient, returning the page model afterwards<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The page</returns>
        public IActionResult OnPostUpdateIngredientAsync()
        {
            string name = Request.Form["Name"][0]!;
            int amount = int.Parse(Request.Form["Amount"]!);
            this.viewModel.EditIngredient(new Ingredient(name.ToString(), amount, MeasurementType.Quantity));
            return RedirectToPage("Ingredients");
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
            return RedirectToPage("Ingredients");
        }
    }
}
