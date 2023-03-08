namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// A mobile-style dialog to display on a screen.
    /// </summary>
    public partial class MobileDialog : UserControl
    {
        /// <summary>
        /// The result for the dialog.
        /// </summary>
        public DialogResult DialogResult { get; set; }

        /// <summary>
        /// The exception thrown while the dialog was active, if any.
        /// </summary>
        public Exception? Exception { get; protected set; }

        /// <summary>
        /// Creates a default instance of <see cref="MobileDialog"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public MobileDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Occurs when the dialog box is closed.
        /// </summary>
        public EventHandler? DialogClosed;

        /// <summary>
        /// Fires the DialogClosed event.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public void Close()
        {
            this.DialogClosed?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
