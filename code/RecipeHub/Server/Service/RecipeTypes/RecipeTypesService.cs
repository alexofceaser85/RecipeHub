using Server.DAL.RecipeTypes;

namespace Server.Service.RecipeTypes
{
    /// <summary>
    /// The service for the recipe types
    /// </summary>
    public class RecipeTypesService : IRecipesTypesService
    {
        private IRecipeTypesDal recipeTypesDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public RecipeTypesService()
        {
            this.recipeTypesDal = new RecipeTypesDal();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.
        ///
        /// Precondition: recipeTypesDal != null
        /// Postcondition: None
        /// </summary>
        /// <param name="recipeTypesDal">The recipe types dal.</param>
        public RecipeTypesService(IRecipeTypesDal recipeTypesDal)
        {
            this.recipeTypesDal = recipeTypesDal;
        }

        /// <summary>
        /// Gets the similar recipe types.
        /// Precondition:
        /// partialRecipeType != null
        /// AND partialRecipeType IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <returns>
        /// The similar recipe types
        /// </returns>
        public string[] GetSimilarRecipeTypes()
        {
            return this.recipeTypesDal.GetSimilarRecipeTypes();
        }
    }
}
