using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Web_Client.ViewModel.ShoppingList;

namespace Web_Client.Pages
{
    /// <summary>
    /// Code-Behind for the Shopping List.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ShoppingListModel : PageModel
    {
        private bool shouldReturnToLogin = false;
        private ShoppingListViewModel viewModel;

        /// <summary>
        /// Gets the shopping list.
        /// </summary>
        /// <value>
        /// The shopping list.
        /// </value>
        public Ingredient[] ShoppingList => this.viewModel.ShoppingList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        public ShoppingListModel()
        {
            try
            {
                this.viewModel = new ShoppingListViewModel();
                this.viewModel.GetShoppingList();
            }
            catch (UnauthorizedAccessException)
            {
                this.shouldReturnToLogin = true;
            }
        }

        /// <summary>
        /// Called when the page is retrieved initially.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        public void OnGet()
        {
            if (this.shouldReturnToLogin)
            {
                TempData["Message"] = UsersServiceErrorMessages.UnauthorizedAccessErrorMessage;
                Response.Redirect("/Index");
            }
        }

        /// <summary>
        /// Called when the shopping list is added to the pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Shopping list has been added to the pantry.<br />
        /// </summary>
        public IActionResult OnPostAddShoppingListToPantry()
        {
            try
            {
                var ingredients = new List<Ingredient>();
                foreach (var ingredient in this.ShoppingList)
                {
                    int amount = int.Parse(Request.Form[$"Amount-{ingredient.Name}"][0]!);
                    var addedIngredient = new Ingredient(ingredient.Name, amount, ingredient.MeasurementType);
                    ingredients.Add(addedIngredient);
                }

                this.viewModel.AddIngredientsToPantry(ingredients.ToArray());
                return RedirectToPage("ShoppingList");
            }
            catch (UnauthorizedAccessException)
            {
                Session.Key = null;
                TempData["Message"] = UsersServiceErrorMessages.UnauthorizedAccessErrorMessage;
                return RedirectToPage("Index");
            }
        }
    }
}
