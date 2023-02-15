using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// Screen for the Ingredients Functionality.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class IngredientsScreen : Form
    {

        public IngredientsScreen()
        {
            InitializeComponent();

        }

        private void hamburgerButton1_Click(object sender, EventArgs e)
        {
            this.userMenu1.Visible = !this.userMenu1.Visible;
        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }
    }
}
