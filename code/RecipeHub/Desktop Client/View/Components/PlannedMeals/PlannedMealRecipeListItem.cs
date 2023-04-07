using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Components.PlannedMeals
{
    /// <summary>
    /// Displays information about a recipe that's part of a planned meal.
    /// </summary>
    public partial class PlannedMealRecipeListItem : UserControl
    {
        /// <summary>
        /// The recipe that is being displayed
        /// </summary>
        public Recipe Recipe { get; }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealRecipeListItem"/> using a specified <see cref="Recipe"/>.<br/>
        /// Optionally allows tags to be passed in to be displayed before the recipe and author names.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>The recipe's information is displayed
        /// </summary>
        /// <param name="recipe">The recipe to display</param>
        /// <param name="tags">The tags for the recipe. None will be displayed if null or an empty array is passed in.</param>
        public PlannedMealRecipeListItem(Recipe recipe, string[]? tags = null)
        {
            this.InitializeComponent();
            this.Recipe = recipe;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.authorNameLabel.Text = recipe.AuthorName;
            this.recipeNameLabel.Text = recipe.Name;

            if (tags == null || tags.Length == 0)
            {
                return;
            }
            this.tagsLabel.Text = string.Join(", ", tags);
        }

        /// <summary>
        /// Occurs when the delete button is pressed.
        /// </summary>
        public EventHandler? DeletePressed;
        
        /// <summary>
        /// Occurs when the view button is pressed.
        /// </summary>
        public EventHandler? ViewPressed;


        private void removeButton_Click(object sender, EventArgs e)
        {
            this.DeletePressed?.Invoke(this, EventArgs.Empty);
        }

        private void viewRecipeButton_Click(object sender, EventArgs e)
        {
            this.ViewPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
