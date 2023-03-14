using Web_Client.ViewModel.Recipes;

namespace Web_Client.Model.States
{
    /// <summary>
    /// Holds the values for the Recipe page for necessity of maintaining values across requests.
    /// </summary>
    public static class RecipePageState
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public static RecipeViewModel? ViewModel { get; set; }
    }
}
