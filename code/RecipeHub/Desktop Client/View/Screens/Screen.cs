using Desktop_Client.View.Components.General;
using Desktop_Client.View.Dialog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class Screen : UserControl
    {
        private UserMenu? menu;
        private MobileDialog? dialogWindow;
        private TransparentContainer? dialogBackground;

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

        /// <summary>
        /// Displays a dialog window over the screen, blocking out all input to the screen itself until the window is closed.<br/>
        /// If a dialog is already shown, it will be closed.<br/>
        /// <br/>
        /// <b>Precondition: </b>dialog != null<br/>
        /// <b>Postcondition: </b>The dialog is displayed
        /// </summary>
        /// <param name="dialog">The dialog window to display</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DisplayDialog(MobileDialog dialog)
        {
            if (dialog == null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            if (this.dialogWindow != null)
            {
                this.CloseDialog(this.dialogWindow);
            }
            this.SetupDialog(dialog);
        }

        /// <summary>
        /// Displays a timeout dialog, then sends the user back the login screen when its closed.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>A dialog is shown informing the user that they are returning to the home screen.
        /// </summary>
        /// <param name="message">The message to display. Uses a default message of none is provided.</param>
        public void DisplayTimeOutDialog(string? message = null)
        {
            message ??= "Session timed out. Returning to the login screen.";

            var dialog = new MessageDialog("Session not found", message, MessageBoxButtons.OK);
            dialog.DialogClosed += (_, _) => this.ChangeScreens(new LoginScreen());
            this.DisplayDialog(dialog);
        }

        private void SetupMenu()
        {
            this.menu = new UserMenu
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
                    this.DisplayTimeOutDialog(exception.Message);
                }
            };
            this.menu.LogoutSelected += (_, _) => this.ChangeScreens(new LoginScreen());
            this.menu.PlannedMealsSelected += (_, _) =>
            {
                try
                {
                    this.ChangeScreens(new PlannedMealsScreen());
                }
                catch (UnauthorizedAccessException exception)
                {
                    this.DisplayTimeOutDialog(exception.Message);
                }
            };
            this.menu.RecipesSelected += (_, _) =>
            {
                try
                {
                    this.ChangeScreens(new RecipeListScreen());
                }
                catch (UnauthorizedAccessException exception)
                {
                    this.DisplayTimeOutDialog(exception.Message);
                }
            };
        }

        private void SetupDialog(MobileDialog dialog)
        {
            this.dialogWindow = dialog;
            this.dialogWindow.Anchor = AnchorStyles.None;
            this.dialogWindow.Location = new Point();
            this.dialogBackground = new TransparentContainer()
            {
                Dock = DockStyle.Fill
            };
            this.dialogBackground.Controls.Add(this.dialogWindow);

            var dialogX = dialog.Location.X - (dialog.Width - 150) / 2;
            var dialogY = dialog.Location.Y - (dialog.Height - 150) / 2;
            this.dialogWindow.Location = new Point(dialogX, dialogY);

            this.Controls.Add(this.dialogBackground);
            this.dialogBackground.BringToFront();

            this.dialogWindow.DialogClosed += (sender, _) => this.CloseDialog((MobileDialog)sender!);
        }

        private void CloseDialog(MobileDialog dialog)
        {
            if (this.dialogBackground == null || this.dialogWindow != dialog)
            {
                return;
            }

            this.dialogBackground.Dispose();
            this.Controls.Remove(this.dialogBackground);
            this.dialogWindow = null;
            this.dialogBackground = null;
        }
    }
}
