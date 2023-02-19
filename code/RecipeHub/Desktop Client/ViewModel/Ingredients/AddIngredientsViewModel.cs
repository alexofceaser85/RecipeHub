using Desktop_Client.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients
{
    /// <summary>
    /// View Model for the Add Ingredients.
    /// </summary>
    public class AddIngredientsViewModel
    {
        private readonly IIngredientsService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to default value.<br />
        /// </summary>
        public AddIngredientsViewModel()
        {
            this.service = new IngredientsService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to specified value.<br />
        /// </summary>
        /// <param name="service">the specified service</param>
        public AddIngredientsViewModel(IIngredientsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds the specified ingredient to the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: The ingredient is added to the logged in user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns>Whether the ingredient was successfully added or not.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            try
            {
                return this.service.AddIngredient(ingredient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the suggestions for the ingredients based on the inputted text.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <returns>The list of suggestions.</returns>
        public string[] GetSuggestions(string ingredientName)
        {
            return this.service.GetSuggestions(ingredientName);
        }
    }
}