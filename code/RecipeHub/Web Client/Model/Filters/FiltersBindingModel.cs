using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Model.Filters
{
    /// <summary>
    /// The binding model for the Filters
    /// </summary>
    public class FiltersBindingModel
    {
        /// <summary>
        /// Gets or sets the Filters types.
        /// </summary>
        /// <value>
        /// The Filters types.
        /// </value>
        [BindProperty]
        public List<string>? FiltersTypes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [only available ingredients].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [only available ingredients]; otherwise, <c>false</c>.
        /// </value>
        [BindProperty]
        public bool OnlyAvailableIngredients { get; set; }
    }
}
