using Shared_Resources.Model.Ingredients;

namespace Web_Client.Endpoints.ShoppingList
{
    /// <summary>
    /// The interface for the recipe types endpoints
    /// </summary>
    public interface IShoppingListEndpoints
    {
        /// <summary>
        /// Gets the shopping list for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The shopping list for the current active user.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Ingredient[] GetShoppingList();

    }
}
