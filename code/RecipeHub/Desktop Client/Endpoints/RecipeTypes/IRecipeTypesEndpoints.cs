namespace Desktop_Client.Endpoints.RecipeTypes
{
    /// <summary>
    /// The interface for the recipe types endpoints
    /// </summary>
    public interface IRecipeTypesEndpoints
    {
        /// <summary>
        /// Gets the similar recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The recipe types</returns>
        public string[] GetAllRecipeTypes();

    }
}
