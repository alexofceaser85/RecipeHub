using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Client.View.Components.General
{
    public partial class UserMenu : UserControl
    {
        public EventHandler? MenuClosed;
        public EventHandler? LogoutSelected;
        public EventHandler? IngredientsSelected;
        public EventHandler? RecipesSelected;
        public EventHandler? PlannedMealsSelected;
        public EventHandler? UserSelected;

        public UserMenu()
        {
            InitializeComponent();
        }

        private void logoutNavbarOption_Click(object sender, EventArgs e)
        {
            this.LogoutSelected?.Invoke(this, EventArgs.Empty);
        }

        private void ingredientsNavbarOption_Click(object sender, EventArgs e)
        {
            this.IngredientsSelected?.Invoke(this, EventArgs.Empty);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.MenuClosed?.Invoke(this, EventArgs.Empty);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            this.RecipesSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
