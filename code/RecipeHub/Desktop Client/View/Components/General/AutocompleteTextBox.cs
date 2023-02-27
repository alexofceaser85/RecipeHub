namespace Desktop_Client.View.Components.General
{
    /// <summary>
    /// A text box that will check if any suggestion contains the text in the text box, not only those that start with it.<br/>
    /// Does not work well with our current setup. Resizing the window will cause the drop down to move out of place, in most instances.<br/>
    /// Source: https://stackoverflow.com/questions/43254621/customize-textbox-autocomplete
    /// </summary>
    public class AutocompleteTextBox : TextBox
    {
        /// <summary>
        /// The error message for when setting MaxSuggestions to a negative number.
        /// </summary>
        public const string NegativeMaxSuggestionsException = "MaxSuggestions must be a non-negative number";

        /// <summary>
        /// The default number of max suggestions to get.
        /// </summary>
        public const int DefaultMaxSuggestions = 5;

        private readonly ListBox listBox;
        private bool isAdded;
        private string formerValue = string.Empty;
        private int maxSuggestions;

        /// <summary>
        /// The autocomplete values
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// The selected values
        /// </summary>
        public List<string> SelectedValues
        {
            get
            {
                var result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<string>(result);
            }
        }

        /// <summary>
        /// The max number of suggestions to give the user. Defaults to 5.<br/>
        /// <br/>
        /// <b>Precondition: </b>b>value >= 0<br/>
        /// <b>Postcondition: </b>this.MaxSuggestions == value
        /// </summary>
        public int MaxSuggestions
        {
            get => this.maxSuggestions;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), NegativeMaxSuggestionsException);
                }
                this.maxSuggestions = value;
            }
        }

        /// <summary>
        /// Creates a default instance of <see cref="AutocompleteTextBox"/><br/>
        /// Example Usage is available in the link in the class documentation.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Values.Count == 0<br/>
        /// &amp;&amp; this.SelectedValues.Count == 0<br/>
        /// &amp;&amp; this.MaxSuggestions == 5
        /// </summary>
        public AutocompleteTextBox()
        {
            this.maxSuggestions = DefaultMaxSuggestions;
            this.listBox = new ListBox();
            this.Values = Array.Empty<string>();

            this.InitializeComponent();
            this.ResetListBox();
        }

        private void InitializeComponent()
        {
            this.KeyDown += this.this_KeyDown;
            this.KeyUp += this.this_KeyUp;
        }

        private void ShowListBox()
        {
            if (!this.isAdded)
            {
                this.SetListboxLocation();
                Control parent = this;
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                }

                parent.Controls.Add(this.listBox);
                this.isAdded = true;
                this.listBox.Click += (_, _) => this.AcceptSuggestion();
            }
            this.listBox.Visible = true;
            this.listBox.BringToFront();
        }

        private void ResetListBox()
        {
            this.listBox.Visible = false;
        }

        private bool AcceptSuggestion()
        {
            if (!this.listBox.Visible)
            {
                return false;
            }

            Text = this.listBox.SelectedItem!.ToString();
            this.ResetListBox();
            this.formerValue = Text;
            this.Select(this.Text.Length, 0);
            return true;
        }

        private void SetListboxLocation()
        {
            Control parent = this;
            var top = 0;
            var left = 0;

            while (parent.Parent != null && parent.Parent.Parent != null)
            {
                top += parent.Top;
                left += parent.Left;
                parent = parent.Parent;
            }

            this.listBox.Location = new Point(left, top + base.Height);
        }

        private void this_KeyUp(object? sender, KeyEventArgs e)
        {
            this.UpdateListBox();
            this.SetListboxLocation();
        }

        private void this_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        e.Handled = this.AcceptSuggestion(); ;
                        break;
                    }
                case Keys.Down:
                    {
                        if ((this.listBox.Visible) && (this.listBox.SelectedIndex < this.listBox.Items.Count - 1))
                            this.listBox.SelectedIndex++;
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (this.listBox is { Visible: true, SelectedIndex: > 0 })
                            this.listBox.SelectedIndex--;
                        e.Handled = true;
                        break;
                    }


            }
        }

        /// <inheritdoc/>
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (this.listBox.Visible)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {
            if (Text == this.formerValue)
            {
                return;
            }

            this.formerValue = this.Text;
            var word = this.Text;

            if (word.Length == 0)
            {
                this.ResetListBox();
                return;
            }

            var matches = Array.FindAll(this.Values,
                x => (x.ToLower().Contains(word.ToLower())));
            if (matches.Length == 0)
            {
                this.ResetListBox();
                return;
            }

            if (matches.Length > this.maxSuggestions)
            {
                matches = matches[..this.maxSuggestions];
            }

            this.ShowListBox();

            this.listBox.BeginUpdate();
            this.listBox.Items.Clear();
            Array.ForEach(matches, x => this.listBox.Items.Add(x));
            this.listBox.SelectedIndex = 0;
            this.listBox.Height = 0;
            this.listBox.Width = 0;

            Focus();

            using var graphics = this.listBox.CreateGraphics();
            for (var i = 0; i < this.listBox.Items.Count; i++)
            {
                if (i < 20)
                {
                    this.listBox.Height += this.listBox.GetItemHeight(i);
                }

                // it item width is larger than the current one
                // set it to the new max item width
                // GetItemRectangle does not work for me
                // we add a little extra space by using '_'
                int itemWidth = (int)graphics.MeasureString(((string)this.listBox.Items[i]) + "_", this.listBox.Font).Width;
                this.listBox.Width = (this.listBox.Width < itemWidth) ? itemWidth : this.Width;
            }

            this.listBox.EndUpdate();
        }

    }
}
