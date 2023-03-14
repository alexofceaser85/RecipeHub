using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Ingredients;
using Shared_Resources.Data.Settings;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients;

/// <summary>
///     View Model for the Edit Ingredient Dialog.
/// </summary>
public class EditIngredientViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// The error message for when the ingredient amount is not an int
    /// </summary>
    public const string NonIntIngredientAmount = "IngredientAmount could not be parsed as an int";

    /// <summary>
    /// The error message for when the ingredient amount is empty
    /// </summary>
    public const string EmptyIngredientAmountErrorMessage = "The amount cannot be empty.";

    private readonly IIngredientsService service;

    private string title;
    private string ingredientName;
    private string amount;
    private string amountErrorMessage;
    private Color amountTextBoxColor;

    /// <summary>
    /// The title for the edit dialog
    /// </summary>
    public string Title
    {
        get => this.title;
        set => this.SetField(ref this.title, value);
    }

    /// <summary>
    /// The name of the ingredient to edit
    /// </summary>
    public string IngredientName
    {
        get => this.ingredientName;
        set
        {
            this.SetField(ref this.ingredientName, value);
            this.Title = $"Edit {this.IngredientName}";
        }
    }

    /// <summary>
    /// The amount of the ingredient, represented as a string
    /// </summary>
    public string Amount
    {
        get => this.amount;
        set
        {
            if (value == string.Empty)
            {
                this.AmountErrorMessage = EmptyIngredientAmountErrorMessage;
                this.AmountTextBoxColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
            }
            else
            {
                this.AmountErrorMessage = string.Empty;
                this.AmountTextBoxColor = Color.White;
            }
            this.SetField(ref this.amount, value);
        }
    }

    /// <summary>
    /// The error message for the ingredient amount text box
    /// </summary>
    public string AmountErrorMessage
    {
        get => this.amountErrorMessage;
        set => this.SetField(ref this.amountErrorMessage, value);
    }

    /// <summary>
    /// The back color for the ingredient amount text box
    /// </summary>
    public Color AmountTextBoxColor
    {
        get => this.amountTextBoxColor;
        set => this.SetField(ref this.amountTextBoxColor, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EditIngredientViewModel" /> class.<br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Service is set to specified value.<br />
    /// &amp;&amp; this.Title == string.Empty <br/>
    /// &amp;&amp; this.IngredientName == string.Empty<br/>
    /// &amp;&amp; this.Amount == string.Empty <br/>
    /// &amp;&amp; this.AmountErrorMessage == string.empty<br/>
    /// &amp;&amp; this.AmountTextBoxColor == Color.White
    /// </summary>
    public EditIngredientViewModel() : this(new IngredientsService())
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EditIngredientViewModel" /> class.<br />
    /// <br />
    /// Precondition: service != null<br />
    /// Postcondition: Service is set to specified value.<br />
    /// &amp;&amp; this.Title == string.Empty <br/>
    /// &amp;&amp; this.IngredientName == string.Empty<br/>
    /// &amp;&amp; this.Amount == string.Empty <br/>
    /// &amp;&amp; this.AmountErrorMessage == string.empty<br/>
    /// &amp;&amp; this.AmountTextBoxColor == Color.White
    /// </summary>
    /// <param name="service">The service.</param>
    public EditIngredientViewModel(IIngredientsService service)
    {
        this.service = service ?? throw new ArgumentNullException(nameof(service));
        this.title = string.Empty;
        this.ingredientName = string.Empty;
        this.amount = string.Empty;
        this.amountErrorMessage = string.Empty;
        this.amountTextBoxColor = Color.White;
    }

    /// <summary>
    /// Edits the ingredient. <br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Ingredient has been updated.<br />
    /// </summary>
    /// <returns>True if the ingredient was edited, false otherwise.</returns>
    public bool EditIngredient()
    {
        try
        {
            var ingredient = this.CreateIngredient();
            return this.service.UpdateIngredient(ingredient);
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private Ingredient CreateIngredient()
    {
        if (!int.TryParse(this.amount, out var amount))
        {
            throw new InvalidOperationException(NonIntIngredientAmount);
        }
        return new Ingredient(this.ingredientName, amount, MeasurementType.Quantity);
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