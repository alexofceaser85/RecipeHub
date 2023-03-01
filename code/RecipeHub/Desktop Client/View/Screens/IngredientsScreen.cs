using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;
using Desktop_Client.View.Components.Ingredients;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class IngredientsScreen : Screen
    {
        private readonly IngredientsViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="IngredientsScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public IngredientsScreen()
        {
            this.InitializeComponent();

            this.viewModel = new IngredientsViewModel();
            this.BindComponents();
            this.viewModel.GetAllIngredientsForUser();
        }

        private void BindComponents()
        {
            this.removeAllButton.DataBindings.Add(new Binding("Enabled", this.viewModel,
                nameof(this.viewModel.RemoveAllButtonEnabled)));
            this.viewModel.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName != nameof(this.viewModel.Ingredients))
                {
                    return;
                }

                this.PopulateIngredientsList(this.viewModel.Ingredients);
            };
        }

        private void PopulateIngredientsList(IEnumerable<Ingredient> ingredients)
        {
            this.ClearRecipeList();
            foreach (var ingredient in ingredients)
            {
                var item = new IngredientListItem(ingredient);
                this.ingredientListTableLayout.Controls.Add(item);
                this.ingredientListTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
                item.EditSelected += (_, selectedIngredient) =>
                {
                    var editIngredientDialog = new EditIngredientDialog(selectedIngredient.Name);
                    if (editIngredientDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.viewModel.GetAllIngredientsForUser();
                    }
                };
                item.RemoveSelected += (_, selectedIngredient) =>
                {
                    var ingredientName = selectedIngredient.Name;
                    var result = MessageBox.Show($@"Are you sure you want to remove {ingredientName} from your pantry?", 
                        @"Remove Ingredient", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.viewModel.RemoveIngredient(selectedIngredient);
                        this.viewModel.GetAllIngredientsForUser();
                    }
                };

            }
        }

        private void ClearRecipeList()
        {
            this.ingredientListTableLayout.Controls.Clear();
            this.ingredientListTableLayout.RowStyles.Clear();
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

        private void addIngredientButton_Click(object sender, EventArgs e)
        {

            try
            {
                var addIngredientDialog = new AddIngredientDialog();
                addIngredientDialog.ShowDialog();
                if (addIngredientDialog.DialogResult == DialogResult.OK)
                {
                    this.viewModel.GetAllIngredientsForUser();
                }
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

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure you want to remove all ingredients?",
                    "Remove All Ingredients", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.viewModel.RemoveAllIngredients();
                    this.viewModel.GetAllIngredientsForUser();
                }
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
    }
}