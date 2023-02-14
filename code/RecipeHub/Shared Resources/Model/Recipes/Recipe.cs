using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Model.Recipes
{
    /// <summary>
    /// Stores information for a recipe.
    /// </summary>
    public class Recipe
    {
        private string authorName;
        private string name;
        private string description;

        /// <summary>
        /// The recipe's unique identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the recipe's author.
        /// </summary>
        [JsonPropertyName("authorName")]
        public string AuthorName
        {
            get => this.authorName;
            set => this.authorName = value ?? 
                                     throw new ArgumentNullException(nameof(value), RecipesErrorMessages.AuthorNameCannotBeNull);
        }

        /// <summary>
        /// The name of the recipe.
        /// </summary>
        [JsonPropertyName("name")] 
        public string Name
        {
            get => this.name;
            set => this.name = value ?? 
                               throw new ArgumentNullException(nameof(value), RecipesErrorMessages.RecipeNameCannotBeNull);
        }

        /// <summary>
        /// The description for the recipe.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description
        {
            get => this.description;
            set => this.description = value ?? 
                                      throw new ArgumentNullException(nameof(value), RecipesErrorMessages.RecipeDescriptionCannotBeNull);
        }

        /// <summary>
        /// The average rating for the recipe.
        /// </summary>
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Whether the recipe is publicly viewable.
        /// </summary>
        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        /// <summary>
        /// The ingredients for the recipe.
        /// </summary>
        [JsonPropertyName("ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="Recipe"/> with a specified id, author name, name, description, and public setting.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Id == 0<br/>
        /// &amp;&amp; this.AuthorName == string.Empty<br/>
        /// &amp;&amp; this.Name == string.Empty<br/>
        /// &amp;&amp; this.Description == string.Empty<br/>
        /// &amp;&amp; this.IsPublic == false<br/>
        /// &amp;&amp; this.Rating == 0<br/>
        /// &amp;&amp; this.Ingredients.IsEmpty()
        /// </summary>
        public Recipe() : this(0, string.Empty, string.Empty, string.Empty, false)
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="Recipe"/> with a specified id, author name, name, description, and public setting.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Id == id<br/>
        /// &amp;&amp; this.AuthorName == authorName<br/>
        /// &amp;&amp; this.Name == name<br/>
        /// &amp;&amp; this.Description == description<br/>
        /// &amp;&amp; this.IsPublic == isPublic<br/>
        /// &amp;&amp; this.Rating == 0<br/>
        /// &amp;&amp; this.Ingredients.IsEmpty()
        /// </summary>
        /// <param name="id">The recipe ID.</param>
        /// <param name="authorName">The author's name.</param>
        /// <param name="name">The recipe's name.</param>
        /// <param name="description">The recipe's description.</param>
        /// <param name="isPublic">Whether the recipe is publicly viewable.</param>
        public Recipe(int id, string authorName, string name, string description, bool isPublic)
        {
            this.authorName = authorName;
            this.name = name;
            this.description = description;
            this.Id = id;
            this.AuthorName = authorName;
            this.Name = name;
            this.Description = description;
            this.IsPublic = isPublic;
            this.Ingredients = new List<Ingredient>();
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is not Recipe other)
            {
                return false;
            }
            return this.Id == other.Id && this.authorName == other.authorName && this.Name == other.Name 
                   && this.Description == other.Description && this.Rating == other.Rating && this.IsPublic == other.IsPublic;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// A stub class used as a placeholder
    /// </summary>
    public struct Ingredient
    {
        /// <summary>
        /// Name stub
        /// </summary>
        public string Name;

        /// <summary>
        /// Id stub
        /// </summary>
        public int Id;

        /// <summary>
        /// Amount stub
        /// </summary>
        public int Amount;
    }

    /// <summary>
    /// A stub class used as a placeholder
    /// </summary>
    public struct RecipeStep
    {
        /// <summary>
        /// Name stub
        /// </summary>
        public string Name;

        /// <summary>
        /// Number stub
        /// </summary>
        public int Number;

        /// <summary>
        /// Instructions stub
        /// </summary>
        public string Instructions;
    }
}
