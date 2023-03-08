using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Model.Filters;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// A dialog containing filtering options for the recipe list screen.
    /// </summary>
    public partial class RecipeListFiltersDialog : MobileDialog
    {
        private readonly RecipeListFilterViewModel viewModel;

        /// <summary>
        /// The Filters to be applied to the recipe list.
        /// </summary>
        public RecipeFilters Filters => this.viewModel.Filters;

        /// <summary>
        /// Creates an instance of <see cref="RecipeListFiltersDialog"/> with a specified set of Filters.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>The filter options are reflected in the UI.
        /// </summary>
        /// <param name="filters">The currently selected Filters.</param>
        public RecipeListFiltersDialog(RecipeFilters filters)
        {
            this.InitializeComponent();

            this.viewModel = new RecipeListFilterViewModel();
            this.BindComponents();
            this.viewModel.Initialize(filters);
            this.CheckSelectedItems();
        }

        private void BindComponents()
        {
            this.ingredientFilterCheckBox.DataBindings.Add(new Binding("Checked", this.viewModel,
                nameof(this.viewModel.FilterForAvailableIngredients)));
            this.tagsTextInput.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.SearchTerm)));
            this.checkedListBox1.DataSource = this.viewModel.FilteredTags;
        }

        private void CheckSelectedItems()
        {
            for (var i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                var item = this.checkedListBox1.Items[i];

                if (this.viewModel.SelectedTags.Contains(item.ToString()!))
                {
                    this.checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                }
            }
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
            this.viewModel.SearchTerm = this.tagsTextInput.Text;
            this.viewModel.ApplySearchTermFilter();
            this.CheckSelectedItems();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var itemText = this.checkedListBox1.Items[e.Index].ToString();

            if (itemText == null)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked)
            {
                this.viewModel.AddSelectedTag(itemText);
            }
            else
            {
                this.viewModel.RemoveSelectedTag(itemText);
            }
        }
    }
}
