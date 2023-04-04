namespace Desktop_Client.Service.RecipeTypes
{
    /// <summary>
    /// The recipe types service
    /// </summary>
    public interface IRecipeTypesService
    {
        /// <summary>
        /// Gets the similar recipe types.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <returns>The similar recipe types</returns>
        public string[] GetAllRecipeTypes();
    }
}
