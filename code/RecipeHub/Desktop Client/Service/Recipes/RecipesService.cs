using Desktop_Client.Endpoints.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.Service.Recipes
{
    /// <inheritdoc cref="IRecipesEndpoints"/>
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesEndpoints endpoints;

        /// <summary>
        /// Creates a default instance of <see cref="RecipesService"/>.<br/>
        /// Uses an instance of <see cref="RecipesEndpoints"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesService() : this(new RecipesEndpoints())
        {

        }
        
        /// <summary>
        /// Creates a instance of <see cref="RecipesService"/> with a specified <see cref="IRecipesEndpoints"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>endpoints != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesService(IRecipesEndpoints endpoints)
        {
            this.endpoints = endpoints ?? 
                             throw new ArgumentNullException(nameof(endpoints), RecipesServiceErrorMessages.RecipesEndpointsCannotBeNull);
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

            return this.endpoints.GetRecipes(sessionKey, searchTerm);
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

            this.endpoints.EditRecipe(sessionKey, recipeId, name, description, isPublic);
        }
    }
}
