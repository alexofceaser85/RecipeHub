using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Controllers.Users;
using Server.Data.Settings;
using Server.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace Server.Controllers.RecipeTypes
{
    /// <summary>
    /// The controller for the recipe types
    /// </summary>
    public class RecipeTypesController
    {
        private readonly IRecipesTypesService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public RecipeTypesController()
        {
            this.service = new RecipeTypesService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesController"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        public RecipeTypesController(IRecipesTypesService service)
        {
            if (service == null)
            {
                throw new ArgumentException(RecipeTypesControllerErrorMessages.ServiceCannotBeNull);
            }

            this.service = service;
        }

        /// <summary>
        /// Gets similar recipe types.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The similar recipes</returns>
        [HttpGet]
        [Route("RecipeTypes")]
        public RecipeTypesResponseModel GetAllRecipeTypes()
        {
            try
            {
                return new RecipeTypesResponseModel(HttpStatusCode.OK,
                    ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetAllRecipeTypes());
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeTypesResponseModel(HttpStatusCode.Unauthorized, ex.Message, new string[0]);
            }
            catch (Exception ex)
            {
                return new RecipeTypesResponseModel(HttpStatusCode.InternalServerError, ex.Message, new string[0]);
            }
        }
    }
}
