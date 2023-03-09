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
        /// Creates an instance of 
        /// </summary>
        /// <param name="recipe"></param>
        public PlannedMealRecipeListItem(Recipe recipe)
        {
            this.InitializeComponent();
            this.Recipe = recipe;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.authorNameLabel.Text = recipe.AuthorName;
            this.recipeNameLabel.Text = recipe.Name;
        }

        /// <summary>
        /// Occurs when the delete button is pressed.
        /// </summary>
        public EventHandler? DeletePressed;

        private void removeButton_Click(object sender, EventArgs e)
        {
            this.DeletePressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
