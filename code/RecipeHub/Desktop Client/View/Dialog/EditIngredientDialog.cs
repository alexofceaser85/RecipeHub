using System.Text;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Dialog for Editing the Amount of a chosen ingredient.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class EditIngredientDialog : Form
    {
        private readonly EditIngredientViewModel viewModel;

        /// <summary>
        /// The error occured event handler
        /// </summary>
        public EventHandler<ErrorEventArgs>? ErrorOccurred;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditIngredientDialog"/> class. <br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All values have been set to default and specified values<br />
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        public EditIngredientDialog(string ingredientName)
        {
            this.InitializeComponent();
            this.viewModel = new EditIngredientViewModel();
            this.BindComponents();

            this.viewModel.IngredientName = ingredientName;
        }

        private void BindComponents()
        {
            this.editTitle.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.Title)));
            this.amountTextBox.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.Amount)));
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
                this.ErrorOccurred?.Invoke(this, new ErrorEventArgs(ex));
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