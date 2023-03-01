using Desktop_Client.ViewModel.Ingredients;
using System.Text;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Dialog for Adding an Ingredient.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddIngredientDialog : Form
    {
        private readonly AddIngredientsViewModel viewModel;

        /// <summary>
        /// The error occurred event handler
        /// </summary>
        public EventHandler<ErrorEventArgs>? ErrorOccurred;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIngredientDialog"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Default values is set for fields.<br />
        /// </summary>
        public AddIngredientDialog()
        {
            this.InitializeComponent();
            this.viewModel = new AddIngredientsViewModel();
            this.measurementComboBox.DataSource = Enum.GetValues(typeof(MeasurementType));
            this.BindComponents();
            this.viewModel.Initialize();
        }

        private void BindComponents()
        {
            this.nameTextBox.DataBindings.Add(new Binding("Text", this.viewModel, 
                nameof(this.viewModel.IngredientName)));
            this.nameTextBox.DataBindings.Add(new Binding("Values", this.viewModel,
                nameof(this.viewModel.IngredientNames)));
            this.amountTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.IngredientAmount)));
            this.measurementComboBox.DataBindings.Add(new Binding("SelectedItem", this.viewModel,
                nameof(this.viewModel.SelectedMeasurementType)));
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.viewModel.AddIngredient())
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}