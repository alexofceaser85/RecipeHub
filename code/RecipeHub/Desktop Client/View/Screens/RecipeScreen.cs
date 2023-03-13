using Desktop_Client.View.Dialog;
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
            this.BindComponents();
            this.viewModel.Initialize(recipeId);
        }

        private void BindComponents()
        {
            this.recipieNameLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.RecipeName)));
            this.authorNameLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.AuthorName)));
            this.tagsPlaceholderLabel.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Tags)));
            this.descriptionLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.Description)));
            this.ingredientsListLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.Ingredients)));
            this.stepsLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.Instructions)));
            this.userRatingLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.UserRatingText)));
            this.yourRatingLabel.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.YourRatingText)));
        }

        private void ShowPlannedMealAddedDialog()
        {
            var dialog = new MessageDialog("Added to planned meals", this.viewModel.PlannedMealAddedMessage,
                MessageBoxButtons.YesNo);

            dialog.DialogClosed += (_, _) =>
            {
                if (dialog.DialogResult == DialogResult.Yes)
                {
                    base.ChangeScreens(new PlannedMealsScreen());
                }
            };

            base.DisplayDialog(dialog);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChangeScreens(new RecipeListScreen());
        }

        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            ToggleHamburgerMenu();
        }

        private void addPlannedMeal_Click(object sender, EventArgs e)
        {
            var dialog = new AddPlannedMealDialog();

            dialog.DialogClosed += (_, _) =>
            {
                if (dialog.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        this.viewModel.AddRecipeToPlannedMeals(dialog.SelectedDate, dialog.SelectedCategory);
                        this.ShowPlannedMealAddedDialog();
                    }
                    catch (UnauthorizedAccessException exception)
                    {
                        this.DisplayTimeOutDialog(exception.Message);
                    }
                    catch (Exception exception)
                    {
                        this.DisplayDialog(new MessageDialog("An error has occurred", exception.Message));
                    }
                }
            };

            base.DisplayDialog(dialog);
        }
    }
}