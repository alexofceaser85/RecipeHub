﻿using Shared_Resources.Model.Ingredients;

namespace Server.Service.Ingredients
{
    /// <summary>
    /// Interface for the Services for the Ingredients functionality.
    /// </summary>
    public interface IIngredientsService
    {
        /// <summary>
        /// Adds the specified ingredient to specified user's pantry.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND ingredient.Name != null<br />
        /// sessionKey must be active, and in system<br />
        /// AND ingredient must be in system<br />
        /// AND ingredient must not already be in user's pantry.<br />
        /// Postcondition: ingredient is added to user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient being added.</param>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>whether the ingredient was added successfully or not.</returns>
        public bool AddIngredientToPantry(Ingredient ingredient, string sessionKey);

        /// <summary>
        /// Adds all of the ingredients to the user's pantry.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND ingredients != null<br />
        /// sessionKey must be active, and in system<br />
        /// Postcondition: ingredient is added to user's pantry.<br />
        /// </summary>
        /// <param name="ingredients">The ingredients being added.</param>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>whether the ingredients were added successfully or not.</returns>
        public void AddIngredientsToPantry(Ingredient[] ingredients, string sessionKey);

        /// <summary>
        /// Gets the missing ingredients for recipe.
        ///
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The missing ingredients for the recipe</returns>
        public IList<Ingredient> GetMissingIngredientsForRecipe(int recipeId, string sessionKey);

        /// <summary>
        /// Removes the ingredients for recipe.
        ///
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="sessionKey">The session key.</param>
        public void RemoveIngredientsForRecipe(int recipeId, string sessionKey);

        /// <summary>
        /// Removes the specified ingredient from pantry.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND ingredient.Name != null<br />
        /// AND sessionKey must be active, and in system<br />
        /// AND ingredient must be in system<br />
        /// AND ingredient must be in user's pantry.<br />
        /// Postcondition: ingredient is removed from user's pantry<br />
        /// </summary>
        /// <param name="ingredient">The ingredient being removed.</param>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>whether the ingredient was removed successfully or not.</returns>
        public bool RemoveIngredientFromPantry(Ingredient ingredient, string sessionKey);

        /// <summary>
        /// Updates the amount of the specified ingredient in specified user's pantry.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND ingredient.Name != null<br />
        /// AND sessionKey must be active, and in system<br />
        /// AND ingredient must be in system<br />
        /// AND ingredient must be in user's pantry.<br />
        /// Postcondition: ingredient's amount is updated in user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient being updated.</param>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>whether the ingredient was updated successfully or not.</returns>
        public bool UpdateIngredientInPantry(Ingredient ingredient, string sessionKey);

        /// <summary>
        /// Removes all ingredients from the specified user's pantry.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND sessionKey must be active, and in system.<br />
        /// Postcondition: All ingredients are removed from user's pantry.<br />
        /// </summary>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>whether all the ingredients were removed or not.</returns>
        public bool RemoveAllIngredientsFromPantry(string sessionKey);

        /// <summary>
        /// Gets a collection of suggested ingredients that match the inputted text.<br />
        /// <br />
        /// Precondition: ingredientName != null<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient being checked.</param>
        /// <returns>the list of suggested ingredients.</returns>
        public IList<string> GetAllIngredientsThatMatch(string ingredientName);

        /// <summary>
        /// Gets all of the ingredients for the specified user.<br />
        /// <br />
        /// Precondition: sessionKey != null<br />
        /// AND sessionKey must be active, and in system.<br />
        /// Postcondition: None.<br />
        /// </summary>
        /// <param name="sessionKey">The session key to identify the user.</param>
        /// <returns>the list of all ingredients for the user.</returns>
        public IList<Ingredient> GetIngredientsFor(string sessionKey);
    }
}
