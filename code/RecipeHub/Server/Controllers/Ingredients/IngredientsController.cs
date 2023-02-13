using Microsoft.AspNetCore.Mvc;
using Server.Service.Ingredients;

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


    }
}
