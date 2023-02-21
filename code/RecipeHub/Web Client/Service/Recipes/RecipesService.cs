using Shared_Resources.Data.UserData;
using Web_Client.Endpoints.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.Users;

namespace Web_Client.Service.Recipes
{
    /// <inheritdoc cref="IRecipesService"/>
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesEndpoints endpoints;
        private readonly IUsersService usersService;

        /// <summary>
        /// Creates a default instance of <see cref="RecipesService"/>.<br/>
        /// Uses an instance of <see cref="RecipesEndpoints"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesService() : this(new RecipesEndpoints(), new UsersService())
        {

        }
        
        /// <summary>
        /// Creates a instance of <see cref="RecipesService"/> with a specified <see cref="IRecipesEndpoints"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>endpoints != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesService(IRecipesEndpoints endpoints, IUsersService usersService)
        {
            this.endpoints = endpoints ?? 
                             throw new ArgumentNullException(nameof(endpoints), RecipesServiceErrorMessages.RecipesEndpointsCannotBeNull);
            this.usersService = usersService;
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipes(string sessionKey, string searchTerm = "")
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (searchTerm == null)
            {
                throw new ArgumentNullException(nameof(searchTerm), RecipesServiceErrorMessages.SearchTermCannotBeNull);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipes(sessionKey, searchTerm);
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipesForType(string type)
        {
            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipesForType(Session.Key, type);
        }

        /// <inheritdoc/>
        public Recipe GetRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipe(sessionKey, recipeId);
        }

        /// <inheritdoc/>
        public Ingredient[] GetIngredientsForRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetIngredientsForRecipe(sessionKey, recipeId);
        }

        /// <inheritdoc/>
        public RecipeStep[] GetStepsForRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetStepsForRecipe(sessionKey, recipeId);
        }

        /// <inheritdoc/>
        public void AddRecipe(string sessionKey, string name, string description, bool isPublic)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), RecipesServiceErrorMessages.RecipeNameCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(RecipesServiceErrorMessages.RecipeNameCannotBeEmpty);
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description),
                    RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.endpoints.AddRecipe(sessionKey, name, description, isPublic);
        }

        /// <inheritdoc/>
        public void RemoveRecipe(string sessionKey, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.endpoints.RemoveRecipe(sessionKey, recipeId);
        }

        /// <inheritdoc/>
        public void EditRecipe(string sessionKey, int recipeId, string name, string description, bool isPublic)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), RecipesServiceErrorMessages.RecipeNameCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(RecipesServiceErrorMessages.RecipeNameCannotBeEmpty);
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description),
                    RecipesServiceErrorMessages.RecipeDescriptionCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(RecipesServiceErrorMessages.RecipeDescriptionCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.endpoints.EditRecipe(sessionKey, recipeId, name, description, isPublic);
        }
    }
}
