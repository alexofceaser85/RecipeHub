using Desktop_Client.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients;

/// <summary>
///     View Model for the Edit Ingredient Dialog.
/// </summary>
public class EditIngredientViewModel
{
    private readonly IIngredientsService service;

    /// <summary>
    /// Initializes a new instance of the <see cref="EditIngredientViewModel" /> class.<br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Service is set to default value.<br />
    /// </summary>
    public EditIngredientViewModel()
    {
        this.service = new IngredientsService();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EditIngredientViewModel" /> class.<br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Service is set to specified value.<br />
    /// </summary>
    /// <param name="service">The service.</param>
    public EditIngredientViewModel(IIngredientsService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Edits the ingredient. <br />
    /// <br />
    /// Precondition: None<br />
    /// Postcondition: Ingredient has been updated.<br />
    /// </summary>
    /// <param name="ingredient">The ingredient.</param>
    /// <returns>True if the ingredient was edited, false otherwise.</returns>
    public bool EditIngredient(Ingredient ingredient)
    {
        return this.service.UpdateIngredient(ingredient);
    }
}