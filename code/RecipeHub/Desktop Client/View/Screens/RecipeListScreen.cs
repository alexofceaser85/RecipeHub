using Desktop_Client.View.Components.Recipes;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class RecipeListScreen : Screen
    {
        private readonly RecipesListViewModel viewmodel;

        /// <summary>
        /// Creates a default instance of <see cref="Screen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeListScreen()
        {
            this.InitializeComponent();
            
            this.viewmodel = new RecipesListViewModel();
            this.BindComponents();

            this.DelayedRecipeLoading();
        }

        private void BindComponents()
        {
            this.searchTextBox.DataBindings.Add(new Binding("Text", this.viewmodel, 
                nameof(this.viewmodel.SearchTerm)));
            this.noRecipesLabel.DataBindings.Add(new Binding("Text", this.viewmodel,
                nameof(this.viewmodel.NoRecipesLabelText)));
            this.viewmodel.PropertyChanged += (_, arg) =>
            {
                if (arg.PropertyName != nameof(this.viewmodel.RecipeTags))
                {
                    return;
                }

                this.PopulateRecipeList(this.viewmodel.Recipes, this.viewmodel.RecipeTags);
            };
        }

        private async void DelayedRecipeLoading()
        {
            await Task.Delay(100);
            this.viewmodel.GetRecipes();
        }

        private void PopulateRecipeList(Recipe[] recipes, string[][] recipeTags)
        {
            this.ClearRecipeList();
            var availableWidth = this.recipeListTablePanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;

            if (recipes.Length == 0)
            {
                this.recipeListTablePanel.Controls.Add(this.noRecipesLabel);
                return;
            }
            for (var i = 0; i < recipes.Length; i++)
            {
                var recipe = recipes[i];
                var tags = recipeTags[i];

                var item = new RecipeListItem(recipe, tags);
                this.recipeListTablePanel.Controls.Add(item);
                item.Tapped += this.RecipeListItemMouseClick;
            }

            //Adds an empty label to the bottom of the list to prevent the last ingredient from expanding vertically
            this.recipeListTablePanel.Controls.Add(new Label { Margin = Padding.Empty, Padding = Padding.Empty});

            this.recipeListTablePanel.ResumeLayout(true);
            this.recipeListTablePanel.Padding = new Padding(0, 0, 1, 0);
            this.AdjustScroll();
        }

        private void ClearRecipeList()
        {
            this.recipeListTablePanel.Controls.Clear();
            this.recipeListTablePanel.RowStyles.Clear();
        }

        private void AdjustScroll()
        {
            // Reset row styles
            this.recipeListTablePanel.RowStyles.Clear();
            for (var i = 0; i < this.recipeListTablePanel.RowCount - 1; i++)
            {
                this.recipeListTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 160));
            }
            this.recipeListTablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Recalculate row heights
            this.recipeListTablePanel.AutoScroll = false;
            this.recipeListTablePanel.AutoScroll = true;
            
        }

        private void RecipeListItemMouseClick(object? sender, int recipeId)
        {
            try
            {
                base.ChangeScreens(new RecipeScreen(recipeId));
            }
            catch (ArgumentException exception)
            {
                var dialog = new MessageDialog("An error has occurred.", exception.Message);
                base.DisplayDialog(dialog);
            }
            catch (UnauthorizedAccessException exception)
            {
                base.DisplayTimeOutDialog(exception.Message);
            }
        }

        private void hamburgerButton_MouseClick(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }

        private void filtersButton_Click(object sender, EventArgs e)
        {
            var filtersDialog = new RecipeListFiltersDialog(RecipesListViewModel.Filters);
            filtersDialog.DialogClosed += (_, _) =>
            {
                if (filtersDialog.DialogResult == DialogResult.OK)
                {
                    RecipesListViewModel.Filters = filtersDialog.Filters;
                    this.viewmodel.GetRecipes();
                }
            };
            base.DisplayDialog(filtersDialog);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewmodel.SearchTerm = this.searchTextBox.Text;
                this.viewmodel.GetRecipes();
            }
            catch (ArgumentException exception)
            {
                var dialog = new MessageDialog("An error has occurred.", exception.Message);
                base.DisplayDialog(dialog);
            }
            catch (UnauthorizedAccessException exception)
            {
                base.DisplayTimeOutDialog(exception.Message);
            }
        }
    }
}