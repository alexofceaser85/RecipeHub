using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace Server.Controllers.PlannedMeals
{
    /// <summary>
    /// The controller for the planned meals
    /// </summary>
    [ApiController]
    public class PlannedMealsController
    {
        private readonly IPlannedMealsService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMealsController"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public PlannedMealsController()
        {
            this.service = new PlannedMealsService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMealsController"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        public PlannedMealsController(IPlannedMealsService service)
        {
            this.service = service ?? throw new ArgumentException(PlannedMealsControllerErrorMessages.PlannedMealsServiceCannotBeNull);
        }

        /// <summary>
        /// Adds the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        [HttpPost]
        [Route("AddPlannedMeal")]
        public BaseResponseModel AddPlannedMeal(string sessionKey, DateTime mealDate, MealCategory category, int recipeId)
        {
            try
            {
                this.service.AddPlannedMeal(sessionKey, mealDate, category, recipeId);
                return new BaseResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);
            }
            catch (UnauthorizedAccessException ex)
            {
                return new BaseResponseModel(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Removes the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>\
        /// <param name="mealId">The meal identifier.</param>
        [HttpPost]
        [Route("RemovePlannedMeal")]
        public BaseResponseModel RemovePlannedMeal(string sessionKey, int mealId)
        {
            try
            {
                this.service.RemovePlannedMeal(sessionKey, mealId);
                return new BaseResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage);
            }
            catch (UnauthorizedAccessException ex)
            {
                return new BaseResponseModel(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets the planned meals.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="currentDate">The current date</param>
        /// <returns>The planned meals</returns>
        [HttpGet]
        [Route("GetPlannedMeals")]
        public PlannedMealsResponseModel GetPlannedMeals(string sessionKey, DateTime currentDate)
        {
            try
            {
                return new PlannedMealsResponseModel(HttpStatusCode.OK,
                    ServerSettings.DefaultSuccessfulConnectionMessage, this.service.GetPlannedMeals(sessionKey, currentDate));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new PlannedMealsResponseModel(HttpStatusCode.Unauthorized, ex.Message, null!);
            }
            catch (Exception ex)
            {
                return new PlannedMealsResponseModel(HttpStatusCode.InternalServerError, ex.Message, null!);
            }
        }
    }
}
