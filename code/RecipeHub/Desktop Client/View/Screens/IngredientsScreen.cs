using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;
using System;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class IngredientsScreen : Screen
    {
        private readonly IngredientsViewModel viewModel;
        private IList<Ingredient> ingredients;

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
            this.ingredients = new List<Ingredient>();
            this.SetupIngredientList();
        }

        private void SetupIngredientList()
        {
            //TODO This really needs to be cleaned up. This should be a component similar to the Recipe List Item
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.Width = 200;
            nameColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ingredientDataGridView.Columns.Add(nameColumn);

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            this.ingredientDataGridView.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            this.ingredientDataGridView.Columns.Add(deleteButton);
            this.ingredientDataGridView.RowTemplate.Height = 100;

            this.ingredientDataGridView.RowHeadersVisible = false;
            this.ingredientDataGridView.ReadOnly = true;
            this.ingredientDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ingredientDataGridView.ColumnHeadersVisible = false;
            this.ingredientDataGridView.AllowUserToAddRows = false;
            this.ingredientDataGridView.AllowUserToDeleteRows = false;
            this.ingredientDataGridView.AllowUserToResizeRows = false;
            this.ingredientDataGridView.AllowUserToResizeColumns = false;
            this.ingredientDataGridView.AllowUserToOrderColumns = false;
            this.ingredientDataGridView.MultiSelect = false;

            this.ingredientDataGridView.CellContentClick += (_, e) =>
            {
                var ingredient = this.ingredients[e.RowIndex];
                var name = ingredient.Name;
                var quantity = ingredient.Amount;
                var measurementType = ingredient.MeasurementType;

                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        var editIngredientDialog = new EditIngredientDialog(name);
                        editIngredientDialog.ShowDialog();
                        this.LoadIngredientsFromServer();
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
                else if (e.ColumnIndex == 2)
                {
                    try
                    {
                        var result = MessageBox.Show($@"Are you sure you want to remove {name} from your pantry?", "Remove Ingredient", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.viewModel.RemoveIngredient(new Shared_Resources.Model.Ingredients.Ingredient(name, quantity, measurementType));
                            this.LoadIngredientsFromServer();
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
            };

            this.LoadIngredientsFromServer();
        }

        private void LoadIngredientsFromServer()
        {
            this.ingredientDataGridView.Rows.Clear();
            this.ingredients = this.viewModel.GetAllIngredientsForUser();
            foreach (var ingredient in this.ingredients)
            {
                this.ingredientDataGridView.Rows.Add(
                    $"{ingredient.Name}\nQuantity:{ingredient.Amount}" +
                    $"{BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType)}",
                    "Edit", "Delete");
            }

        }

        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            ToggleHamburgerMenu();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChangeScreens(new RecipeListScreen());
        }
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
                    this.LoadIngredientsFromServer();
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
            var result = MessageBox.Show("Are you sure you want to remove all ingredients?",
                "Remove All Ingredients", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.viewModel.RemoveAllIngredients();
            }

            this.LoadIngredientsFromServer();
        }
            try
            {
                var result = MessageBox.Show("Are you sure you want to remove all ingredients?",
                    "Remove All Ingredients", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.viewModel.RemoveAllIngredients();
                }
                this.LoadIngredientsFromServer();
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