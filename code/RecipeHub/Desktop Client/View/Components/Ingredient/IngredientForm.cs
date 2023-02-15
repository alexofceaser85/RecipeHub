using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Components.Ingredient
{
    /// <summary>
    /// Control for the Ingredient Screen.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class IngredientForm : UserControl
    {
        private readonly IngredientsViewModel viewModel;
        private IList<Shared_Resources.Model.Ingredients.Ingredient> ingredients;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientForm"/> class.<br />
        /// <br />
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public IngredientForm()
        {
            this.viewModel = new IngredientsViewModel();
            InitializeComponent();
        }

        private void SetupIngredientList()
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.Width = 200;
            nameColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(nameColumn);

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(deleteButton);
            this.dataGridView1.RowTemplate.Height = 100;

            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.MultiSelect = false;

            this.dataGridView1.CellContentClick += (sender, e) =>
            {
                var ingredient = this.ingredients[e.RowIndex];
                var name = ingredient.Name;
                var quantity = ingredient.Amount;
                var measurementType = ingredient.MeasurementType;

                if (e.ColumnIndex == 1)
                {
                    var editIngredientDialog = new EditIngredientDialog(name);
                    editIngredientDialog.ShowDialog();
                    this.LoadIngredientsFromServer();

                }
                else if (e.ColumnIndex == 2)
                {
                    var result = MessageBox.Show($@"Are you sure you want to remove {name} from your pantry?", "Remove Ingredient", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.viewModel.RemoveIngredient(new Shared_Resources.Model.Ingredients.Ingredient(name, quantity, measurementType));
                        this.LoadIngredientsFromServer();
                    }
                }
            };

            this.LoadIngredientsFromServer();
        }

        private void LoadIngredientsFromServer()
        {
            this.dataGridView1.Rows.Clear();
            this.ingredients = this.viewModel.GetAllIngredientsForUser();
            foreach (var ingredient in this.ingredients)
            {
                this.dataGridView1.Rows.Add($"{ingredient.Name}\nQuantity:{ingredient.Amount}{BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType)}", "Edit", "Delete");
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            var addIngredientDialog = new AddIngredientDialog();
            addIngredientDialog.ShowDialog();
            if (addIngredientDialog.DialogResult == DialogResult.OK)
            {
                this.LoadIngredientsFromServer();
            }
        }

        private void removeAllIngredientsButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove all ingredients?", "Remove All Ingredients", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.viewModel.RemoveAllIngredients();
            }
            this.LoadIngredientsFromServer();
        }
    }
}
