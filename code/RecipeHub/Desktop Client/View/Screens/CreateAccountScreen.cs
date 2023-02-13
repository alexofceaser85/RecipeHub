using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The create account form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CreateAccountScreen : Form
    {
        private readonly UsersViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountScreen"/> class.
        /// </summary>
        public CreateAccountScreen()
        {
            this.InitializeComponent();
            this.viewModel = new UsersViewModel();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewModel.CreateAccount(
                    this.createAccountForm.UsernameTextBox.Text,
                    this.createAccountForm.PasswordTextBox.Text,
                    this.createAccountForm.VerifyPasswordTextBox.Text,
                    this.createAccountForm.FirstNameTextBox.Text,
                    this.createAccountForm.LastNameTextBox.Text,
                    this.createAccountForm.EmailTextBox.Text
                );
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
