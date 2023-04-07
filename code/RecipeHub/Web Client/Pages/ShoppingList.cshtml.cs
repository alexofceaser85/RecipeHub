using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            this.viewModel = new ShoppingListViewModel();
            this.viewModel.GetShoppingList();
        }

        /// <summary>
        /// Called when the page is retrieved initially.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Called when the shopping list is added to the pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Shopping list has been added to the pantry.<br />
        /// </summary>
        public IActionResult OnPostAddShoppingListToPantry()
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
    }
}
