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
        private readonly RecipeViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="Screen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeScreen(int recipeId)
        {
            this.InitializeComponent();
            this.viewModel = new RecipeViewModel();
            this.LoadRecipe(recipeId);
            this.LoadIngredients(recipeId);
            this.LoadInstructions(recipeId);
        }

        private void LoadRecipe(int recipeId)
        {
            var recipe = this.viewModel.LoadRecipe(recipeId);
            this.recipieNameLabel.Text = recipe.Name;
            this.authorNameLabel.Text = recipe.AuthorName;
            this.userRatingLabel.Text = @$"User Ratings: {recipe.Rating}/5";
            this.descriptionLabel.Text = recipe.Description;
        }

        private void LoadIngredients(int recipeId)
        {
            var ingredients = this.viewModel.LoadIngredients(recipeId);
            if (ingredients.Length == 0)
            {
                this.ingredientsListLabel.Text = @"No ingredients have been added... Yet!";
                return;
            }

            this.ingredientsListLabel.Text = "";
            foreach (var ingredient in ingredients)
            {
                this.ingredientsListLabel.Text += $"{ingredient.Name} - {ingredient.Amount} {ingredient.MeasurementType}\n";
            }
        }

        private void LoadInstructions(int recipeId)
        {
            var steps = this.viewModel.LoadSteps(recipeId);
            if (steps.Length == 0)
            {
                this.stepsLabel.Text = @"No steps have been added... Yet!";
                return;
            }

            this.stepsLabel.Text = "";
            foreach (var step in steps)
            {
                this.stepsLabel.Text += $"{step.StepNumber}: {step.Name}\n{step.Instructions}\n\n";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChangeScreens(new RecipeListScreen());
        }

        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            ToggleHamburgerMenu();
        }
    }
}