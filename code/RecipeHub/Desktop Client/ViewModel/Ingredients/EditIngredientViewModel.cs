using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Ingredients;
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

    private readonly IIngredientsService service;

    private string title;
    private string ingredientName;
    private string amount;

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
        set => this.SetField(ref this.amount, value);
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="EditIngredientViewModel" /> class.<br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Service is set to default value.<br />
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
    /// &amp;&amp; this.Amount == string.Empty
    /// </summary>
    /// <param name="service">The service.</param>
    public EditIngredientViewModel(IIngredientsService service)
    {
        this.service = service ?? throw new ArgumentNullException(nameof(service));
        this.title = string.Empty;
        this.ingredientName = string.Empty;
        this.amount = string.Empty;
    }

    /// <summary>
    /// Edits the ingredient. <br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Ingredient has been updated.<br />
    /// </summary>
    /// <param name="ingredient">The ingredient.</param>
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

    /// <inheritdoc/>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <inheritdoc/>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}