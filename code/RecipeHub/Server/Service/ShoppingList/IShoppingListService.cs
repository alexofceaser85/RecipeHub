using Shared_Resources.Model.Ingredients;

namespace Server.Service.ShoppingList
{
    /// <summary>
    /// The service for the shopping list
    /// </summary>
    public interface IShoppingListService
    {
        /// <summary>
        /// Gets the shopping list ingredients.
        ///
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The shopping list ingredients</returns>
        public Ingredient[] GetShoppingListIngredients(string sessionKey);
    }
}
