namespace Desktop_Client.Endpoints.RecipeTypes
{
    /// <summary>
    /// The interface for the recipe types endpoints
    /// </summary>
    public interface IRecipeTypesEndpoints
    {
        /// <summary>
        /// Gets the similar recipe types.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <returns>The recipe types</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public string[] GetAllRecipeTypes();

    }
}
