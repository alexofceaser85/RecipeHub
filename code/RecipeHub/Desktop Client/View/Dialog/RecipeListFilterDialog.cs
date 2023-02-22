using Desktop_Client.Model;
using Desktop_Client.ViewModel.RecipeTypes;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// A dialog window containing filtering options for the recipe list screen.
    /// </summary>
    public partial class RecipeListFilterDialog : Form
    {
        private RecipeFilters filters;
        private readonly string[] recipeTypes;
        private readonly Dictionary<string, bool> checkedState;

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

            this.applyFilterToControls();

            var suggestions = new AutoCompleteStringCollection();
            this.checkedState = new Dictionary<string, bool>();
            
            this.recipeTypes = viewModel.GetAllRecipeTypes();

            foreach (var item in this.recipeTypes)
            {
                this.checkedState[item] = false;
            }

            this.checkedListBox1.Items.AddRange(this.recipeTypes);

            this.tagsTextInput.AutoCompleteCustomSource = suggestions;
            this.tagsTextInput.Focus();
        }

        private void applyFilterToControls()
        {
            this.ingredientFilterCheckBox.Checked = this.filters.OnlyAvailableIngredients;
        }

        private void ingredientFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filters.OnlyAvailableIngredients = this.ingredientFilterCheckBox.Checked;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.filters.MatchTags = this.checkedListBox1.CheckedItems.OfType<object>().Select(item => item.ToString()).ToArray();
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
            var checkboxItems = new List<string>();
            var searchText = this.tagsTextInput.Text;
            for (int i = 0; i < this.recipeTypes.Length; i++)
            {
                string itemText = this.recipeTypes[i];
                bool match = itemText.Contains(searchText);

                if (match)
                {
                    checkboxItems.Add(itemText);
                }
            }

            this.checkedListBox1.Items.Clear();
            this.checkedListBox1.Items.AddRange(checkboxItems.ToArray());


            var checkedListBoxItems = this.checkedListBox1.Items.OfType<object>().ToArray();

            foreach (var item in checkedListBoxItems)
            {
                if (this.checkedState.TryGetValue(item.ToString(), out bool isChecked))
                {
                    this.checkedListBox1.SetItemChecked(this.checkedListBox1.Items.IndexOf(item), isChecked);
                }
            }

            this.checkedListBox1.Refresh();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var itemText = this.checkedListBox1.Items[e.Index].ToString();

            if (itemText != null)
            {
                this.checkedState[itemText] = e.NewValue == CheckState.Checked;
            }
        }
    }
}