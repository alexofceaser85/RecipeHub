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
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Screens
{
    public partial class IngredientsScreen : Form
    {
        private IList<Ingredient> test;
        public IngredientsScreen()
        {
            this.test = new List<Ingredient>() {
                new("Eggs", 5, MeasurementType.Quantity),
                new("Flour", 500, MeasurementType.Mass),
                new("Milk", 500, MeasurementType.Volume),
                new("Sugar", 500, MeasurementType.Mass),
                new("Salt", 5, MeasurementType.Mass),
                new("Butter", 500, MeasurementType.Mass),
                new("Baking Powder", 5, MeasurementType.Mass),
                new("Baking Soda", 5, MeasurementType.Mass),
                new("Vanilla", 5, MeasurementType.Mass),
                new("Chocolate Chips", 500, MeasurementType.Mass),
                new("Cinnamon", 5, MeasurementType.Mass),
                new("Nutmeg", 5, MeasurementType.Mass),
                new("Clove", 5, MeasurementType.Mass),
            };
            InitializeComponent();

            //TODO: Make a list view that has the name of the ingredient and quantity on one column, and edit and delete buttons on the other two.

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
            //Change row height to be 100
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
                    MessageBox.Show($@"Edit Button clicked for row {e.RowIndex}, column 0 value is '{cellValue}'");
                }
                else if (e.ColumnIndex == 2)
                {
                    MessageBox.Show($@"Delete Button clicked for row {e.RowIndex}, column 0 value is '{cellValue}'");
                }
            };
            //Disable selection of anything


            foreach (Ingredient ingredient in this.test)
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
            Form addIngredient = new AddIngredientDialog();
            addIngredient.ShowDialog();
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
