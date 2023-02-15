using Shared_Resources.Model.Recipes;

namespace Server.Service.Recipes
{
    /// <summary>
    /// Contains methods for interfacing with the 
    /// </summary>
    public interface IRecipesService
    {
        /// <summary>
        /// Gets all of the recipes visible to the user that have the search term in its name.<br/>
        /// If no search term is provided, all visible recipes are fetched.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key for the active user.</param>
        /// <param name="searchTerm">The term to search for. Defaults to an empty string.</param>
        /// <returns>An array containing all visible recipes that match the search term.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public Recipe[] GetRecipes(string sessionKey, string searchTerm = "");
        
        public Recipe GetRecipe(string sessionKey, int recipeId);

        /// <summary>
        /// Attempts to add a recipe to the database.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key for the active user.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description for the recipe.</param>
        /// <param name="isPublic">Whether or not the recipe is publicly viewable.</param>
        /// <returns>Whether the recipe was successfully added or not.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public bool AddRecipe(string sessionKey, string name, string description, bool isPublic);

        /// <summary>
        /// Attempts to remove a recipe from the database.<br/>
        /// Recipes will only be removed if the user the session key is associated with is the creator of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; The user is the author of the recipe<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key for the active user.</param>
        /// <param name="recipeId">The ID of the recipe to remove.</param>
        /// <returns>Whether the recipe was successfully added to the database or not.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public bool RemoveRecipe(string sessionKey, int recipeId);

        /// <summary>
        /// Updates the current information of a recipe.<br/>
        /// Recipes will only be updated if the user the session key is associated with is the creator of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// &amp;&amp; The user is the author of the recipe<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key for the active user.</param>
        /// <param name="recipeId">The ID for the recipe to update.</param>
        /// <param name="name">The new name for the recipe.</param>
        /// <param name="description">The new description for the recipe.</param>
        /// <param name="isPublic">Whether the recipe is publicly viewable or not.</param>
        /// <returns>Whether the recipe was successfully edited or not.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public bool EditRecipe(string sessionKey, int recipeId, string name, string description, bool isPublic);
    }
}
