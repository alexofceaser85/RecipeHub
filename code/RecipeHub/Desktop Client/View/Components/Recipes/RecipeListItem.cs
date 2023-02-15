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

        public EventHandler<int> Tapped;

        public string AuthorName
        {
            get => this.authorName;
            set
            {
                this.authorName = value;
                this.authorNameLabel.Text = $"By: {value}";
            }
        }

        public string RecipeName
        {
            get => this.recipeNameLabel.Text;
            set => this.recipeNameLabel.Text = value;
        }

        public int Rating
        {
            get => this.rating;
            set
            {
                this.rating = value;
                this.ratingLabel.Text = $"Rating: {value}/5";
            }
        }

        public int RecipeId { get; set; }

        public RecipeListItem()
        {
            this.InitializeComponent();
        }

        public RecipeListItem(Recipe recipe)
        {
            this.InitializeComponent();
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
