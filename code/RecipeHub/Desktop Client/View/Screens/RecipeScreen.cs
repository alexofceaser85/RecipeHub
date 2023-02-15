using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;

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
            this.LoadIngredients(recipeId);
        }

        private void LoadRecipe(int recipeId)
        {
            var recipe = this.viewModel.LoadRecipe(Session.Key!, recipeId);
            this.recipieNameLabel.Text = recipe.Name;
            this.authorNameLabel.Text = recipe.AuthorName;
            this.userRatingLabel.Text = $"User Ratings: {recipe.Rating}/5";
            this.descriptionLabel.Text = recipe.Description;
        }

        private void LoadIngredients(int recipeId)
        {
            var ingredients = this.viewModel.LoadIngredients(Session.Key!, recipeId);
            if (ingredients.Length == 0)
            {
                this.ingredientsListLabel.Text = "No ingredients have been added... Yet!";
                return;
            }

            this.ingredientsListLabel.Text = "";
            foreach (var ingredient in ingredients)
            {
                this.ingredientsListLabel.Text += $"{ingredient.Name} - {ingredient.Amount} {ingredient.MeasurementType}\n";
            }
        }
        
        private void backButton_Click(object sender, EventArgs e)
        {
            base.ChangeScreens(new RecipeListScreen());
        }

        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }
    }
}
