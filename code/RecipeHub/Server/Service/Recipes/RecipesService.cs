using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Server.Service.Recipes
{
    /// <summary>
    /// Holds the service methods for the recipes table
    /// </summary>
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesDal recipesDal;
        private readonly IUsersDal usersDal;

        /// <summary>
        /// Creates an instance of <see cref="RecipesService"/>.<br/>
        /// A <see cref="RecipeDal"/> will be used as the DAL.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesService()
        {
            this.recipesDal = new RecipeDal();
            this.usersDal = new UsersDal();
        }

        /// <summary>
        /// Creates an instance of <see cref="RecipesService"/> with a specified <see cref="IRecipesDal"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>recipesDal != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipesDal">The DAL for the recipes table</param>
        /// <param name="usersDal">The DAL for the users table</param>
        /// <exception cref="ArgumentNullException">recipesDal</exception>
        public RecipesService(IRecipesDal recipesDal, IUsersDal usersDal)
        {
            this.recipesDal = recipesDal ?? throw new ArgumentNullException(nameof(recipesDal),
                ServerRecipesServiceErrorMessages.RecipesDataAccessLayerCannotBeNull);
            this.usersDal = usersDal ?? throw new ArgumentNullException(nameof(usersDal),
                ServerRecipesServiceErrorMessages.UsersDataAccessLayerCannotBeNull);
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipes(string sessionKey, string searchTerm = "")
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (searchTerm == null)
            {
                throw new ArgumentNullException(nameof(searchTerm),
                    ServerRecipesServiceErrorMessages.SearchTermCannotBeNull);
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);

            return this.recipesDal.GetRecipesWithName((int) userId, searchTerm);
        }

        /// <inheritdoc/>
        public Recipe GetRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ?? throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);
            if (!this.recipesDal.UserCanSeeRecipe((int)userId, recipeId))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.UserDidNotMakeRecipe);
            }

            return (Recipe) this.recipesDal.GetRecipe(recipeId)!;
        }

        /// <inheritdoc/>
        public Ingredient[] GetRecipeIngredients(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);
            if (!this.recipesDal.UserCanSeeRecipe((int)userId, recipeId))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.UserDidNotMakeRecipe);
            }

            return this.recipesDal.GetIngredientsForRecipe(recipeId);
        }

        /// <inheritdoc/>
        public RecipeStep[] GetRecipeSteps(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);
            if (!this.recipesDal.UserCanSeeRecipe((int)userId, recipeId))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.UserDidNotMakeRecipe);
            }

            return this.recipesDal.GetStepsForRecipe(recipeId);
        }

        /// <inheritdoc/>
        public bool AddRecipe(string sessionKey, string name, string description, bool isPublic)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name),
                    ServerRecipesServiceErrorMessages.RecipeNameCannotBeEmpty);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.RecipeNameCannotBeEmpty);
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description),
                    ServerRecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty);
            }

            int? authorId = this.usersDal.GetIdForSessionKey(sessionKey) ?? throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);

            return this.recipesDal.AddRecipe((int) authorId, name, description, isPublic);
        }

        /// <inheritdoc/>
        public bool RemoveRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            int? authorId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                            throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);
            if (!this.recipesDal.IsAuthorOfRecipe((int)authorId, recipeId))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.UserDidNotMakeRecipe);
            }

            return this.recipesDal.RemoveRecipe(recipeId);
        }

        /// <inheritdoc/>
        public bool EditRecipe(string sessionKey, int recipeId, string name, string description, bool isPublic)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name),
                    ServerRecipesServiceErrorMessages.RecipeNameCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.RecipeNameCannotBeEmpty);
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description),
                    ServerRecipesServiceErrorMessages.RecipeDescriptionCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty);
            }

            int? authorId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                            throw new UnauthorizedAccessException(ServerRecipesServiceErrorMessages.SessionKeyIsNotValid);
            if (!this.recipesDal.IsAuthorOfRecipe((int)authorId, recipeId))
            {
                throw new ArgumentException(ServerRecipesServiceErrorMessages.UserDidNotMakeRecipe);
            }

            return this.recipesDal.EditRecipe(recipeId, name, description, isPublic);
        }
    }
}