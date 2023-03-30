using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Users;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.Service.Ingredients
{
    /// <summary>
    /// Service for the Ingredients functionality.
    /// </summary>
    /// <seealso cref="IIngredientsService" />
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientEndpoints endpoints;
        private readonly IUsersService usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Endpoints are set to default value.<br />
        /// </summary>
        public IngredientsService()
        {
            this.endpoints = new IngredientEndpoints();
            this.usersService = new UsersService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Endpoints are set to specified value.<br />
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <param name="usersService">The users service</param>
        public IngredientsService(IIngredientEndpoints endpoints, IUsersService usersService)
        {
            this.endpoints = endpoints;
            this.usersService = usersService;
        }

        /// <inheritdoc />
        public Ingredient[] GetAllIngredientsForUser()
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.GetAllIngredientsForUser();
        }

        /// <inheritdoc />
        public bool AddIngredient(Ingredient ingredient)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.AddIngredient(ingredient);
        }

        /// <summary>
        /// Adds multiple ingredients to a user's pantry.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; All ingredients in ingredients are present on the server<br/>
        /// <b>Postcondition: </b>Each ingredient is added to the user's pantry
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        /// <returns>Whether the ingredient was successfully added</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool AddIngredients(Ingredient[] ingredients)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.AddIngredients(ingredients);
        }

        /// <inheritdoc />
        public bool DeleteIngredient(Ingredient ingredient)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.DeleteIngredient(ingredient);
        }

        /// <inheritdoc />
        public bool UpdateIngredient(Ingredient ingredient)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.UpdateIngredient(ingredient);
        }

        /// <inheritdoc />
        public bool DeleteAllIngredientsForUser()
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.DeleteAllIngredientsForUser();
        }

        /// <inheritdoc />
        public string[] GetSuggestions(string ingredientName)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.GetSuggestions(ingredientName);
        }
    }
}