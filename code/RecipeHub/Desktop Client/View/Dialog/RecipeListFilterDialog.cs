using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_Client.Model;

namespace Desktop_Client.View.Dialog
{
    public partial class RecipeListFilterDialog : Form
    {
        private RecipeFilters filters;

        public RecipeFilters Filters
        {
            get => this.filters;
            set => this.filters = value;
        }

        public RecipeListFilterDialog(RecipeFilters filters)
        {
            InitializeComponent();
            this.filters = filters;
            this.ApplyFilterToControls();
        }

        private void ApplyFilterToControls()
        {
            this.ingredientFilterCheckBox.Checked = this.filters.OnlyAvailableIngredients;
        }

        private void ingredientFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filters.OnlyAvailableIngredients = this.ingredientFilterCheckBox.Checked;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
