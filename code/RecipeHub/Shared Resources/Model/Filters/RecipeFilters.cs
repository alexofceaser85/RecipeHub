namespace Shared_Resources.Model.Filters
{
    /// <summary>
    /// Stores the current Filters for a recipe search.
    /// </summary>
    public class RecipeFilters
    {
        /// <summary>
        /// Whether to only search for ingredients that the user has all the ingredients for.
        /// </summary>
        public bool OnlyAvailableIngredients { get; set; }
        /// <summary>
        /// Gets or sets the matching tag.
        /// </summary>
        /// <value>
        /// The only matching tag.
        /// </value>
        public string[] MatchTags { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipeFilters"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.OnlyAvailableIngredients == true
        /// </summary>
        public RecipeFilters()
        {
            this.OnlyAvailableIngredients = false;
            this.MatchTags = null!;
        }
    }
}