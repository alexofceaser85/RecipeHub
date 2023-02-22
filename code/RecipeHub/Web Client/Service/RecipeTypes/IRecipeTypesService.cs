namespace Web_Client.Service.RecipeTypes
{
    /// <summary>
    /// The recipe types service
    /// </summary>
    public interface IRecipeTypesService
    {
        /// <summary>
        /// Gets the similar recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The similar recipe types</returns>
        public string[] GetAllRecipeTypes();
    }
}
