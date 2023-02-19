using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.Service.Recipes
{
    /// <summary>
    /// Contains methods for interacting with recipes through an endpoint.
    /// </summary>
    public interface IRecipesService
    {
        /// <summary>
        /// Gets all of the visible recipes for the active user that match the search term.<br/>
        /// If the search term is empty, all recipes will be fetched<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(Session.Key) &amp;&amp; searchTerm != null<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="sessionKey">The session key for the current user.</param>
        /// <param name="searchTerm">The string to search recipe names for. Default to an empty string.</param>
        /// <returns>An array containing all visible recipes that match the search term.</returns>
        public Recipe[] GetRecipes(string searchTerm = "");

        /// <summary>
        /// Gets a recipe from the server with a specified recipeId.<br/>
        /// The account associated with the session key must by the author if the recipe is private.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(Session.Key)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe.</param>
        /// <returns>The queried recipe</returns>
        public Recipe GetRecipe(int recipeId);

        /// <summary>
        /// Gets all of the ingredients for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe.</param>
        /// <returns>The ingredients for the recipe.</returns>
        public Ingredient[] GetIngredientsForRecipe(int recipeId);

        /// <summary>
        /// Gets the steps for recipe.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns></returns>
        public RecipeStep[] GetStepsForRecipe(int recipeId);

        /// <summary>
        /// Adds a recipe to the system, authored by the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(Session.Key)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        public void AddRecipe(string name, string description, bool isPublic);

        /// <summary>
        /// Removes a recipe from the database, if the user is the author of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(Session.Key)<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to remove.</param>
        public void RemoveRecipe(int recipeId);

        /// <summary>
        /// Edits a recipe, updating the name, description, and public status.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(Session.Key)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to update.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        public void EditRecipe(int recipeId, string name, string description, bool isPublic);
    }
}
