using Desktop_Client.View.Dialog;
using Desktop_Client.View.Components.PlannedMeals;
using Desktop_Client.ViewModel.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class PlannedMealsScreen : Screen
    {
        private readonly PlannedMealsViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="IngredientsScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public PlannedMealsScreen()
        {
            this.InitializeComponent();

            this.mealsListTableLayout.RowStyles.Clear();
            this.viewModel = new PlannedMealsViewModel();
            this.BindComponents();
            this.DelayTablePopulation();
        }
        
        private async void DelayTablePopulation()
        {
            await Task.Delay(100);
            this.viewModel.Initialize();
        }
        
        private void BindComponents()
        {
            this.viewModel.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName != nameof(this.viewModel.PlannedMeals))
                {
                    return;
                }

                this.PopulatePlannedMeals(this.viewModel.PlannedMeals);
            };
        }

        private void PopulatePlannedMeals(IEnumerable<PlannedMeal> meals)
        {
            this.mealsListTableLayout.Controls.Clear();

            foreach (var meal in meals)
            {
                var listItem = new PlannedMealListItem(meal, this.viewModel.RecipeTags);
                this.mealsListTableLayout.Controls.Add(listItem);
                
                listItem.DeletePressed += (_, args) =>
                {
                    var plannedRecipe = args.Item1;
                    var recipe = plannedRecipe.Recipe;
                    var category = args.Item2;
                    var dialog = new MessageDialog("Remove planned meal?",
                        $"Are you sure that you want to remove {recipe.Name}?", MessageBoxButtons.YesNo);

                    dialog.DialogClosed += (_, _) =>
                    {
                        try
                        {
                            if (dialog.DialogResult != DialogResult.Yes)
                            {
                                return;
                            }

                            this.viewModel.RemovePlannedMeal(plannedRecipe.MealId);
                            listItem.RemovePlannedMeal(recipe.Id, category);
                            this.AdjustScroll();
                        }
                        catch (UnauthorizedAccessException exception)
                        {
                            base.DisplayTimeOutDialog(exception.Message);
                        }
                    };

                    base.DisplayDialog(dialog);
                };
                listItem.ViewPressed += (_, recipeId) =>
                {
                    try
                    {
                        this.ChangeScreens(new RecipeScreen(recipeId));
                    }
                    catch (UnauthorizedAccessException exception)
                    {
                        this.DisplayTimeOutDialog(exception.Message);
                    }
                };
                listItem.CollapseToggled += (_, _) => this.AdjustScroll();
            }
            
            //Adds an empty label to the bottom of the list to prevent the last ingredient from expanding vertically
            this.mealsListTableLayout.Controls.Add(new Label { Margin = Padding.Empty, Padding = Padding.Empty});

            this.mealsListTableLayout.ResumeLayout(true);
            this.AdjustScroll();
        }
        
        private void AdjustScroll()
        {
            // Reset row styles
            this.mealsListTableLayout.RowStyles.Clear();
            for (int i = 0; i < this.mealsListTableLayout.RowCount; i++)
            {
                this.mealsListTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Recalculate row heights
            this.mealsListTableLayout.AutoScroll = false;
            this.mealsListTableLayout.AutoScroll = true;
        }
        
        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                base.ChangeScreens(new RecipeListScreen());
            }
            catch (ArgumentException exception)
            {
                var messageDialog =
                    new MessageDialog("Error occurred", exception.Message);
                base.DisplayDialog(messageDialog);
            }
            catch (UnauthorizedAccessException exception)
            {
                this.DisplayTimeOutDialog(exception.Message);
            }
        }

        private void viewShoppingListButton_Click(object sender, EventArgs e)
        {
            try
            {
                base.ChangeScreens(new ShoppingListScreen());
            }
            catch (ArgumentException exception)
            {
                var messageDialog =
                    new MessageDialog("Error occurred", exception.Message);
                base.DisplayDialog(messageDialog);
            }
            catch (UnauthorizedAccessException exception)
            {
                this.DisplayTimeOutDialog(exception.Message);
            }
        }
    }
}