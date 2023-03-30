using System.Text.Json;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.ShoppingList
{
    /// <summary>
    /// The endpoints for the recipe types
    /// </summary>
    /// <seealso cref="IShoppingListEndpoints" />
    public class ShoppingListEndpoints : IShoppingListEndpoints
    {
        private const string GetShoppingListServiceMethodName = "GetShoppingListIngredients";

        private const string IngredientsElementName = "ingredients";

        private readonly HttpClient client;

        /// <summary>
        /// Initializes a default instance of the <see cref="ShoppingListEndpoints"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public ShoppingListEndpoints()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListEndpoints"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>client != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="client">The client.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ShoppingListEndpoints(HttpClient client)
        {
            this.client = client ?? 
                          throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets the shopping list for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The shopping list for the current active user.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Ingredient[] GetShoppingList()
        {
            var parameters = $"?sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{GetShoppingListServiceMethodName}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var shoppingList = json[IngredientsElementName]!.AsArray().Deserialize<Ingredient[]>();

            return shoppingList!;
        }
    }
}
