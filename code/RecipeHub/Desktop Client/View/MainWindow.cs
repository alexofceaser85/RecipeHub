using Desktop_Client.View.Screens;
using Screen = Desktop_Client.View.Screens.Screen;

namespace Desktop_Client.View
{
    /// <summary>
    /// The main window for the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        private Screen? activeScreen;

        /// <summary>
        /// Creates a default instance of <see cref="MainWindow"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.SwapScreens(new LoginScreen());
        }

        private void SwapScreens(Screen newScreen)
        {
            if (newScreen == null)
            {
                throw new ArgumentNullException(nameof(newScreen));
            }

            if (this.activeScreen != null)
            {
                this.activeScreen.ScreenChanged -= this.OnScreenChanged;
                this.Controls.Remove(this.activeScreen);
            }
            
            newScreen.ScreenChanged += this.OnScreenChanged;
            this.activeScreen = newScreen;
            this.AdjustScreenSize();
            this.Controls.Add(newScreen);
        }

        private void AdjustScreenSize()
        {
            if (this.activeScreen == null)
            {
                return;
            }

            var screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            var titleHeight = screenRectangle.Top - this.Top;
            var horizontalPadding = screenRectangle.Left - this.Left;
            this.activeScreen.Size = new Size(this.Size.Width - horizontalPadding * 2, this.Size.Height - titleHeight);
        }

        private void OnScreenChanged(object? sender, Screen e)
        {
            this.SwapScreens(e);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            this.AdjustScreenSize();
        }
    }
}
