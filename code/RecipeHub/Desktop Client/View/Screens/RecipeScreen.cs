using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Data.UserData;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class RecipeScreen : Screen
    {
        private readonly RecipesViewModel viewModel;
        /// <summary>
        /// Creates a default instance of <see cref="Screen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeScreen(int recipeId)
        {
            this.InitializeComponent();
            this.viewModel = new RecipesViewModel();
            this.LoadRecipe(recipeId);
        }

        private void LoadRecipe(int recipeId)
        {
            var recipe = this.viewModel.LoadRecipe(Session.Key!, recipeId);
            this.recipieNameLabel.Text = recipe.Name;
            this.authorNameLabel.Text = recipe.AuthorName;
            this.userRatingLabel.Text = $"User Ratings: {recipe.Rating}/5";
            this.descriptionLabel.Text = recipe.Description;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            base.ChangeScreens(new RecipeListScreen());
        }
    }
}
