using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.ResponseModels;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Server.Controllers.Ingredients
{
    /// <summary>
    /// Controller for the API Endpoints pertaining to the Ingredients functionality.
    /// </summary>
    [ApiController]
    public class IngredientsController
    {
        private readonly IIngredientsService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsController"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All fields have been initialized to default values.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public IngredientsController()
        {
            this.service = new IngredientsService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsController"/> class.<br />
        /// <br />
        /// Precondition: service != null.<br />
        /// Postcondition: All fields have been set to specified values.<br />
        /// </summary>
        /// <param name="service">The service to use for the different API routes.</param>
        /// <exception cref="ArgumentNullException">If service is null.</exception>
        public IngredientsController(IIngredientsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Adds the specified ingredient to the specified user's pantry.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: The ingredient has been added to the user's pantry.<br />
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="measurementType">Type of the measurement.</param>
        /// <param name="amount">The amount of the ingredient being added.</param>
        /// <param name="sessionKey">The session key for the specified user.</param>
        /// <returns>A response to the client, containing a flag dictating whether the ingredient was added or not.</returns>
        [HttpPost]
        [Route("AddIngredientToPantry")]
        public FlagResponseModel AddIngredientToPantry(string name, int measurementType, int amount, string sessionKey)
        {
            try
            {
                return new FlagResponseModel(HttpStatusCode.OK, "Ingredient successfully added.",
                    this.service.AddIngredientToPantry(new Ingredient(name, amount, (MeasurementType)measurementType),
                        sessionKey));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new FlagResponseModel(HttpStatusCode.Unauthorized, ex.Message, false);
            }
            catch (Exception ex)
            {
                return new FlagResponseModel(HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }

        /// <summary>
        /// Removes the specified ingredient from the specified user's pantry.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: The ingredient has been removed from the user's pantry.<br />
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="measurementType">Type of the measurement.</param>
        /// <param name="amount">The amount of the ingredient being added.</param>
        /// <param name="sessionKey">The session key for the specified user.</param>
        /// <returns>A response to the client, containing a flag dictating whether the ingredient was removed or not</returns>
        [HttpPost]
        [Route("RemoveIngredientFromPantry")]
        public FlagResponseModel RemoveIngredientFromPantry(string name, int measurementType, int amount,
            string sessionKey)
        {
            try
            {
                return new FlagResponseModel(HttpStatusCode.OK, "Ingredient successfully removed from pantry.",
                    this.service.RemoveIngredientFromPantry(
                        new Ingredient(name, amount, (MeasurementType)measurementType),
                        sessionKey));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new FlagResponseModel(HttpStatusCode.Unauthorized, ex.Message, false);
            }
            catch (Exception ex)
            {
                return new FlagResponseModel(HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }

        /// <summary>
        /// Updates the amount of the specified ingredient in the specified user's pantry.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: The ingredient has been updated in the user's pantry.<br />
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="measurementType">Type of the measurement.</param>
        /// <param name="amount">The amount of the ingredient being added.</param>
        /// <param name="sessionKey">The session key for the specified user.</param>
        /// <returns>A response to the client, containing a flag dictating whether the ingredient was updated or not</returns>
        [HttpPost]
        [Route("UpdateIngredientInPantry")]
        public FlagResponseModel UpdateIngredientInPantry(string name, int measurementType, int amount,
            string sessionKey)
        {
            try
            {
                return new FlagResponseModel(HttpStatusCode.OK, "Ingredient successfully updated.",
                    this.service.UpdateIngredientInPantry(
                        new Ingredient(name, amount, (MeasurementType)measurementType),
                        sessionKey));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new FlagResponseModel(HttpStatusCode.Unauthorized, ex.Message, false);
            }
            catch (Exception ex)
            {
                return new FlagResponseModel(HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }

        /// <summary>
        /// Removes all ingredients from the specified user's pantry.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: All ingredients have been removed from the user's pantry.<br />
        /// </summary>
        /// <param name="sessionKey">The session key for the specified user.</param>
        /// <returns>A response to the client, containing a flag dictating whether all ingredients were removed or not</returns>
        [HttpPost]
        [Route("RemoveAllIngredientsFromPantry")]
        public FlagResponseModel RemoveAllIngredientsFromPantry(string sessionKey)
        {
            try
            {
                return new FlagResponseModel(HttpStatusCode.OK, "Pantry successfully cleared.",
                    this.service.RemoveAllIngredientsFromPantry(sessionKey));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new FlagResponseModel(HttpStatusCode.Unauthorized, ex.Message, false);
            }
            catch (Exception ex)
            {
                return new FlagResponseModel(HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }

        /// <summary>
        /// Gets all ingredients in the specified user's pantry.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="sessionKey">The session key for the specified user.</param>
        /// <returns>A response to the client, containing the list of all ingredients the specified user has.</returns>
        [HttpGet]
        [Route("GetIngredientsInPantry")]
        public PantryResponseModel GetIngredientsInPantry(string sessionKey)
        {
            try
            {
                return new PantryResponseModel(HttpStatusCode.OK, "Ingredients successfully retrieved.",
                    this.service.GetIngredientsFor(sessionKey).ToArray());
            }
            catch (UnauthorizedAccessException ex)
            {
                return new PantryResponseModel(HttpStatusCode.Unauthorized, ex.Message, null);
            }
            catch (Exception ex)
            {
                return new PantryResponseModel(HttpStatusCode.InternalServerError, ex.Message, null);
            }
        }

        /// <summary>
        /// Gets all suggestions for ingredients that matched inputted text.<br />
        /// <br />
        /// Precondition: None.<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="text">The text the suggestions will match.</param>
        /// <returns>A response to the client, containing the list of suggestions that match the text given.</returns>
        [HttpGet]
        [Route("GetSuggestions")]
        public SuggestionResponseModel GetSuggestions(string text = "")
        {
            try
            {
                return new SuggestionResponseModel(HttpStatusCode.OK, "Suggestions successfully retrieved.",
                    this.service.GetAllIngredientsThatMatch(text));
            }
            catch (UnauthorizedAccessException ex)
            {
                return new SuggestionResponseModel(HttpStatusCode.Unauthorized, ex.Message, new List<string>());
            }
            catch (Exception ex)
            {
                return new SuggestionResponseModel(HttpStatusCode.InternalServerError, ex.Message, new List<string>());
            }
        }
    }
}
