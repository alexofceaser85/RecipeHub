using System.ComponentModel;
using System.Runtime.CompilerServices;
using Web_Client.Pages;
using Web_Client.Service.Ingredients;
using Web_Client.Service.ShoppingList;

namespace Web_Client.ViewModel.ShoppingList
{
    /// <summary>
    /// The viewmodel for <see cref="ShoppingListModel"/>.
    /// </summary>
    public class ShoppingListViewModel: INotifyPropertyChanged
    {
        private Shared_Resources.Model.Ingredients.Ingredient[] shoppingList;

        private readonly IShoppingListService shoppingListService;
        private readonly IIngredientsService ingredientsService;

        /// <summary>
        /// The shopping list
        /// </summary>
        public Shared_Resources.Model.Ingredients.Ingredient[] ShoppingList
        {
            get => this.shoppingList;
            set => this.SetField(ref this.shoppingList, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="ShoppingListViewModel"/>, using a default <see cref="shoppingListService"/>
        /// and a default <see cref="ingredientsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.ShoppingList.Length == 0
        /// </summary>
        public ShoppingListViewModel() : this(new ShoppingListService(), new IngredientsService())
        {

        }

        /// <summary>
        /// Creates a instance of <see cref="ShoppingListViewModel"/>, with specified <see cref="IShoppingListService"/> and
        /// <see cref="IIngredientsService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>shoppingListService != null<br/>
        /// &amp;&amp; ingredientsService != null<br/>
        /// <b>Postcondition: </b>this.ShoppingList.Length == 0
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public ShoppingListViewModel(IShoppingListService shoppingListService, IIngredientsService ingredientsService)
        {
            this.shoppingListService =
                shoppingListService ?? throw new ArgumentNullException(nameof(shoppingListService));
            this.ingredientsService = 
                ingredientsService ?? throw new ArgumentNullException(nameof(ingredientsService));
            this.shoppingList = Array.Empty<Shared_Resources.Model.Ingredients.Ingredient>();
        }

        /// <summary>
        /// Queries the server for the active user's shopping list and loads it into this.ShoppingList.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>this.ShoppingList is populated with the active user's shopping list.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void GetShoppingList()
        {
            this.ShoppingList = this.shoppingListService.GetShoppingList();
        }

        /// <summary>
        /// Adds all items in the shopping list to the user's pantry.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>All items in the shopping list are added to the user's pantry.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddIngredientsToPantry(Shared_Resources.Model.Ingredients.Ingredient[] ingredients)
        {
            this.ingredientsService.AddIngredients(ingredients);
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
