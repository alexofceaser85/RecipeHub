using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.Endpoints.ShoppingList
{
    /// <summary>
    /// The interface for the recipe types endpoints
    /// </summary>
    public interface IShoppingListEndpoints
    {
        /// <summary>
        /// Gets the shopping list for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The shopping list for the current active user.</returns>
        public Ingredient[] GetShoppingList();

    }
}
