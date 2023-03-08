namespace Desktop_Client.View.Components.General
{
    /// <summary>
    /// A container that renders the items behind it.
    /// </summary>
    public partial class TransparentContainer : UserControl
    {
        /// <summary>
        /// Creates a default instance of <see cref="TransparentContainer"/><br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public TransparentContainer()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Parent == null)
            {
                return;
            }

            var behind = new Bitmap(Parent.Width, Parent.Height);
            foreach (Control c in Parent.Controls)
            {
                if (!c.Bounds.IntersectsWith(this.Bounds) || c == this)
                {
                    continue;
                }

                var x = Math.Max(c.Bounds.X, 0);
                var y = Math.Max(c.Bounds.Y, 0);
                var width = c.Width;
                var height = c.Height;

                var renderBounds = new Rectangle(x, y, width, height);
                c.DrawToBitmap(behind, renderBounds);
            }

            e.Graphics.DrawImage(behind, -Left, -Top);
            behind.Dispose();
        }
    }
}
