using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;
using Desktop_Client.View.Components.Ingredients;
using System;
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
            this.mealsListTableLayout.RowStyles.Clear();
            var firstItem = true;
            foreach (var meal in meals)
            {
                var rowStyle = new RowStyle
                {
                    SizeType = SizeType.AutoSize
                };
                var listItem = new PlannedMealListItem(meal, this.viewModel.RecipeTags);
                this.mealsListTableLayout.Controls.Add(listItem);
                this.mealsListTableLayout.RowStyles.Add(rowStyle);

                if (!firstItem)
                {
                    listItem.Margin = new Padding(3, 48, 3, 3);
                }
                firstItem = false;

                listItem.DeletePressed += (sender, args) =>
                {
                    var recipe = args.Item1;
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

                            this.viewModel.RemovePlannedMeal(meal.MealDate.Date, category, recipe.Id);
                            listItem.RemovePlannedMeal(recipe.Id, category);
                        }
                        catch (UnauthorizedAccessException exception)
                        {
                            base.DisplayTimeOutDialog(exception.Message);
                        }
                    };

                    base.DisplayDialog(dialog);
                };
            }
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
    }
}