using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.View.Screens;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients
{
    /// <summary>
    /// View Model for <see cref="IngredientsScreen"/>.
    /// </summary>
    public class IngredientsViewModel : INotifyPropertyChanged
    {
        private readonly IIngredientsService service;

        private bool removeAllButtonEnabled;
        private Ingredient[] ingredients;

        /// <summary>
        /// Whether the remove all button is enabled.
        /// </summary>
        public bool RemoveAllButtonEnabled
        {
            get => this.removeAllButtonEnabled;
            set => this.SetField(ref this.removeAllButtonEnabled, value);
        }

        /// <summary>
        /// The list of ingredients to display.<br/>
        /// An empty array sets this.RemoveAllButtonEnabled to false.
        /// </summary>
        public Ingredient[] Ingredients
        {
            get => this.ingredients;
            set
            {
                this.SetField(ref this.ingredients, value);
                this.RemoveAllButtonEnabled = this.Ingredients.Length > 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to default value.<br />
        /// </summary>
        public IngredientsViewModel() : this(new IngredientsService())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsViewModel"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Service is set to specified value.<br />
        /// </summary>
        /// <param name="service">The service.</param>
        public IngredientsViewModel(IIngredientsService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.ingredients = Array.Empty<Ingredient>();
        }
        
        /// <summary>
        /// Gets all ingredients for user.<br />
        /// <br />
        /// Precondition: Session.Key is an active session key<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <returns>the list of all ingredients for the user.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public void GetAllIngredientsForUser()
        {
            this.Ingredients = this.service.GetAllIngredientsForUser();
        }

        /// <summary>
        /// Removes the specified ingredient.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Removes the ingredients from the logged in user's pantry.<br />
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns>Whether the ingredient was removed or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public bool RemoveIngredient(Ingredient ingredient)
        {
            try
            {
                return this.service.DeleteIngredient(ingredient);
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

        /// <summary>
        /// Removes all ingredients from the logged in user's pantry.<br />
        /// <br />
        /// Precondition: Session.Key is a valid an active session key<br />
        /// Postcondition: Removes all ingredients from the logged in user's pantry.<br />
        /// </summary>
        /// <returns>Whether all ingredients were removed or not.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public bool RemoveAllIngredients()
        {
            try
            {
                return this.service.DeleteAllIngredientsForUser();
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