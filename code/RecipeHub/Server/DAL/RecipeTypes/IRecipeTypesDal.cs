namespace Server.DAL.RecipeTypes
{
    /// <summary>
    /// The data access layer for the recipe types
    /// </summary>
    public interface IRecipeTypesDal
    {
        /// <summary>
        /// Gets the similar recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="partialString">The partial string.</param>
        /// <returns>The similar recipe types</returns>
        public string[] GetSimilarRecipeTypes();
    }
}
