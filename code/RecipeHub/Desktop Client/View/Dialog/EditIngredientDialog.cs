﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private readonly string ingredientName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditIngredientDialog"/> class. <br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All values have been set to default and specified values<br />
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        public EditIngredientDialog(string ingredientName)
        {
            this.viewModel = new EditIngredientViewModel();
            this.ingredientName = ingredientName;
            InitializeComponent();
            this.editTitle.Text = $@"Edit {ingredientName}?";
        }

        private void editIngredientButton_Click(object sender, EventArgs e)
        {
            this.viewModel.EditIngredient(new Ingredient(this.ingredientName, int.Parse(this.amountTextBox.Text), MeasurementType.Quantity));
            this.Close();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            this.DialogResult = DialogResult.Cancel;
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
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

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                this.amountTextBox.Text = sb.ToString();
                this.amountTextBox.SelectionStart = this.amountTextBox.Text.Length;
            }
        }
    }
}
