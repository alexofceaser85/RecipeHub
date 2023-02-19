using Desktop_Client.View.Components.Recipes;
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
            this.PopulateRecipeList(this.viewmodel.GetRecipes(Session.Key!));
        }

        private void PopulateRecipeList(IEnumerable<Recipe> recipes)
        {
            this.ClearRecipeList();
            foreach (var recipe in recipes)
            {
                var item = new RecipeListItem(recipe);
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
            this.PopulateRecipeList(this.viewmodel.GetRecipes(Session.Key!, this.searchTextBox.Text));
        }

        private void RecipeListItemMouseClick(object? sender, int recipeId)
        {
            ChangeScreens(new RecipeScreen(recipeId));
        }

        private void hamburgerButton_MouseClick(object sender, EventArgs e)
        {
            ToggleHamburgerMenu();
        }

        private void filtersButton_Click(object sender, EventArgs e)
        {
            this.viewmodel.OpenFiltersDialog();
            this.PopulateRecipeList(this.viewmodel.GetRecipes(Session.Key!));
        }
    }
}