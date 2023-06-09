﻿using Desktop_Client.Endpoints.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace Desktop_Client.Service.RecipeTypes
{
    /// <summary>
    /// The service for the recipe types
    /// </summary>
    /// <seealso cref="Desktop_Client.Service.RecipeTypes.IRecipeTypesService" />
    public class RecipeTypesService : IRecipeTypesService
    {
        private readonly IRecipeTypesEndpoints endpoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        public RecipeTypesService()
        {
            this.endpoints = new RecipeTypesEndpoints();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesService"/> class.<br/>
        /// <br/>
        /// Precondition endpoints != null<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        public RecipeTypesService(IRecipeTypesEndpoints endpoints)
        {
            if (endpoints == null)
            {
                throw new ArgumentException(RecipeTypesErrorMessages.EndpointsCannotBeNull);
            }
            this.endpoints = endpoints;
        }
        
        /// <inheritdoc/>
        public string[] GetAllRecipeTypes()
        {
            return this.endpoints.GetAllRecipeTypes();
        }
    }
}
