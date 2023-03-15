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
                this.activeScreen.Dispose();
            }
            
            newScreen.ScreenChanged += this.OnScreenChanged;
            this.activeScreen = newScreen;
            this.activeScreen.Dock = DockStyle.Fill;
            this.Controls.Add(newScreen);
        }
        
        private void OnScreenChanged(object? sender, Screen e)
        {
            this.SwapScreens(e);
        }
    }
}
