﻿using Shared_Resources.Model.Ingredients;
using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Users;

namespace Web_Client.Service.Ingredients
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

        /// <inheritdoc />
        public void AddIngredients(Ingredient[] ingredients)
        {
            this.usersService.RefreshSessionKey();
            this.endpoints.AddIngredients(ingredients);
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

        /// <inheritdoc />
        public Ingredient[] GetMissingIngredientsForRecipe(int recipeId)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.GetMissingIngredientsForRecipe(recipeId);
        }

        /// <inheritdoc />
        public void RemoveIngredientsForRecipe(int recipeId)
        {
            this.usersService.RefreshSessionKey();
            this.endpoints.RemoveIngredientsForRecipe(recipeId);
        }
    }
}

