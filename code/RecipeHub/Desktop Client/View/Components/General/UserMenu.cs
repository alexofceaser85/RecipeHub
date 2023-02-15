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
        /// <summary>
        /// Occurs when the user presses the close button.
        /// </summary>
        public EventHandler? MenuClosed;

        /// <summary>
        /// Occurs when the user presses the logout button.
        /// </summary>
        public EventHandler? LogoutSelected;

        /// <summary>
        /// Occurs when the user presses the ingredients button
        /// </summary>
        public EventHandler? IngredientsSelected;

        /// <summary>
        /// Occurs when the user presses the recipes button
        /// </summary>
        public EventHandler? RecipesSelected;

        /// <summary>
        /// Occurs when the user presses the planned meals button
        /// </summary>
        public EventHandler? PlannedMealsSelected;

        /// <summary>
        /// Occurs when the user presses the users button
        /// </summary>
        public EventHandler? UserSelected;

        /// <summary>
        /// Creates a default instance of <see cref="UserMenu"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
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
