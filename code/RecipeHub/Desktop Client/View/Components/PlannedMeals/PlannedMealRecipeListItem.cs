using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Components.PlannedMeals
{
    /// <summary>
    /// Displays information about a plannedRecipe that's part of a planned meal.
    /// </summary>
    public partial class PlannedMealRecipeListItem : UserControl
    {
        /// <summary>
        /// The plannedRecipe that is being displayed
        /// </summary>
        public PlannedRecipe PlannedRecipe { get; }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealRecipeListItem"/> using a specified <see cref="PlannedRecipe"/>.<br/>
        /// Optionally allows tags to be passed in to be displayed before the plannedRecipe and author names.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>The plannedRecipe's information is displayed
        /// </summary>
        /// <param name="plannedRecipe">The plannedRecipe to display</param>
        /// <param name="tags">The tags for the plannedRecipe. None will be displayed if null or an empty array is passed in.</param>
        public PlannedMealRecipeListItem(PlannedRecipe plannedRecipe, string[]? tags = null)
        {
            this.InitializeComponent();
            this.PlannedRecipe = plannedRecipe;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.authorNameLabel.Text = plannedRecipe.Recipe.AuthorName;
            this.recipeNameLabel.Text = plannedRecipe.Recipe.Name;

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
