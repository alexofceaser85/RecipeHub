using Desktop_Client.Service.RecipeTypes;

namespace Desktop_Client.ViewModel.RecipeTypes
{
    /// <summary>
    /// The view model for the recipe types
    /// </summary>
    public class RecipeTypesViewModel
    {
        private readonly IRecipeTypesService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesViewModel"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public RecipeTypesViewModel()
        {
            this.service = new RecipeTypesService();
        }

        /// <summary>
        /// Gets all of the recipe types.
        /// </summary>
        /// <returns>All of the recipe types</returns>
        public string[] GetAllRecipeTypes()
        {
            return this.service.GetAllRecipeTypes();
        }
    }
}
