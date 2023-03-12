using System.ComponentModel;
using System.Runtime.CompilerServices;
using Shared_Resources.Model.PlannedMeals;
using Web_Client.Pages;
using Web_Client.Service.PlannedMeals;

namespace Web_Client.ViewModel.PlannedMeals
{
    /// <summary>
    /// The view model for <see cref="PlannedMealsModel"/>
    /// </summary>
    public class PlannedMealsViewModel : INotifyPropertyChanged
    {
        private readonly IPlannedMealsService service;
        private PlannedMeal[] plannedMeals;

        /// <summary>
        /// The array of planned meals to display
        /// </summary>
        public PlannedMeal[] PlannedMeals
        {
            get => this.plannedMeals;
            set => this.SetField(ref this.plannedMeals, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="PlannedMealsViewModel"/>, using a default <see cref="PlannedMealsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.PlannedMeals.Length == 0
        /// </summary>
        public PlannedMealsViewModel() : this(new PlannedMealsService())
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealsViewModel"/> with a specified <see cref="IPlannedMealsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>this.PlannedMeals.Length == 0
        /// </summary>
        /// <param name="service">The planned meal service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlannedMealsViewModel(IPlannedMealsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.plannedMeals = Array.Empty<PlannedMeal>();
        }

        /// <summary>
        /// Gets the planned meals for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.PlannedMeals contains all planned meals for the active user
        /// </summary>
        public void Initialize()
        {
            this.PlannedMeals = this.service.GetPlannedMeals();
        }

        /// <summary>
        /// Removes a recipe from the active user's planned meals.<br/>
        /// <br/>
        /// <b>Precondition: </b>None
        /// <b>Postcondition: </b>The recipe is removed from this.PlannedMeals
        /// </summary>
        /// <param name="mealDate">The date for the planned meal</param>
        /// <param name="category">The category of the planned meal</param>
        /// <param name="recipeId">The id of the recipe to remove</param>
        public void RemovePlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            this.service.RemovePlannedMeal(mealDate, category, recipeId);
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
