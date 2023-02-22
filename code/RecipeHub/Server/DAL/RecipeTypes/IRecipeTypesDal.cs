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
        /// <returns>The similar recipe types</returns>
        ///
        public string[] GetAllRecipeTypes();
        /// <summary>
        /// Gets the name of the type identifier.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>The name of the type</returns>
        public int? GetTypeIdForTypeName(string typeName);

        /// <summary>
        /// Gets the recipe identifier for type identifier.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>The recipe id</returns>
        public int[] GetRecipeIdsForTypeId(int typeId);
    }
}
