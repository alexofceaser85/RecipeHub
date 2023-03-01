using System.ComponentModel;
using System.Runtime.CompilerServices;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Units;
using Web_Client.Service.Recipes;

namespace Web_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes screen.
    /// </summary>
    public class RecipeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The message displayed when no tags have been added.
        /// </summary>
        public const string NoTagsMessage = "No tags have been added...Yet!";

        /// <summary>
        /// The message displayed when no ingredients have been added.
        /// </summary>
        public const string NoIngredientsMessage = "No ingredients have been added...Yet!";

        /// <summary>
        /// The message displayed when no instructions have been added.
        /// </summary>
        public const string NoInstructionsMessage = "No steps have been added... Yet!";

        private string recipeName;
        private string authorName;
        private string description;
        private string tags;
        private string ingredients;
        private string instructions;
        private string userRatingText;
        private string yourRatingText;
        private readonly IRecipesService service;

        /// <summary>
        /// The name of the recipe, as should be displayed on the screen.
        /// </summary>
        public string RecipeName
        {
            get => this.recipeName;
            set => this.SetField(ref this.recipeName, value);
        }

        /// <summary>
        /// The name of the author, as should be displayed on the screen.
        /// </summary>
        public string AuthorName
        {
            get => this.authorName;
            set => this.SetField(ref this.authorName, value);
        }

        /// <summary>
        /// The tags for the recipe, as should be displayed on the screen.
        /// </summary>
        public string Tags
        {
            get => this.tags;
            set => this.SetField(ref this.tags, value);
        }

        /// <summary>
        /// The description of the recipe, as should be displayed on the screen.
        /// </summary>
        public string Description
        {
            get => this.description;
            set => this.SetField(ref this.description, value);
        }

        /// <summary>
        /// The ingredients for the recipe, as should be displayed on the screen.
        /// </summary>
        public string Ingredients
        {
            get => this.ingredients;
            set => this.SetField(ref this.ingredients, value);
        }

        /// <summary>
        /// The instructions for the recipe, as should be displayed on the screen.
        /// </summary>
        public string Instructions
        {
            get => this.instructions;
            set => this.SetField(ref this.instructions, value);
        }

        /// <summary>
        /// The over all user rating in text for, as should be displayed on the screen.
        /// </summary>
        public string UserRatingText
        {
            get => this.userRatingText;
            set => this.SetField(ref this.userRatingText, value);
        }

        /// <summary>
        /// The current user's rating for the recipe, as should be displayed on the screen.
        /// </summary>
        public string YourRatingText
        {
            get => this.yourRatingText;
            set => this.SetField(ref this.yourRatingText, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListViewModel"/>.<br/>
        /// Uses an instance of <see cref="RecipesService"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.RecipeName == string.Empty<br/>
        /// &amp;&amp; this.AuthorName == string.Empty<br/>
        /// &amp;&amp; this.Description == string.Empty<br/>
        /// &amp;&amp; this.Ingredients == string.Empty<br/>
        /// &amp;&amp; this.Instructions == string.Empty<br/>
        /// &amp;&amp; this.UserRatingText == string.Empty<br/>
        /// &amp;&amp; this.YourRatingText == string.Empty.
        /// </summary>
        public RecipeViewModel() : this(new RecipesService())
        {
        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesService"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>this.RecipeName == string.Empty<br/>
        /// &amp;&amp; this.AuthorName == string.Empty<br/>
        /// &amp;&amp; this.Description == string.Empty<br/>
        /// &amp;&amp; this.Ingredients == string.Empty<br/>
        /// &amp;&amp; this.Instructions == string.Empty<br/>
        /// &amp;&amp; this.UserRatingText == string.Empty<br/>
        /// &amp;&amp; this.YourRatingText == string.Empty.
        /// </summary>
        public RecipeViewModel(IRecipesService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service),
                               RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);

            this.recipeName = "";
            this.authorName = "";
            this.description = "";
            this.ingredients = "";
            this.instructions = "";
            this.userRatingText = "";
            this.yourRatingText = "";
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;
        
        /// <summary>
        /// Loads the information for a recipe from the server and updates the appropriate properties to match them.<br/>
        /// <br/>
        /// <b>Precondition: </b>A recipe with recipeId exists and is visible to the user.<br/>
        /// <b>Postcondition: </b>this.RecipeName == the recipe's name<br/>
        /// &amp;&amp; this.AuthorName == the recipe author's name<br/>
        /// &amp;&amp; this.Tags == the recipe's tags<br/>
        /// &amp;&amp; this.Description == the recipe's description<br/>
        /// &amp;&amp; this.Ingredients == the recipe's ingredients<br/>
        /// &amp;&amp; this.Instructions == the recipe's instructions<br/>
        /// &amp;&amp; this.UserRatingText == the recipe's overall rating<br/>
        /// &amp;&amp; this.YourRatingText == the user's rating for the recipe.
        /// </summary>
        /// <param name="recipeId"></param>
        public void Initialize(int recipeId)
        {
            this.LoadRecipe(recipeId);
            this.LoadTags(recipeId);
            this.LoadIngredients(recipeId);
            this.LoadInstructions(recipeId);
        }

        private void LoadRecipe(int recipeId)
        {
            var recipe = this.service.GetRecipe(recipeId);
            this.RecipeName = recipe.Name;
            this.AuthorName = recipe.AuthorName;
            this.UserRatingText = $"User Rating: {recipe.Rating}/5";
            this.YourRatingText = "Your Rating: 0/5";
            this.Description = recipe.Description;
        }

        private void LoadTags(int recipeId)
        {
            var tags = this.service.GetTypesForRecipe(recipeId);
            if (tags.Length == 0)
            {
                this.Tags = NoTagsMessage;
                return;
            }

            this.Tags = tags[0];
            for (var i = 1; i < tags.Length; i++)
            {
                this.Tags += $"<br>{tags[i]}";
            }
        }

        private void LoadIngredients(int recipeId)
        {
            var ingredients = this.service.GetIngredientsForRecipe(recipeId);
            if (ingredients.Length == 0)
            {
                this.Ingredients = NoIngredientsMessage;
                return;
            }

            var ingredientText = "";
            foreach (var ingredient in ingredients)
            {
                var unit = BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType);
                ingredientText += $"- {ingredient.Name} - {ingredient.Amount} {unit}<br>";
            }

            this.Ingredients = ingredientText.TrimEnd();
        }

        private void LoadInstructions(int recipeId)
        {
            var steps = this.service.GetStepsForRecipe(recipeId);
            if (steps.Length == 0)
            {
                this.Instructions = NoInstructionsMessage;
                return;
            }

            var instructions = "";
            foreach (var step in steps)
            {
                instructions += $"{step.StepNumber}: {step.Name}<br>{step.Instructions}<br><br>";
            }

            this.Instructions = instructions.TrimEnd();
        }

        /// <summary>
        /// Fires this.PropertyChanged with the specified property name.<br/>
        /// Defaults to the name of the calling member, allowing for easier use within property bodies.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates a specified field, returning whether or not the value was changed.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.[field] == value
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <param name="field">The field that stores the data for the property</param>
        /// <param name="value">The new value for the field</param>
        /// <param name="propertyName">The name of the property that is being updated.</param>
        /// <returns>Whether the value of the field has changed.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}