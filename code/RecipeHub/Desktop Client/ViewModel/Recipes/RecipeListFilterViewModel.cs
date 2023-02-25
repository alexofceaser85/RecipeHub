using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Filters;

namespace Desktop_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the recipe types
    /// </summary>
    public class RecipeListFilterViewModel : INotifyPropertyChanged
    {
        private readonly IRecipeTypesService service;

        private string searchTerm;
        private bool filterForAvailableIngredients;
        private string[] tags;
        private List<string> selectedTags;

        /// <summary>
        /// The text displayed in the tag text box.
        /// </summary>
        public string SearchTerm
        {
            get => this.searchTerm;
            set => this.SetField(ref this.searchTerm, value);
        }

        /// <summary>
        /// Whether the checkbox for the filter for available ingredients toggle should be checked.
        /// </summary>
        public bool FilterForAvailableIngredients
        {
            get => filterForAvailableIngredients;
            set => SetField(ref filterForAvailableIngredients, value);
        }

        /// <summary>
        /// The list of all selected tags
        /// </summary>
        public List<string> SelectedTags
        {
            get => this.selectedTags;
            set => this.SetField(ref this.selectedTags, value);
        }
        
        /// <summary>
        /// The list of filtered tags displayed in the tag list
        /// </summary>
        public BindingList<string> FilteredTags { get; set; }

        /// <summary>
        /// The filter object that represents all selected filters.
        /// </summary>
        public RecipeFilters Filters => new() {
            OnlyAvailableIngredients = this.filterForAvailableIngredients,
            MatchTags = this.selectedTags.ToArray()
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListFilterViewModel"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.FilteredTags.Count == 0<br/>
        /// &amp;&amp; this.FilterForAvailableIngredients == true<br/>
        /// &amp;&amp; this.SearchTerm == string.Empty<br/>
        /// &amp;&amp; this.SelectedTags.Count == 0
        /// </summary>
        public RecipeListFilterViewModel() : this (new RecipeTypesService())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListFilterViewModel"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public RecipeListFilterViewModel(IRecipeTypesService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service),
                RecipeTypesViewModelErrorMessages.ServiceCannotBeNull);
            this.FilteredTags = new BindingList<string>();
            this.searchTerm = "";
            this.tags = Array.Empty<string>();
            this.selectedTags = new List<string>();
            this.filterForAvailableIngredients = true;
        }
        
        /// <summary>
        /// Sets up the initial values for the viewmodel using the specified <see cref="RecipeFilters"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.FilterForAvailableIngredients == filters.OnlyAvailableIngredients<br/>
        /// &amp;&amp; this.SelectedTags contains all items in filters.MatchTags
        /// </summary>
        /// <param name="filters"></param>
        public void Initialize(RecipeFilters filters)
        {
            this.FilterForAvailableIngredients = filters.OnlyAvailableIngredients;
            this.tags = this.service.GetAllRecipeTypes();
            this.SelectedTags = filters.MatchTags?.ToList() ?? new List<string>();
            this.ApplySearchTermFilter();
        }

        /// <summary>
        /// Applies the current search term to the list of filtered tags.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>All items in this.FilteredTags contains this.SearchTerm
        /// </summary>
        public void ApplySearchTermFilter()
        {
            this.FilteredTags.Clear();
            var filteredTags = this.tags.Where(tag => 
                tag.Contains(this.searchTerm, StringComparison.InvariantCultureIgnoreCase));
            foreach (var tag in filteredTags)
            {
                this.FilteredTags.Add(tag);
            }
        }

        /// <summary>
        /// Adds the tag to the list of selected tags.<br/>
        /// <br/>
        /// <b>Precondition: </b>newTag != null<br/>
        /// <b>Postcondition: </b>this.SelectedTags.Contains(newTag)
        /// </summary>
        /// <param name="newTag">The tag to add</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddSelectedTag(string newTag)
        {
            if (newTag == null)
            {
                throw new ArgumentNullException(nameof(newTag));
            }

            if (this.selectedTags.Contains(newTag))
            {
                return;
            }
            this.selectedTags.Add(newTag);
        }

        /// <summary>
        /// Removes the tag from the list of selected tags.<br/>
        /// <br/>
        /// <b>Precondition: </b>tag != null<br/>
        /// <b>Postcondition: </b>!this.SelectedTags.Contains(tag)
        /// </summary>
        /// <param name="tag">The tag to remove</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveSelectedTag(string tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }
            this.selectedTags = this.selectedTags.Where(selectedTag => selectedTag != tag).ToList();
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
