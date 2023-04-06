using Desktop_Client.ViewModel.Ingredients;
using System.Text;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Dialog for Editing the Amount of a chosen ingredient.
    /// </summary>
    /// <seealso cref="MobileDialog" />
    public partial class EditIngredientDialog : MobileDialog
    {
        private readonly EditIngredientViewModel viewModel;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EditIngredientDialog"/> class. <br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All values have been set to default and specified values<br />
        /// </summary>
        /// <param name="ingredient">The ingredient to edit.</param>
        public EditIngredientDialog(Ingredient ingredient)
        {
            this.InitializeComponent();
            this.viewModel = new EditIngredientViewModel();
            this.BindComponents();

            this.viewModel.IngredientName = ingredient.Name;
            this.viewModel.Amount = ingredient.Amount.ToString();
        }

        private void BindComponents()
        {
            this.editTitle.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Title)));
            this.amountTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Amount), true, DataSourceUpdateMode.OnPropertyChanged));
            this.amountTextBox.DataBindings.Add(new Binding("BackColor", this.viewModel,
                nameof(this.viewModel.AmountTextBoxColor)));
            this.amountErrorLabel.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.AmountErrorMessage)));
        }

        private void editIngredientButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.viewModel.EditIngredient())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                this.Exception = ex;
                this.Dispose();
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            var enteredLetter = false;
            var text = new Queue<char>();
            foreach (var ch in this.amountTextBox.Text)
            {
                if (char.IsDigit(ch))
                {
                    text.Enqueue(ch);
                }
                else
                {
                    enteredLetter = true;
                }
            }

            if (!enteredLetter)
            {
                return;
            }

            var sb = new StringBuilder();
            while (text.Count > 0)
            {
                sb.Append(text.Dequeue());
            }

            this.amountTextBox.Text = sb.ToString();
            this.amountTextBox.SelectionStart = this.amountTextBox.Text.Length;
        }
    }
}
