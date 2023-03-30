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
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <returns>the ingredients for the currently logged in user.</returns>
        public Ingredient[] GetAllIngredientsForUser();

        /// <summary>
        /// Adds the specified ingredient to the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Ingredient is added to system.<br />
        /// </summary>
        /// <param name="ingredient">the ingredient being added.</param>
        /// <returns>whether the ingredient was successfully added or not.</returns>
        public bool AddIngredient(Ingredient ingredient);

        /// <summary>
        /// Adds multiple ingredients to a user's pantry. <br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>Each ingredient is added to the user's pantry
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        /// <returns>Whether the ingredient was successfully added</returns>
        public bool AddIngredients(Ingredient[] ingredients);

        /// <summary>
        /// Deletes the specified ingredient from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Ingredient is added to system.<br />
        /// </summary>
        /// <param name="ingredient">the ingredient being deleted.</param>
        /// <returns>whether the ingredient was successfully added or not.</returns>
        public bool DeleteIngredient(Ingredient ingredient);

        /// <summary>
        /// Updates the specified ingredient in the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Ingredient is updated in the system.<br />
        /// </summary>
        /// <returns>whether the ingredient was successfully updated or not.</returns>
        public bool UpdateIngredient(Ingredient ingredient);

        /// <summary>
        /// Deletes all ingredient from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All ingredients are removed from user's pantry.<br />
        /// </summary>
        /// <returns>whether all ingredient were successfully removed or not.</returns>
        public bool DeleteAllIngredientsForUser();

        /// <summary>
        /// Gets the list of suggested ingredients based on the specified text.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="ingredientName">the name being checked against for suggestions</param>
        /// <returns>the list of suggestions</returns>
        public string[] GetSuggestions(string ingredientName);
    }
}