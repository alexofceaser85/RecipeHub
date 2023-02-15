using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Screens
{
    public partial class IngredientsScreen : Form
    {
        private readonly IngredientsViewModel viewModel;

        public IngredientsScreen()
        {
            this.viewModel = new IngredientsViewModel();
            InitializeComponent();

            this.SetupIngredientList();


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
                var cellValue = this.dataGridView1.Rows[e.RowIndex].Cells["Name"].Value;
                if (e.ColumnIndex == 1)
                {
                    var editIngredientDialog = new EditIngredientDialog(cellValue.ToString()!.Split("\nQuantity:")[0]);
                    editIngredientDialog.ShowDialog();
                    this.AddIngredientsFromServer();

                }
                else if (e.ColumnIndex == 2)
                {
                    MessageBox.Show($@"Delete Button clicked for row {e.RowIndex}, column 0 value is '{cellValue}'");
                }
            };

            this.AddIngredientsFromServer();
        }

        private void AddIngredientsFromServer()
        {
            this.dataGridView1.Rows.Clear();
            var ingredients = this.viewModel.GetAllIngredientsForUser();
            foreach (var ingredient in ingredients)
            {
                this.dataGridView1.Rows.Add($"{ingredient.Name}\nQuantity:{ingredient.Amount}", "Edit", "Delete");
            }
        }

        private void hamburgerButton1_Click(object sender, EventArgs e)
        {
            this.userMenu1.Visible = !this.userMenu1.Visible;
        }


        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            var addIngredientDialog = new AddIngredientDialog();
            addIngredientDialog.ShowDialog();
            if (addIngredientDialog.DialogResult == DialogResult.OK)
            {
                this.AddIngredientsFromServer();
            }
        }

        private void removeAllIngredientsButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove all ingredients?", "Remove All Ingredients", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }
    }
}
