using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.Service.ShoppingList
{
    /// <summary>
    /// The interface for the recipe types endpoints
    /// </summary>
    public interface IShoppingListService
    {
        /// <summary>
        /// Gets the shopping list for the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The ingredients in the active user's shopping list.</returns>
        public Ingredient[] GetShoppingList();

    }
}
