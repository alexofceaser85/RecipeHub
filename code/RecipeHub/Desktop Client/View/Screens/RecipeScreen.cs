using System.Text;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Data.UserData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Shared_Resources.Utils.Units;

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
            try
            {
                ChangeScreens(new RecipeListScreen());
            }
            catch (UnauthorizedAccessException exception)
            {
                this.DisplayTimeOutDialog(exception.Message);
            }
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

        private void cookRecipeButton_Click(object sender, EventArgs e)
        {
            this.viewModel.GetMissingIngredientsForRecipe();

            MessageDialog dialog;

            if (this.viewModel.MissingIngredients.Length > 0)
            {
                var message = new StringBuilder();
                message.Append(
                    "You are missing some ingredients. If you cook this meal, they will be removed from your pantry (if present):");
                foreach (var ingredient in this.viewModel.MissingIngredients)
                {
                    var unit = BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType);
                    message.Append($"\n - {ingredient.Name}: {ingredient.Amount} {unit}");
                }
                dialog = new MessageDialog("Missing Ingredients", message.ToString(), MessageBoxButtons.YesNo);
            }
            else
            {
                dialog = new MessageDialog("Cook Meal",
                    "Are you sure you would like to cook this meal?\nAll ingredients will be removed from your pantry.",
                    MessageBoxButtons.YesNo);
            }

            dialog.DialogClosed += (_, _) =>
            {
                if (dialog.DialogResult != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    this.viewModel.RemoveIngredientsForRecipe();
                    base.ChangeScreens(new IngredientsScreen());
                }
                catch (UnauthorizedAccessException exception)
                {
                    this.DisplayTimeOutDialog(exception.Message);
                }
                catch (Exception exception)
                {
                    this.DisplayDialog(new MessageDialog("An error has occurred", exception.Message));
                }
            };

            base.DisplayDialog(dialog);
        }
    }
}