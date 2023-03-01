using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Service.Users;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.Service.Recipes
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
            this.usersService = usersService ??
                                throw new ArgumentNullException(nameof(endpoints), RecipesServiceErrorMessages.UserServiceCannotBeNull);
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipes(string searchTerm = "")
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (searchTerm == null)
            {
                throw new ArgumentNullException(nameof(searchTerm), RecipesServiceErrorMessages.SearchTermCannotBeNull);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipes(Session.Key, searchTerm);
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipesForTags(string[] tags)
        {
            if (Session.Key == null)
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            if (tags == null)
            {
                throw new ArgumentException(RecipesServiceErrorMessages.RecipeTagsCannotBeNull);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipesForTags(Session.Key, tags);
        }

        /// <inheritdoc/>
        public Recipe GetRecipe(int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetRecipe(Session.Key, recipeId);
        }

        /// <inheritdoc/>
        public Ingredient[] GetIngredientsForRecipe(int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetIngredientsForRecipe(Session.Key, recipeId);
        }

        /// <inheritdoc/>
        public RecipeStep[] GetStepsForRecipe(int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetStepsForRecipe(Session.Key, recipeId);
        }

        /// <inheritdoc/>
        public string[] GetTypesForRecipe(int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            return this.endpoints.GetTypesForRecipe(Session.Key, recipeId);
        }

        /// <inheritdoc/>
        public void AddRecipe(string name, string description, bool isPublic)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
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
            this.endpoints.AddRecipe(Session.Key, name, description, isPublic);
        }

        /// <inheritdoc/>
        public void RemoveRecipe(int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.endpoints.RemoveRecipe(Session.Key, recipeId);
        }

        /// <inheritdoc/>
        public void EditRecipe(int recipeId, string name, string description, bool isPublic)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key), SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
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
            this.endpoints.EditRecipe(Session.Key, recipeId, name, description, isPublic);
        }
    }
}
