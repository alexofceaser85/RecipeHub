using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Ingredients;
using Shared_Resources.Data.Settings;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients
{
    /// <summary>
    /// View Model for the Add Ingredients.
    /// </summary>
    public class AddIngredientsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The error message for when the ingredient amount is not an int
        /// </summary>
        public const string NonIntIngredientAmount = "IngredientAmount could not be parsed as an int";

        /// <summary>
        /// The error message for when the ingredient name is empty
        /// </summary>
        public const string EmptyIngredientNameErrorMessage = "The ingredient name cannot be empty.";

        /// <summary>
        /// The error message for when the ingredient name is empty
        /// </summary>
        public const string EmptyIngredientAmountErrorMessage = "The ingredient amount cannot be empty.";

        private readonly IIngredientsService service;

        private string ingredientName;
        private string[] ingredientNames;
        private string ingredientAmount;
        private string ingredientNameErrorMessage;
        private string ingredientAmountErrorMessage;
        private Color ingredientNameTextBoxColor;
        private Color ingredientAmountTextBoxColor;
        private int selectedMeasurementIndex;
        private MeasurementType selectedMeasurementType;

        /// <summary>
        /// The name of the ingredient to add.
        /// </summary>
        public string IngredientName
        {
            get => this.ingredientName;
            set
            {
                if (value == string.Empty)
                {
                    this.ingredientNameErrorMessage = EmptyIngredientNameErrorMessage;
                    this.ingredientNameTextBoxColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
                }
                else
                {
                    this.ingredientNameErrorMessage = string.Empty;
                    this.ingredientNameTextBoxColor = Color.White;
                }
                this.SetField(ref this.ingredientName, value);
            }
        }

        /// <summary>
        /// The list of all ingredient names already added to the system.
        /// </summary>
        public string[] IngredientNames
        {
            get => this.ingredientNames;
            set => this.SetField(ref this.ingredientNames, value);
        }

        /// <summary>
        /// The amount of the ingredient
        /// </summary>
        public string IngredientAmount
        {
            get => this.ingredientAmount;
            set
            {
                if (value == string.Empty)
                {
                    this.ingredientAmountErrorMessage = EmptyIngredientAmountErrorMessage;
                    this.ingredientAmountTextBoxColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
                }
                else
                {
                    this.ingredientAmountErrorMessage = string.Empty;
                    this.ingredientAmountTextBoxColor = Color.White;
                }
                this.SetField(ref this.ingredientAmount, value);
            }
        }

        /// <summary>
        /// The error message to display for the ingredient name text box
        /// </summary>
        public string IngredientNameErrorMessage
        {
            get => this.ingredientNameErrorMessage;
            set => this.SetField(ref this.ingredientNameErrorMessage, value);
        }

        /// <summary>
        /// The error message to display for the ingredient amount text box
        /// </summary>
        public string IngredientAmountErrorMessage
        {
            get => this.ingredientAmountErrorMessage;
            set => this.SetField(ref this.ingredientAmountErrorMessage, value);
        }

        /// <summary>
        /// The back color for the ingredient name text box
        /// </summary>
        public Color IngredientNameTextBoxColor
        {
            get => this.ingredientNameTextBoxColor;
            set => this.SetField(ref this.ingredientNameTextBoxColor, value);
        }

        /// <summary>
        /// The back color for the ingredient amount text box
        /// </summary>
        public Color IngredientAmountTextBoxColor
        {
            get => this.ingredientAmountTextBoxColor;
            set => this.SetField(ref this.ingredientAmountTextBoxColor, value);
        }

        /// <summary>
        /// The index for the selected measurement type
        /// </summary>
        public int SelectedMeasurementIndex
        {
            get => this.selectedMeasurementIndex;
            set 
            {
                this.SetField(ref this.selectedMeasurementIndex, value);
                this.SetField(ref this.selectedMeasurementType, (MeasurementType) value);
            }
        }

        /// <summary>
        /// How the ingredient should be measured.
        /// </summary>
        public MeasurementType SelectedMeasurementType
        {
            get => this.selectedMeasurementType;
            set
            {
                this.SetField(ref this.selectedMeasurementType, value);
                this.SetField(ref this.selectedMeasurementIndex, (int)value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// <b>Postcondition: </b>service != null <br/>
        /// &amp;&amp; this.IngredientName == string.Empty<br/>
        /// &amp;&amp; this.IngredientName == string.Empty<br/>
        /// &amp;&amp; this.IngredientNames.Length == 0<br/>
        /// &amp;&amp; this.IngredientAmount == string.Empty<br/>
        /// &amp;&amp; this.SelectedMeasurementType == MeasurementTypes.Quantity<br/>
        /// &amp;&amp; this.SelectedMeasurementIndex == 0<br/>
        /// &amp;&amp; this.IngredientNameErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.IngredientAmountErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.IngredientNameTextBoxColor == Color.White<br/>
        /// &amp;&amp; this.IngredientAmountTextBoxColor == Color.White
        /// </summary>
        public AddIngredientsViewModel() : this(new IngredientsService())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIngredientsViewModel"/> class.<br />
        /// <br />
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>service != null <br/>
        /// &amp;&amp; this.IngredientName == string.Empty<br/>
        /// &amp;&amp; this.IngredientName == string.Empty<br/>
        /// &amp;&amp; this.IngredientNames.Length == 0<br/>
        /// &amp;&amp; this.IngredientAmount == string.Empty<br/>
        /// &amp;&amp; this.SelectedMeasurementType == MeasurementTypes.Quantity<br/>
        /// &amp;&amp; this.SelectedMeasurementIndex == 0<br/>
        /// &amp;&amp; this.IngredientNameErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.IngredientAmountErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.IngredientNameTextBoxColor == Color.White<br/>
        /// &amp;&amp; this.IngredientAmountTextBoxColor == Color.White
        /// </summary>
        /// <param name="service">the specified service</param>
        /// <exception cref="InvalidOperationException"></exception>
        public AddIngredientsViewModel(IIngredientsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.ingredientName = string.Empty;
            this.ingredientNames = Array.Empty<string>();
            this.ingredientAmount = string.Empty;
            this.selectedMeasurementType = MeasurementType.Quantity;
            this.selectedMeasurementIndex = 0;
            this.ingredientNameErrorMessage = string.Empty;
            this.ingredientAmountErrorMessage = string.Empty;
            this.ingredientNameTextBoxColor = Color.White;
            this.ingredientAmountTextBoxColor = Color.White;
        }

        /// <summary>
        /// Initializes the viewmodel by querying the server for a list of ingredient names.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.IngredientNames contains all ingredient names.
        /// </summary>
        public void Initialize()
        {
            this.IngredientNames = this.service.GetSuggestions("");
        }
        
        /// <summary>
        /// Adds the specified ingredient to the logged in user's pantry.<br />
        /// <br />
        /// Precondition: Session.Key is a valid session key<br />
        /// &amp;&amp; !string.IsNullOrWhiteSpace(this.IngredientName) <br/>
        /// &amp;&amp; int.TryParse(this.IngredientAmount)<br/>
        /// Postcondition: The ingredient is added to the logged in user's pantry.<br />
        /// </summary>
        /// <returns>Whether the ingredient was successfully added or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public bool AddIngredient()
        {
            try
            {
                var ingredient = this.CreateIngredient();
                return this.service.AddIngredient(ingredient);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch
            {
                return false;
            }
        }

        private Ingredient CreateIngredient()
        {
            if (!int.TryParse(this.ingredientAmount, out var amount))
            {
                throw new InvalidOperationException(NonIntIngredientAmount);
            }
            return new Ingredient(this.ingredientName, amount, this.selectedMeasurementType);
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
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}