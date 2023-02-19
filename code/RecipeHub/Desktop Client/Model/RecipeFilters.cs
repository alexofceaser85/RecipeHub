namespace Desktop_Client.Model
{
    /// <summary>
    /// Stores the current filters for a recipe search.
    /// </summary>
    public struct RecipeFilters
    {
        /// <summary>
        /// Whether to only search for ingredients that the user has all the ingredients for.
        /// </summary>
        public bool OnlyAvailableIngredients { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipeFilters"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.OnlyAvailableIngredients == true
        /// </summary>
        public RecipeFilters()
        {
            this.OnlyAvailableIngredients = false;
        }
    }
}