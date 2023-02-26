using Desktop_Client.View.Components.Recipes;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Data.UserData;
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
            this.viewmodel.GetRecipes();
        }

        private void BindComponents()
        {
            this.searchTextBox.DataBindings.Add(new Binding("Text", this.viewmodel, 
                nameof(this.viewmodel.SearchTerm)));
            this.viewmodel.PropertyChanged += (_, arg) =>
            {
                if (arg.PropertyName != nameof(this.viewmodel.RecipeTags))
                {
                    return;
                }

                this.PopulateRecipeList(this.viewmodel.Recipes, this.viewmodel.RecipeTags);
            };
        }

        private void PopulateRecipeList(Recipe[] recipes, string[][] recipeTags)
        {
            this.ClearRecipeList();
            for (var i = 0; i < recipes.Length; i++)
            {
                var recipe = recipes[i];
                var tags = recipeTags[i];

                var item = new RecipeListItem(recipe, tags);
                this.recipeListTablePanel.Controls.Add(item);
                this.recipeListTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 160));
                item.Tapped += this.RecipeListItemMouseClick;
            }
        }

        private void ClearRecipeList()
        {
            this.recipeListTablePanel.Controls.Clear();
            this.recipeListTablePanel.RowStyles.Clear();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.viewmodel.SearchTerm = this.searchTextBox.Text;
                this.viewmodel.GetRecipes();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                var result = MessageBox.Show(exception.Message);
                if (result == DialogResult.OK)
                {
                    base.ChangeScreens(new LoginScreen());
                }
            }
        }

        private void RecipeListItemMouseClick(object? sender, int recipeId)
        {
            try
            {
                base.ChangeScreens(new RecipeScreen(recipeId));
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                var result = MessageBox.Show(exception.Message);
                if (result == DialogResult.OK)
                {
                    base.ChangeScreens(new LoginScreen());
                }
            }
        }

        private void hamburgerButton_MouseClick(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }

        private void filtersButton_Click(object sender, EventArgs e)
        {
            var filtersDialog = new RecipeListFilterDialog(this.viewmodel.Filters);
            if (filtersDialog.ShowDialog() == DialogResult.OK)
            {
                this.viewmodel.Filters = filtersDialog.Filters;
                this.viewmodel.GetRecipes();
            }
        }
    }
}