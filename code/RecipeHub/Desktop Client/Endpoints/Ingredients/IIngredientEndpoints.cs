using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.Endpoints.Ingredients
{
    /// <summary>
    /// Interface for the Endpoints.
    /// </summary>
    public interface IIngredientEndpoints
    {
        /// <summary>
        /// Gets all ingredients for user.<br />
        ///<br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <returns>the ingredients for the currently logged in user.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Ingredient[] GetAllIngredientsForUser();

        /// <summary>
        /// Adds the specified ingredient to the logged in user's pantry.<br />
        /// <br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: Ingredient is added to system.<br />
        /// </summary>
        /// <param name="ingredient">the ingredient being added.</param>
        /// <returns>whether the ingredient was successfully added or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool AddIngredient(Ingredient ingredient);

        /// <summary>
        /// Adds multiple ingredients to a user's pantry. <br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; All ingredients in ingredients are present on the server<br/>
        /// <b>Postcondition: </b>Each ingredient is added to the user's pantry
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddIngredients(Ingredient[] ingredients);

        /// <summary>
        /// Deletes the specified ingredient from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: Ingredient is added to system.<br />
        /// </summary>
        /// <param name="ingredient">the ingredient being deleted.</param>
        /// <returns>whether the ingredient was successfully added or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool DeleteIngredient(Ingredient ingredient);

        /// <summary>
        /// Updates the specified ingredient in the logged in user's pantry.<br />
        /// <br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: Ingredient is updated in the system.<br />
        /// </summary>
        /// <returns>whether the ingredient was successfully updated or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool UpdateIngredient(Ingredient ingredient);

        /// <summary>
        /// Deletes all ingredient from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: All ingredients are removed from user's pantry.<br />
        /// </summary>
        /// <returns>whether all ingredient were successfully removed or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool DeleteAllIngredientsForUser();

        /// <summary>
        /// Gets the list of suggested ingredients based on the specified text.<br />
        /// <br />
        /// Precondition: The active user's session key is valid<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="ingredientName">the name being checked against for suggestions</param>
        /// <returns>the list of suggestions</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public string[] GetSuggestions(string ingredientName);

        /// <summary>
        /// Gets the ingredients that the active user is missing for a specified recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; A recipe exists with the specified id<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe</param>
        /// <returns>All of the ingredients that are missing for a recipe.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Ingredient[] GetMissingIngredientsForRecipe(int recipeId);

        /// <summary>
        /// Removes the ingredients for a specified recipe from the active user's pantry.<br/>
        /// If the user does not have enough of a specified ingredient, then that ingredient will be removed from the pantry.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; A recipe exists with the specified id<br/>
        /// <b>Postcondition: </b>The ingredients for the specified recipe are removed from the user's pantry, down to a minimum of 0
        /// </summary>
        /// <param name="recipeId">The id for the recipe</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveIngredientsForRecipe(int recipeId);
    }
}