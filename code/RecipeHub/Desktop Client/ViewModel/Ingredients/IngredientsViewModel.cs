using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients
{
    /// <summary>
    /// View Model for the Ingredients.
    /// </summary>
    public class IngredientsViewModel
    {
        private readonly IIngredientsService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to default value.<br />
        /// </summary>
        public IngredientsViewModel()
        {
            this.service = new IngredientsService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to specified value.<br />
        /// </summary>
        /// <param name="service">The service.</param>
        public IngredientsViewModel(IIngredientsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all ingredients for user.
        /// </summary>
        /// <returns></returns>
        public IList<Ingredient> GetAllIngredientsForUser()
        {
            return this.service.GetAllIngredientsForUser();
        }
    }
}
