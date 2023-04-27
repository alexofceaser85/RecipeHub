using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Components.Recipes
{
    /// <summary>
    /// A item that displays information about a recipe, designed to be shown in a list.
    /// </summary>
    public partial class RecipeListItem : UserControl
    {
        private string authorName;

        /// <summary>
        /// Occurs when the user taps the list item.
        /// </summary>
        public EventHandler<int>? Tapped;

        /// <summary>
        /// The name of the recipe author
        /// </summary>
        public string AuthorName
        {
            get => this.authorName;
            set
            {
                this.authorName = value;
                this.authorNameLabel.Text = @$"By: {value}";
            }
        }

        /// <summary>
        /// The name of the recipe
        /// </summary>
        public string RecipeName
        {
            get => this.recipeNameLabel.Text;
            set => this.recipeNameLabel.Text = value;
        }
        
        /// <summary>
        /// The recipe's ID
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipeListItem"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeListItem()
        {
            this.InitializeComponent();
            this.authorName = "";
        }

        /// <summary>
        /// Creates an instance of <see cref="RecipeListItem"/> with a specified <see cref="Recipe"/> object.<br/>
        /// recipe will be used to fill the initial parameters of the RecipeListItem.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Rating == recipe.Rating<br/>
        /// &amp;&amp; this.AuthorName == recipe.AuthorName<br/>
        /// &amp;&amp; this.SearchTerm == recipe.Name<br/>
        /// &amp;&amp; this.RecipeId == recipe.RecipeId
        /// </summary>
        /// <param name="recipe">The recipe to load</param>
        /// <param name="tags">The tags for the recipe</param>
        public RecipeListItem(Recipe recipe, string[]? tags = null)
        {
            this.InitializeComponent();
            this.authorName = "";
            this.AuthorName = recipe.AuthorName;
            this.RecipeName = recipe.Name;
            this.RecipeId = recipe.Id;

            if (tags == null || tags.Length == 0)
            {
                this.tagsPlaceholderLabel.Text = @"No tags";
            }
            else
            {
                this.tagsPlaceholderLabel.Text = @$"Tags: {tags[0]}";
                for (var i = 1; i < tags.Length; i++)
                {
                    this.tagsPlaceholderLabel.Text += $@", {tags[i]}";
                }
            }

            base.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }

        private void childControlMouseClick(object sender, EventArgs e)
        {
            this.Tapped?.Invoke(this, this.RecipeId);
        }
    }
}