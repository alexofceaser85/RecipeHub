using Desktop_Client.View.Screens;
using Screen = Desktop_Client.View.Screens.Screen;

namespace Desktop_Client.View
{
    public partial class MainWindow : Form
    {
        private Screen? activeScreen;

        public MainWindow()
        {
            InitializeComponent();

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
            this.Controls.Add(newScreen);
            this.activeScreen = newScreen;
        }

        private void OnScreenChanged(object? sender, Screen e)
        {
            this.SwapScreens(e);
        }
    }
}
