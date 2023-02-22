using Shared_Resources.ErrorMessages;
using Web_Client.Endpoints.RecipeTypes;

namespace Web_Client.Service.RecipeTypes
{
    /// <summary>
    /// The recipe types service
    /// </summary>
    /// <seealso cref="Web_Client.Service.RecipeTypes.IRecipeTypesService" />
    public class RecipeTypesService : IRecipeTypesService
    {
        private readonly IRecipeTypesEndpoints endpoints;

        /// <summary>
        /// Precondition: None
        /// Postcondition: None
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.
        /// </summary>
        public RecipeTypesService()
        {
            this.endpoints = new RecipeTypesEndpoints();
        }

        /// <summary>
        /// Precondition: endpoints != null
        /// Postcondition: None
        /// 
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public RecipeTypesService(IRecipeTypesEndpoints endpoints)
        {
            if (endpoints == null)
            {
                throw new ArgumentException(RecipeTypesErrorMessages.EndpointsCannotBeNull);
            }

            this.endpoints = endpoints;
        }

        /// <summary>
        /// Gets the similar recipe types.
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>
        /// The similar recipe types
        /// </returns>
        public string[] GetAllRecipeTypes()
        {
            return this.endpoints.GetAllRecipeTypes();
        }
    }
}
