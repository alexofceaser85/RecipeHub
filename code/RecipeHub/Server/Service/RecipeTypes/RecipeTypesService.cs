using Server.DAL.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace Server.Service.RecipeTypes
{
    /// <summary>
    /// The service for the recipe types
    /// </summary>
    public class RecipeTypesService : IRecipesTypesService
    {
        private readonly IRecipeTypesDal recipeTypesDal;

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
            if (recipeTypesDal == null)
            {
                throw new ArgumentException(RecipeTypesServiceErrorMessages.DalCannotBeNull);
            }
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
        public string[] GetAllRecipeTypes()
        {
            return this.recipeTypesDal.GetAllRecipeTypes();
        }
    }
}
