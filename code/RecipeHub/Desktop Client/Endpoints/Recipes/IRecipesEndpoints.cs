using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.Endpoints.Recipes
{
    /// <summary>
    /// Contains methods for interacting with the Recipes HTTP API
    /// </summary>
    public interface IRecipesEndpoints
    {
        /// <summary>
        /// Gets all of the visible recipes for the active user that match the search term.<br/>
        /// If the search term is empty, all recipes will be fetched<br/>
        /// <br/>
        /// <b>Precondition: </b> The active user's session key is valid.<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="searchTerm">The string to search recipe names for. Default to an empty string.</param>
        /// <returns>An array containing all visible recipes that match the search term.</returns>
        public Recipe[] GetRecipes(string searchTerm = "");

        /// <summary>
        /// Gets all of the recipes with the given tags<br/>
        /// <br/>
        /// Precondition: The active user's session key is valid<br/>
        /// Postcondition: None<br/>
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <returns>The recipes with the given tags</returns>
        public Recipe[] GetRecipesForTags(string[] tags);

        /// <summary>
        /// Gets a recipe from the server with a specified recipeId.<br/>
        /// The account associated with the session key must by the author if the recipe is private.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid and the user has access to the recipe<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The recipe id for the recipe to fetch</param>
        /// <returns>The recipe</returns>
        public Recipe GetRecipe(int recipeId);

        /// <summary>
        /// Gets all of the ingredients for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid and the user has access to the recipe.<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe.</param>
        /// <returns>The ingredients for the recipe.</returns>
        public Ingredient[] GetIngredientsForRecipe(int recipeId);

        /// <summary>
        /// Gets all of the steps for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid and the user has access to the recipe.<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe.</param>
        /// <returns>The steps for the recipe.</returns>
        public RecipeStep[] GetStepsForRecipe(int recipeId);

        /// <summary>
        /// Gets all of the types for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid and the user has access to the recipe.<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe.</param>
        /// <returns>The types for the recipe.</returns>
        public string[] GetTypesForRecipe(int recipeId);

        /// <summary>
        /// Adds a recipe to the system, authored by the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// &amp;&amp; The active user's session key is valid
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        public void AddRecipe(string name, string description, bool isPublic);

        /// <summary>
        /// Removes a recipe from the database, if the user is the author of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; The active user's session key is valid
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to remove.</param>
        public void RemoveRecipe(int recipeId);

        /// <summary>
        /// Edits a recipe, updating the name, description, and public status.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// &amp;&amp; The active user's session key is valid
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to update.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        public void EditRecipe(int recipeId, string name, string description, bool isPublic);
    }
}