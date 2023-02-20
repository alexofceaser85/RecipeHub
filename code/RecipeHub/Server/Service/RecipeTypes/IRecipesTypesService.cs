namespace Server.Service.RecipeTypes
{
    /// <summary>
    /// The service for the recipe types
    /// </summary>
    public interface IRecipesTypesService
    {
        /// <summary>
        /// Gets the similar recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The similar recipe types</returns>
        public string[] GetSimilarRecipeTypes();
    }
}
