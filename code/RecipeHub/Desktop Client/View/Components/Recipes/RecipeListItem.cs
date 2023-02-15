using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Components.Recipes
{
    public partial class RecipeListItem : UserControl
    {
        private int rating;
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
                this.authorNameLabel.Text = $"By: {value}";
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
        /// The recipe's rating
        /// </summary>
        public int Rating
        {
            get => this.rating;
            set
            {
                this.rating = value;
                this.ratingLabel.Text = $"Rating: {value}/5";
            }
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
        /// &amp;&amp; this.RecipeName == recipe.Name<br/>
        /// &amp;&amp; this.RecipeId == recipe.RecipeId
        /// </summary>
        /// <param name="recipe">The recipe to load</param>
        public RecipeListItem(Recipe recipe)
        {
            this.InitializeComponent();
            this.authorName = "";
            this.Rating = recipe.Rating;
            this.AuthorName = recipe.AuthorName;
            this.RecipeName = recipe.Name;
            this.RecipeId = recipe.Id;
        }

        private void childControlMouseClick(object sender, EventArgs e)
        {
            this.Tapped?.Invoke(this, this.RecipeId);
        }
    }
}
