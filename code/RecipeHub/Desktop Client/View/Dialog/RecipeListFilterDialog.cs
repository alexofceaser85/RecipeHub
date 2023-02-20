using System.Collections.Specialized;
using Desktop_Client.Model;
using Desktop_Client.ViewModel.RecipeTypes;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// A dialog window containing filtering options for the recipe list screen.
    /// </summary>
    public partial class RecipeListFilterDialog : Form
    {
        private AutoCompleteStringCollection suggestionList;
        private RecipeFilters filters;

        /// <summary>
        /// The Filters to be applied to the recipe list.
        /// </summary>
        public RecipeFilters Filters
        {
            get => this.filters;
            set => this.filters = value;
        }

        /// <summary>
        /// Creates an instance of <see cref="RecipeListFilterDialog"/> with a specified set of Filters.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>The filter options are reflected in the UI.
        /// </summary>
        /// <param name="filters">The currently selected Filters.</param>
        public RecipeListFilterDialog(RecipeFilters filters)
        {
            this.InitializeComponent();
            this.filters = filters;

            var viewModel = new RecipeTypesViewModel();

            this.ApplyFilterToControls();

            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();

            suggestions.AddRange(viewModel.GetSimilarRecipeTypes());

            this.tagsTextInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.tagsTextInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tagsTextInput.AutoCompleteCustomSource = suggestions;
            this.tagsTextInput.Focus();
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

        private void tagsTextInput_TextChanged(object sender, EventArgs e)
        {
            if (this.tagsTextInput.Text.Trim().Length == 0)
            {
                return;
            }
        }
    }
}