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
    }
}
