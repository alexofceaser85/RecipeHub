using Microsoft.Data.SqlClient;
using System.Data;
using Shared_Resources.Model.Recipes;

namespace Server.DAL.Recipes
{
    /// <summary>
    /// Contains methods for querying the database for recipe information.
    /// </summary>
    public interface IRecipesDal
    {
        /// <summary>
        /// Checks whether a recipe with a specified ID exists.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe.</param>
        /// <returns>Whether or not a recipe with the recipe exists.</returns>
        public bool RecipeWithIdExists(int recipeId);

        /// <summary>
        /// Checks whether a specified user is the author of a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="authorId">The user's ID.</param>
        /// <param name="recipeId">The recipe's ID.</param>
        /// <returns>Whether or not the user is the author of the recipe.</returns>
        public bool IsAuthorOfRecipe(int authorId, int recipeId);

        /// <summary>
        /// Gets an array of all recipes in the database that are visible to the user.<br/>
        /// Only recipes that are public or are authored by the user will be retrieved.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="userId">The user's ID</param>
        /// <returns>An array containing all recipes visible to the user.</returns>
        public Recipe[] GetRecipes(int userId);

        /// <summary>
        /// Gets an array of all recipes in the database that are visible to the user and contain the specified string in the name.<br/>
        /// Only recipes that are public or are authored by the user will be retrieved.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="userId">The user's ID</param>
        /// <param name="nameFilter">The string to filter names for.</param>
        /// <returns>An array containing all recipes who's name contains the specified string and are visible to the user.</returns>
        public Recipe[] GetRecipesWithName(int userId, string nameFilter);

        /// <summary>
        /// Adds a recipe to the database.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="authorId">The ID of the recipe's author.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The recipe's description.</param>
        /// <param name="isPublic">Whether the recipe should be public or not.</param>
        /// <returns></returns>
        public bool AddRecipe(int authorId, string name, string description, bool isPublic);

        /// <summary>
        /// Removes a recipe using its recipe ID.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID of the recipe to remove.</param>
        /// <returns>Whether the recipe was successfully removed or not.</returns>
        public bool RemoveRecipe(int recipeId);

        /// <summary>
        /// Updates a recipe using the recipe's ID.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID of the recipe to update.</param>
        /// <param name="name">The updated recipe name</param>
        /// <param name="description">The updated recipe description.</param>
        /// <param name="isPublic">Whether the recipe should be public or not.</param>
        /// <returns>Whether the recipe was successfully updated or not.</returns>
        public bool EditRecipe(int recipeId, string name, string description, bool isPublic);

        /// <summary>
        /// Gets all of the ingredients for a recipe using the recipe's ID.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID of the recipe.</param>
        /// <returns>An array containing all of the ingredients.</returns>
        public Ingredient[] GetIngredientsForRecipe(int recipeId);

        /// <summary>
        /// Gets all of the steps for a recipe using the recipe's ID.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID of the recipe.</param>
        /// <returns>An array containing all of the steps.</returns>
        public RecipeStep[] GetStepsForRecipe(int recipeId);
    }
}
