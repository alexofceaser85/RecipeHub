using Web_Client.Service.Ingredients;

namespace Web_Client.ViewModel.Ingredient
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
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetAllIngredientsForUser()
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
        public bool RemoveIngredient(Shared_Resources.Model.Ingredients.Ingredient ingredient)
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

        /// <summary>
        /// Adds the specified ingredient to the logged in user's pantry.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: The ingredient is added to the logged in user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns>Whether the ingredient was successfully added or not.</returns>
        public bool AddIngredient(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {
            try
            {
                return this.service.AddIngredient(ingredient);
            }
            catch (Exception e)
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

        /// <summary>
        /// Edits the ingredient.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Ingredient has been updated.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns>True if the ingredient was edited, false otherwise.</returns>
        public bool EditIngredient(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {
            return this.service.UpdateIngredient(ingredient);
        }
    }
}
