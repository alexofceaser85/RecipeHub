using Desktop_Client.View.Components.General;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class Screen : UserControl
    {
        private UserMenu? menu;

        /// <summary>
        /// Creates a default instance of <see cref="Screen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public Screen()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Occurs when [screen changed].
        /// </summary>
        public event EventHandler<Screen>? ScreenChanged;

        /// <summary>
        /// Fires the <code>ScreenChanged</code> event with the specified screen as the event argument.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="screen"></param>
        protected void ChangeScreens(Screen screen)
        {
            this.ScreenChanged?.Invoke(this, screen);
        }

        /// <summary>
        /// Toggles whether or not the hamburger menu is displayed.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>The menu is displayed, if it wasn't before. It is hidden if it was displayed before.
        /// </summary>
        protected void ToggleHamburgerMenu()
        {
            if (this.menu == null)
            {
                this.SetupMenu();
            }

            this.menu!.Visible = !this.menu.Visible;

            if (this.menu.Visible)
            {
                this.menu.BringToFront();
            }
            else
            {
                this.menu!.BringToFront();
            }
        }

        private void SetupMenu()
        {
            this.menu = new UserMenu() 
            {
                Visible = false
            };
            this.Controls.Add(this.menu);
            this.menu.Location = new Point(this.Size.Width - this.menu.Size.Width, 0);
            this.menu.Size = new Size(this.menu.Width, this.Size.Height);
            this.menu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;

            this.menu.MenuClosed += (_, _) => this.ToggleHamburgerMenu();
            this.menu.IngredientsSelected += (_, _) =>
            {
                try
                {
                    this.ChangeScreens(new IngredientsScreen());
                }
                catch (UnauthorizedAccessException exception)
                {
                    var result = MessageBox.Show(exception.Message);
                    if (result == DialogResult.OK)
                    {
                        this.ChangeScreens(new LoginScreen());
                    }
                }
            };
            this.menu.LogoutSelected += (_, _) => this.ChangeScreens(new LoginScreen());
            this.menu.RecipesSelected += (_, _) =>
            {
                try
                {
                    this.ChangeScreens(new RecipeListScreen());
                }
                catch (UnauthorizedAccessException exception)
                {
                    var result = MessageBox.Show(exception.Message);
                    if (result == DialogResult.OK)
                    {
                        this.ChangeScreens(new LoginScreen());
                    }
                }
            };
        }


    }
}
