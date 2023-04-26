using System.ComponentModel;
using System.Runtime.CompilerServices;
using Shared_Resources.Model.PlannedMeals;
using Web_Client.Pages;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;

namespace Web_Client.ViewModel.PlannedMeals
{
    /// <summary>
    /// The view model for <see cref="PlannedMealsModel"/>
    /// </summary>
    public class PlannedMealsViewModel : INotifyPropertyChanged
    {
        private readonly IPlannedMealsService plannedMealService;
        private readonly IRecipesService recipesService;

        private PlannedMeal[] plannedMeals;
        private Dictionary<int, string[]> recipeTags;

        /// <summary>
        /// The array of planned meals to display
        /// </summary>
        public PlannedMeal[] PlannedMeals
        {
            get => this.plannedMeals;
            set => this.SetField(ref this.plannedMeals, value);
        }

        /// <summary>
        /// Stores the tags for a recipe by its id
        /// </summary>
        public Dictionary<int, string[]> RecipeTags
        {
            get => this.recipeTags;
            set => this.SetField(ref this.recipeTags, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="PlannedMealsViewModel"/>, using a default <see cref="PlannedMealsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.PlannedMeals.Length == 0<br/>
        /// &amp;&amp; this.RecipeTags.Count == 0
        /// </summary>
        public PlannedMealsViewModel() : this(new PlannedMealsService(), new RecipesService())
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealsViewModel"/> with a specified <see cref="IPlannedMealsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>plannedMealService != null<br/>
        /// <b>Postcondition: </b>this.PlannedMeals.Length == 0<br/>
        /// &amp;&amp; this.RecipeTags.Count == 0
        /// </summary>
        /// <param name="plannedMealsService">The planned meal service</param>
        /// <param name="recipesService">The recipes service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlannedMealsViewModel(IPlannedMealsService plannedMealsService, IRecipesService recipesService)
        {
            this.plannedMealService = plannedMealsService ?? throw new ArgumentNullException(nameof(plannedMealsService));
            this.recipesService = recipesService ?? throw new ArgumentNullException(nameof(recipesService));
            this.plannedMeals = Array.Empty<PlannedMeal>();
            this.recipeTags = new Dictionary<int, string[]>();
        }

        /// <summary>
        /// Gets the planned meals for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.PlannedMeals contains all planned meals for the active user
        /// </summary>
        public void Initialize()
        {
            var plannedMeals = this.plannedMealService.GetPlannedMeals();

            this.RecipeTags = plannedMeals.SelectMany(plannedMeal => plannedMeal.Meals)
                                          .SelectMany(meal => meal.Recipes)
                                          .Distinct()
                                          .Select(recipe => recipe.Recipe.Id)
                                          .Distinct()
                                          .ToDictionary(recipeId => recipeId,
                                              recipeId => this.recipesService.GetTypesForRecipe(recipeId));

            this.PlannedMeals = plannedMeals;
        }

        /// <summary>
        /// Removes a recipe from the active user's planned meals.<br/>
        /// <br/>
        /// <b>Precondition: </b>None
        /// <b>Postcondition: </b>The recipe is removed from this.PlannedMeals
        /// </summary>
        /// <param name="mealId">The id of the recipe to remove</param>
        public void RemovePlannedMeal(int mealId)
        {
            this.plannedMealService.RemovePlannedMeal(mealId);
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
