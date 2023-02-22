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
        public string? FiltersTypes { get; set; }
    }
}
