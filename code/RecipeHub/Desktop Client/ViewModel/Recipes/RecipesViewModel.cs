using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes screen.
    /// </summary>
    public class RecipesViewModel
    {
        private readonly IRecipesService service;

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListViewModel"/>.<br/>
        /// Uses an instance of <see cref="RecipesService"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesViewModel() : this(new RecipesService())
        {

        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesService"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesViewModel(IRecipesService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service),
                               RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);
        }

        public Recipe LoadRecipe(string sessionKey, int recipeId)
        {
            return this.service.GetRecipe(sessionKey, recipeId);
        }
    }
}
