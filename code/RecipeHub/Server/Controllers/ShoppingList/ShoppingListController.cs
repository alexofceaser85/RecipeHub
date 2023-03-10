using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.ShoppingList;
using Shared_Resources.Model.Ingredients;

namespace Server.Controllers.ShoppingList
{
    /// <summary>
    /// The shopping list controller
    /// </summary>
    public class ShoppingListController
    {
        private readonly IShoppingListService service;

        /// <summary>
        /// The shopping list container
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public ShoppingListController()
        {
            this.service = new ShoppingListService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListController"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The shopping list service</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public ShoppingListController(IShoppingListService service)
        {
            if (service == null)
            {
                throw new ArgumentException(ShoppingListControllerErrorMessages.ShoppingListServiceCannotBeNull);
            }

            this.service = service;
        }

        /// <summary>
        /// Gets the shopping list ingredients.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The shopping list ingredients</returns>
        [HttpGet]
        [Route("GetShoppingListIngredients")]
        public RecipeIngredientsResponseModel GetShoppingListIngredients(string sessionKey)
        {
            try
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.OK,
                    ServerSettings.DefaultSuccessfulConnectionMessage,
                    this.service.GetShoppingListIngredients(sessionKey));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.Unauthorized, ex.Message, Array.Empty<Ingredient>());
            }
            catch (Exception ex)
            {
                return new RecipeIngredientsResponseModel(HttpStatusCode.InternalServerError, ex.Message,
                    Array.Empty<Ingredient>());
            }
        }
    }
}
