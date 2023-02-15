using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;

namespace Web_Client.Service.Ingredients
{
    /// <summary>
    /// Service for the Ingredients functionality.
    /// </summary>
    /// <seealso cref="IIngredientsService" />
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientEndpoints endpoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Endpoints are set to default value.<br />
        /// </summary>
        public IngredientsService()
        {
            this.endpoints = new IngredientEndpoints();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Endpoints are set to specified value.<br />
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        public IngredientsService(IIngredientEndpoints endpoints)
        {
            this.endpoints = endpoints;
        }

        /// <inheritdoc />
        public Ingredient[] GetAllIngredientsForUser()
        {
            return this.endpoints.GetAllIngredientsForUser();
        }

        /// <inheritdoc />
        public bool AddIngredient(Ingredient ingredient)
        {
            return this.endpoints.AddIngredient(ingredient);
        }

        /// <inheritdoc />
        public bool DeleteIngredient(Ingredient ingredient)
        {
            return this.endpoints.DeleteIngredient(ingredient);
        }

        /// <inheritdoc />
        public bool UpdateIngredient(Ingredient ingredient)
        {
            return this.endpoints.UpdateIngredient(ingredient);
        }

        /// <inheritdoc />
        public bool DeleteAllIngredientsForUser()
        {
            return this.endpoints.DeleteAllIngredientsForUser();
        }

        /// <inheritdoc />
        public string[] GetSuggestions(string ingredientName)
        {
            return this.endpoints.GetSuggestions(ingredientName);
        }
    }
}
