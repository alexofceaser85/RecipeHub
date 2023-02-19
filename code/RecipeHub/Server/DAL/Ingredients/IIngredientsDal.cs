namespace Server.DAL.Ingredients
{
    /// <summary>
    /// Interface for the Data Access Layer to the Ingredients Table.
    /// </summary>
    public interface IIngredientsDal
    {
        /// <summary>
        /// Gets the ingredient names that match the specified text, including partial matches with a limit of 5.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient to match to.</param>
        /// <returns>The list of closest matching ingredient names to the specified text.</returns>
        public IList<string> GetIngredientNamesThatMatchText(string ingredientName);

        /// <summary>
        /// Gets the ingredients for the specified user id. <br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>All the ingredients that the user has in their pantry.</returns>
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(int userId);

        /// <summary>
        /// Adds the ingredient to system.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: ingredient is added to the system.
        /// </summary>
        /// <param name="ingredient">The ingredient being added.</param>
        /// <returns>whether the ingredient is added or not.</returns>
        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient);

        /// <summary>
        /// Adds the ingredient to pantry of the specified user.<br />
        /// <br />
        /// Precondition: None
        /// Postcondition: ingredient is added to the user's pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient being added to the pantry.</param>
        /// <param name="userId">The id for the user.</param>
        /// <returns>whether the ingredient was added to the user's pantry or not.</returns>
        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId);

        /// <summary>
        /// Removes the ingredient from specified user's pantry.<br />
        ///<br />
        /// Precondition: None.<br />
        /// Postcondition: ingredient is removed from the user's pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient being removed from the pantry.</param>
        /// <param name="userId">The id for the user.</param>
        /// <returns>whether the ingredient was removed from the user's pantry or not</returns>
        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId);

        /// <summary>
        /// Updates the amount of an ingredient in the specified user's pantry.<br />
        ///<br />
        /// Precondition: None.<br />
        /// Postcondition: ingredient's amount is updated in the user's pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient being updated in the pantry.</param>
        /// <param name="userId">The id for the user.</param>
        /// <returns>whether the ingredient was updated from the user's pantry or not</returns>
        public bool UpdateIngredientInPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId);

        /// <summary>
        /// Removes all ingredients from specified user's pantry.<br />
        ///<br />
        /// Precondition: None.<br />
        /// Postcondition: user's pantry has all ingredients removed.
        /// </summary>
        /// <param name="userId">The id for the user.</param>
        /// <returns>whether all the ingredients were removed or not.</returns>
        public bool RemoveAllIngredientsFromPantry(int userId);

        /// <summary>
        /// Checks whether or not the ingredient is in the system.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None.
        /// </summary>
        /// <param name="ingredientName">the name of the ingredient being checked.</param>
        /// <returns>whether the ingredient is in the system or not.</returns>
        public bool IsIngredientInSystem(string ingredientName);

        /// <summary>
        /// Checks whether the ingredient is in the specified user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None.
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient being checked.</param>
        /// <param name="userId">The id for the user.</param>
        /// <returns>whether the ingredient</returns>
        public bool IsIngredientInPantry(string ingredientName, int userId);

        /// <summary>
        /// Gets the ingredient id that matches the ingredient name.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <returns>The id matching the ingredientName, null if none is found.</returns>
        public int? GetIngredientIdFor(string ingredientName);
    }
}