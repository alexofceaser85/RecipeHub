namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class Screen : UserControl
    {
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
    }
}
