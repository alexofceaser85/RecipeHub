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
        /// Gets all ingredients for user.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <returns>the list of all ingredients for the user.</returns>
        public IList<Ingredient> GetAllIngredientsForUser()
        {
            return this.service.GetAllIngredientsForUser();
        }

        /// <summary>
        /// Removes the specified ingredient.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Removes the ingredients from the logged in user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns>Whether the ingredient was removed or not.</returns>
        public bool RemoveIngredient(Ingredient ingredient)
        {
            return this.service.DeleteIngredient(ingredient);
        }

        /// <summary>
        /// Removes all ingredients from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Removes all ingredients from the logged in user's pantry.<br />
        /// </summary>
        /// <returns>Whether all ingredients were removed or not.</returns>
        public bool RemoveAllIngredients()
        {
            return this.service.DeleteAllIngredientsForUser();
        }
    }
}