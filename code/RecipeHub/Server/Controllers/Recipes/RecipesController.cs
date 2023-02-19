using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.Recipes;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Server.Controllers.Recipes
{
    /// <summary>
    /// The controller for the users methods
    /// </summary>
    [ApiController]
    public class RecipesController
    {
        private readonly IRecipesService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesController"/> class.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public RecipesController()
        {
            this.service = new RecipesService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesController"/> class.<br/>
        ///<br/>
        /// <b>Precondition: </b>usersService != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipesService">The recipes service.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public RecipesController(IRecipesService recipesService)
        {
            this.service = recipesService ??
                           throw new ArgumentNullException(nameof(recipesService),
                               RecipesControllerErrorMessages.RecipesServiceCannotBeNull);
        }

        /// <summary>
        /// Gets a specified recipe, if the recipe exists and is visible to the user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key associated with the user</param>
        /// <param name="recipeId">The id of the recipe to search.</param>
        /// <returns>A response containing the recipe.</returns>
        [HttpGet]
        [Route("Recipe")]
        public RecipeResponseModel GetRecipe(string sessionKey, int recipeId)
        {
            try
            {
                return new RecipeResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetRecipe(sessionKey, recipeId));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeResponseModel(HttpStatusCode.Unauthorized, ex.Message, null!);
            }
            catch (Exception ex)
            {
                return new RecipeResponseModel(HttpStatusCode.InternalServerError, ex.Message, new Recipe());
            }
        }

        /// <summary>
        /// Gets the ingredients for a specified recipe, if the recipe exists and is visible to the user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key associated with the user</param>
        /// <param name="recipeId">The id of the recipe to search.</param>
        /// <returns>A response containing the ingredients for recipe.</returns>
        [HttpGet]
        [Route("RecipeIngredients")]
        public RecipeIngredientsResponseModel GetRecipeIngredients(string sessionKey, int recipeId)
        {
            try
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.OK,
                    ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetRecipeIngredients(sessionKey, recipeId));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.Unauthorized, ex.Message, Array.Empty<Ingredient>());
            }
            catch (Exception ex)
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.InternalServerError, ex.Message,
                    Array.Empty<Ingredient>());
            }
        }

        /// <summary>
        /// Gets the steps for a recipe, if the recipe exists and is visible to the user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key associated with the user</param>
        /// <param name="recipeId">The id of the recipe to search.</param>
        /// <returns>A response containing the steps for the recipe.</returns>
        [HttpGet]
        [Route("RecipeSteps")]
        public RecipeStepsResponseModel GetRecipeSteps(string sessionKey, int recipeId)
        {
            try
            {
                return new RecipeStepsResponseModel(HttpStatusCode.OK,
                    ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetRecipeSteps(sessionKey, recipeId));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeStepsResponseModel(HttpStatusCode.Unauthorized, ex.Message, Array.Empty<RecipeStep>());
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeStepsResponseModel(HttpStatusCode.Unauthorized, ex.Message, Array.Empty<RecipeStep>());
            }
            catch (Exception ex)
            {
                return new RecipeStepsResponseModel(HttpStatusCode.InternalServerError, ex.Message,
                    Array.Empty<RecipeStep>());
            }
        }

        /// <summary>
        /// Adds a recipe with the user associated with the session key as the author.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The active user's session key.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The recipe's description.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        /// <returns>The server's response.</returns>
        [HttpPost]
        [Route("Recipe")]
        public StandardResponseModel AddRecipe(string sessionKey, string name, string description, bool isPublic)
        {
            try
            {
                if (this.service.AddRecipe(sessionKey, name, description, isPublic))
                {
                    return new StandardResponseModel(HttpStatusCode.OK,
                        ServerSettings.DefaultSuccessfulConnectionMessage);
                }

                return new StandardResponseModel(HttpStatusCode.InternalServerError,
                    RecipesControllerErrorMessages.RecipeFailedToAdd);
            }
            catch (UnauthorizedAccessException ex)
            {
                return new StandardResponseModel(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new StandardResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Removes the specified recipe.<br/>
        /// The user associated with the provided session key must be the author of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key for the active user.</param>
        /// <param name="recipeId">Thee ID for the recipe to remove.</param>
        /// <returns>Thee server's response.</returns>
        [HttpDelete]
        [Route("Recipe")]
        public StandardResponseModel RemoveRecipe(string sessionKey, int recipeId)
        {
            try
            {
                if (this.service.RemoveRecipe(sessionKey, recipeId))
                {
                    return new StandardResponseModel(HttpStatusCode.OK,
                        ServerSettings.DefaultSuccessfulConnectionMessage);
                }

                return new StandardResponseModel(HttpStatusCode.InternalServerError,
                    RecipesControllerErrorMessages.RecipeFailedToRemove);
            }
            catch (UnauthorizedAccessException ex)
            {
                return new StandardResponseModel(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new StandardResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Updates the information for a specified recipe.<br/>
        /// The user associated with the session key must be the author of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The active user's session key.</param>
        /// <param name="recipeId">The ID for the recipe to update.</param>
        /// <param name="name">The new name of the recipe.</param>
        /// <param name="description">The new description for the recipe..</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        /// <returns>The server's response.</returns>
        [HttpPut]
        [Route("Recipe")]
        public StandardResponseModel EditRecipe(string sessionKey, int recipeId, string name, string description,
            bool isPublic)
        {
            try
            {
                if (this.service.EditRecipe(sessionKey, recipeId, name, description, isPublic))
                {
                    return new StandardResponseModel(HttpStatusCode.OK,
                        ServerSettings.DefaultSuccessfulConnectionMessage);
                }

                return new StandardResponseModel(HttpStatusCode.InternalServerError,
                    RecipesControllerErrorMessages.RecipeFailedToEdit);
            }
            catch (UnauthorizedAccessException ex)
            {
                return new StandardResponseModel(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new StandardResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets all of the recipes who's name contains the search term for the user.<br/>
        /// If no search term is provided, all recipes visible to the user are fetched.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The active user's session key.</param>
        /// <param name="searchTerm">The term to search recipe names for.</param>
        /// <returns>The server's response.</returns>
        [HttpGet]
        [Route("Recipes")]
        public RecipeListResponseModel GetRecipes(string sessionKey, string searchTerm = "")
        {
            try
            {
                return new RecipeListResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetRecipes(sessionKey, searchTerm));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeListResponseModel(HttpStatusCode.Unauthorized, ex.Message, Array.Empty<Recipe>());
            }
            catch (Exception ex)
            {
                return new RecipeListResponseModel(HttpStatusCode.InternalServerError, ex.Message,
                    Array.Empty<Recipe>());
            }
        }
    }
}