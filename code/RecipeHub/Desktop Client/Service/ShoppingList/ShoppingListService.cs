using Desktop_Client.Endpoints.ShoppingList;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.Service.ShoppingList
{
    /// <summary>
    /// The endpoints for the recipe types
    /// </summary>
    /// <seealso cref="IShoppingListService" />
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListEndpoints endpoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListService"/> class.<br/>
        ///<br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        public ShoppingListService() : this(new ShoppingListEndpoints())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListService"/> class.<br/>
        ///<br/>
        /// <b>Precondition: </b>endpoints != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ShoppingListService(IShoppingListEndpoints endpoints)
        {
            this.endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints));
        }

        /// <summary>
        /// Gets the shopping list for the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The ingredients in the active user's shopping list.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Ingredient[] GetShoppingList()
        {
            return this.endpoints.GetShoppingList();
        }
    }
}
