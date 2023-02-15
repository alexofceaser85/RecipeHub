using Microsoft.AspNetCore.Mvc;
using Shared_Resources.Model.Ingredients;

namespace Web_Client.Model.Ingredients
{
    /// <summary>
    /// Binding Model for the Ingredient
    /// </summary>
    public class IngredientBindingModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [BindProperty]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [BindProperty]
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the type of the measurement.
        /// </summary>
        /// <value>
        /// The type of the measurement.
        /// </value>
        [BindProperty]
        public MeasurementType MeasurementType { get; set; }
    }
}
