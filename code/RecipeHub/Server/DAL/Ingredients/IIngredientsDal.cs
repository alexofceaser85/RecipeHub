namespace Server.DAL.Ingredient
{
    /// <summary>
    /// Interface for the Data Access Layer to the Ingredients Table.
    /// </summary>
    public interface IIngredientsDal
    {
        /// <summary>
        /// Gets the ingredient names that match the specified text, including partial matches with a limit of 5.<br />
        ///<br />
        /// Precondition: ingredientName cannot be empty or whitespace.<br />
        /// Postcondition: None
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient to match to.</param>
        /// <returns>The list of closest matching ingredient names to the specified text.</returns>
        public IList<string> GetIngredientNamesThatMatchText(string ingredientName);

        /// <summary>
        /// Gets the ingredients for the specified user id. <br />
        ///<br />
        /// Precondition: session key must not be null<br />
        /// AND session key must be in the system.<br />
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session id for the user.</param>
        /// <returns>All the ingredients that the user has in their pantry.</returns>
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(string sessionKey);

        /// <summary>
        /// Adds the ingredient to system.<br />
        ///<br />
        /// Precondition: ingredient must not be in the system already.<br />
        /// Postcondition: ingredient is added to the system.
        /// </summary>
        /// <param name="ingredient">The ingredient being added.</param>
        /// <returns>whether the ingredient is added or not.</returns>
        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient);


        /// <summary>
        /// Adds the ingredient to pantry of the specified user.<br />
        ///<br />
        /// Precondition: session key must be in the system<br />
        /// AND session key must not be null<br />
        /// AND ingredient must be in the system already.<br />
        /// AND ingredient must not be in the user's pantry already.<br />
        /// Postcondition: ingredient is added to the user's pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient being added to the pantry.</param>
        /// <param name="sessionKey">The session key for the user.</param>
        /// <returns>whether the ingredient was added to the user's pantry or not.</returns>
        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey);


        /// <summary>
        /// Removes the ingredient from specified user's pantry.<br />
        ///<br />
        /// Precondition: session key must be in the system<br />
        /// session key must not be null<br />
        /// ingredient must be in the system<br />
        /// ingredient must be in the user's pantry<br />
        /// </summary>
        /// <param name="ingredient">The ingredient being removed from the pantry.</param>
        /// <param name="sessionKey">The session key for the user.</param>
        /// <returns>whether the ingredient was removed from the user's pantry or not</returns>
        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey);

        /// <summary>
        /// Updates the amount of an ingredient in the specified user's pantry.<br />
        ///<br />
        /// Precondition: session key must be in the system<br />
        /// session key must not be null<br />
        /// ingredient must be in the system<br />
        /// ingredient must be in the user's pantry<br />
        /// Postcondition: ingredient's amount is updated in the user's pantry.
        /// </summary>
        /// <param name="ingredient">The ingredient being updated in the pantry.</param>
        /// <param name="sessionKey">The session key for the user.</param>
        /// <returns>whether the ingredient was updated from the user's pantry or not</returns>
        public bool UpdateIngredientInPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey);

        /// <summary>
        /// Removes all ingredients from specified user's pantry.<br />
        ///<br />
        /// Precondition: user must be in the system<br />
        /// Postcondition: user's pantry has all ingredients removed.
        /// </summary>
        /// <param name="sessionKey">The session key for the user.</param>
        /// <returns>whether all the ingredients were removed or not.</returns>
        public bool RemoveAllIngredientsFromPantry(string sessionKey);

        /// <summary>
        /// Checks whether or not the ingredient is in the system.<br />
        /// Precondition: ingredient name must not be null<br />
        /// Postcondition: None.
        /// </summary>
        /// <param name="ingredientName">the name of the ingredient being checked.</param>
        /// <returns>whether the ingredient is in the system or not.</returns>
        public bool IsIngredientInSystem(string ingredientName);
    }
}
