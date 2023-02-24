using Desktop_Client.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;

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
        /// Initializes a new instance of the <see cref="RecipeTypesViewModel"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public RecipeTypesViewModel(IRecipeTypesService service)
        {
            if (service == null)
            {
                throw new ArgumentException(RecipeTypesViewModelErrorMessages.ServiceCannotBeNull);
            }

            this.service = service;
        }

        /// <summary>
        /// Gets all of the recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>All of the recipe types</returns>
        public string[] GetAllRecipeTypes()
        {
            return this.service.GetAllRecipeTypes();
        }
    }
}
