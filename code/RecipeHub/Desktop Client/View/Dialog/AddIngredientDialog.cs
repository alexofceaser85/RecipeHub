﻿using Desktop_Client.ViewModel.Ingredients;
using System.Text;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Dialog for Adding an Ingredient.
    /// </summary>
    public partial class AddIngredientDialog : MobileDialog
    {
        private readonly AddIngredientsViewModel viewModel;

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

            var measurementListItems = new List<string>();
            foreach (var type in Enum.GetValues(typeof(MeasurementType)))
            {
                var unit = BaseUnitUtils.GetBaseUnitSign((MeasurementType)type);
                if (!string.IsNullOrEmpty(unit))
                {
                    measurementListItems.Add($"{type} ({unit})");
                }
                else
                {
                    measurementListItems.Add(type.ToString()!);
                }
            }
            this.measurementComboBox.DataSource = measurementListItems;
            this.BindComponents();
            this.viewModel.Initialize();
        }

        private void BindComponents()
        {
            this.nameTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.IngredientName), false, DataSourceUpdateMode.OnPropertyChanged));
            this.nameTextBox.DataBindings.Add(new Binding("BackColor", this.viewModel,
                nameof(this.viewModel.IngredientNameTextBoxColor)));
            this.nameTextBox.DataBindings.Add(new Binding("Values", this.viewModel,
                nameof(this.viewModel.IngredientNames)));
            this.amountTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.IngredientAmount), false, DataSourceUpdateMode.OnPropertyChanged));
            this.amountTextBox.DataBindings.Add(new Binding("BackColor", this.viewModel,
                nameof(this.viewModel.IngredientAmountTextBoxColor)));
            this.measurementComboBox.DataBindings.Add(new Binding("SelectedItem", this.viewModel,
                nameof(this.viewModel.SelectedMeasurementType)));
            this.measurementComboBox.DataBindings.Add(new Binding("SelectedIndex", this.viewModel,
                nameof(this.viewModel.SelectedMeasurementIndex)));
            this.nameErrorLabel.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.IngredientNameErrorMessage)));
            this.amountErrorLabel.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.IngredientAmountErrorMessage)));
        }

        /// <summary>
        /// The error occurred event handler
        /// </summary>
        public EventHandler<ErrorEventArgs>? ErrorOccurred;
        
        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewModel.IngredientName = this.nameTextBox.Text;
                if (this.viewModel.AddIngredient())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
                else if (string.IsNullOrEmpty(this.nameErrorLabel.Text))
                {
                    this.nameErrorLabel.Text = "Ingredient already added to pantry";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                this.ErrorOccurred?.Invoke(this, new ErrorEventArgs(ex));
                this.Exception = ex;
                this.Dispose();
                this.Close();
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

            this.amountTextBox.Text = sb.ToString();
            this.amountTextBox.SelectionStart = this.amountTextBox.Text.Length;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }
    }
}
