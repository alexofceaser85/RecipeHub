namespace Desktop_Client.View.Dialog
{
    /// <summary>
    /// Displays a Windows Forms-style message dialog.
    /// </summary>
    public partial class MessageDialog : MobileDialog
    {
        /// <summary>
        /// Creates an instance of <see cref="MessageDialog"/> with a specified title and content.<br/>
        /// <see cref="MessageBoxButtons"/> can be specified, but will default to <see cref="MessageBoxButtons.OK"/><br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>title is displayed at the top of the dialog<br/>
        /// &amp;&amp; content is displayed below the title<br/>
        /// &amp;&amp; The buttons reflect the specified buttonOption
        /// </summary>
        /// <param name="title">The title of the message box</param>
        /// <param name="content">The content of the message box</param>
        /// <param name="buttonOption">The buttons to display to the user</param>
        public MessageDialog(string title, string content, MessageBoxButtons buttonOption = MessageBoxButtons.OK)
        {
            this.InitializeComponent();
            var results = new[] {
                DialogResult.None,
                DialogResult.None,
                DialogResult.None
            };
            var buttons = new[] {
                this.button1,
                this.button2,
                this.button3
            };

            this.titleLabel.Text = title;
            this.messageLabel.Text = content;

            switch (buttonOption)
            {
                case MessageBoxButtons.OK:
                    results[0] = DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    results[1] = DialogResult.Cancel;
                    results[0] = DialogResult.OK;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    results[2] = DialogResult.Abort;
                    results[1] = DialogResult.Retry;
                    results[0] = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    results[2] = DialogResult.Yes;
                    results[1] = DialogResult.No;
                    results[0] = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    results[1] = DialogResult.Yes;
                    results[0] = DialogResult.No;
                    break;
                case MessageBoxButtons.RetryCancel:
                    results[1] = DialogResult.Retry;
                    results[0] = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.CancelTryContinue:
                    results[2] = DialogResult.Cancel;
                    results[1] = DialogResult.TryAgain;
                    results[0] = DialogResult.Continue;
                    break;
            }

            for (var i = 0; i < buttons.Length; i++)
            {
                var result = results[i];
                if (results[i] == DialogResult.None)
                {
                    buttons[i].Hide();
                    continue;
                }

                if (results[i] == DialogResult.TryAgain)
                {
                    buttons[i].Text = "Try";
                }

                buttons[i].Text = results[i].ToString();
                buttons[i].Click += (_, _) =>
                {
                    this.DialogResult = result;
                    this.Close();
                };
            }

            //Manual resizing as automatic resizing keeps cutting off the bottoms of the buttons
            this.Size = new Size(this.Width, this.messageLabel.Height + 150);
        }
    }
}
