using System.Net;
using Server.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the planned meals
    /// </summary>
    public class PlannedMealsResponseModel
    {
        private string message;

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// The response message.
        /// </summary>
        public string Message
        {
            get => this.message;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeNull);
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
                }
                this.message = value;
            }
        }

        /// <summary>
        /// Gets or sets the planned meals.
        /// </summary>
        /// <value>
        /// The planned meals.
        /// </value>
        public PlannedMeal[]? PlannedMeals { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMealsResponseModel"/> class.
        ///
        /// Precondition: message != null AND message.isEmpty == false
        /// Postcondition: Code == code AND Message == message AND PlannedMeals == plannedMeals
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="plannedMeals">The planned meals.</param>
        public PlannedMealsResponseModel(HttpStatusCode code, string message, PlannedMeal[] plannedMeals)
        {
            if (message == null)
            {
                throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeNull);
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
            }

            this.Code = code;
            this.message = message;
            this.PlannedMeals = plannedMeals;
        }
    }
}
