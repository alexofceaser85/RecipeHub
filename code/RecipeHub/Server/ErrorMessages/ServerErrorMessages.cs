namespace Server.ErrorMessages
{
    /// <summary>
    /// The error messages for the users service
    /// </summary>
    public static class ServerUsersServiceErrorMessages
    {
        /// <summary>
        /// The previous session key cannot be null error message
        /// </summary>
        public const string PreviousSessionKeyCannotBeNull = "The previous session key cannot be null";
        /// <summary>
        /// The previous session key cannot be empty error message
        /// </summary>
        public const string PreviousSessionKeyCannotBeEmpty = "The previous session key cannot be empty";
        /// <summary>
        /// The session key cannot be null error message
        /// </summary>
        public const string SessionKeyCannotBeNull = "The session key cannot be null";
        /// <summary>
        /// The session key cannot be empty error message
        /// </summary>
        public const string SessionKeyCannotBeEmpty = "The session key cannot be empty";
        /// <summary>
        /// The username and password combination is wrong error message
        /// </summary>
        public const string UsernameAndPasswordCombinationIsWrong = "The username and password combination is wrong";
        /// <summary>
        /// The data access layer cannot be null error message
        /// </summary>
        public const string DataAccessLayerCannotBeNull = "The data access layer cannot be null";
        /// <summary>
        /// The session key cannot be expired error message
        /// </summary>
        public const string SessionKeyCannotBeExpired = "Session Expired Returning to Login Screen";
    }

    /// <summary>
    /// The error messages for the recipes service
    /// </summary>
    public static class ServerRecipesServiceErrorMessages
    {
        /// <summary>
        /// The recipes data access layer cannot be null error message
        /// </summary>
        public const string RecipesDataAccessLayerCannotBeNull = "The recipes data access layer cannot be null";

        /// <summary>
        /// The users data access layer cannot be null error message
        /// </summary>
        public const string UsersDataAccessLayerCannotBeNull = "The users data access layer cannot be null";

        /// <summary>
        /// The search term cannot be null error message
        /// </summary>
        public const string SearchTermCannotBeNull = "The search term cannot be null";

        /// <summary>
        /// The recipe name cannot be null error message
        /// </summary>
        public const string RecipeNameCannotBeNull = "The recipe name cannot be null";

        /// <summary>
        /// The recipe name cannot be empty error message
        /// </summary>
        public const string RecipeNameCannotBeEmpty = "The recipe name cannot be empty";

        /// <summary>
        /// The recipe description cannot be null error message
        /// </summary>
        public const string RecipeDescriptionCannotBeNull = "The recipe description cannot be null";

        /// <summary>
        /// The recipe description cannot be empty error message
        /// </summary>
        public const string RecipeDescriptionCannotBeEmpty = "The recipe description cannot be empty";

        /// <summary>
        /// The user did not make the recipe error message
        /// </summary>
        public const string UserDidNotMakeRecipe = "The user did not make the recipe";

        /// <summary>
        /// The recipe description cannot be empty error message
        /// </summary>
        public const string AuthorIdDoesNotExist = "The recipe description cannot be empty";

        /// <summary>
        /// The session key cannot be null error message
        /// </summary>
        public const string SessionKeyCannotBeNull = "The session key cannot be null";

        /// <summary>
        /// The session key cannot be empty error message
        /// </summary>
        public const string SessionKeyCannotBeEmpty = "The session key cannot be empty";
        
        /// <summary>
        /// The session key is not valid error message
        /// </summary>
        public const string SessionKeyIsNotValid = "The session key is not valid";

        /// <summary>
        /// The recipe types dal cannot be null error message
        /// </summary>
        public const string RecipeTypesDalCannotBeNull = "The recipe types Dal cannot be null";

        /// <summary>
        /// The tags cannot be null error message
        /// </summary>
        public const string TagsCannotBeNull = "The tags cannot be null";

        /// <summary>
        /// The tags cannot be empty error message
        /// </summary>
        public const string TagsCannotBeEmpty = "The tags cannot be empty";
    }

    /// <summary>
    /// The error messages for the recipes controller
    /// </summary>
    public static class RecipesControllerErrorMessages
    {
        /// <summary>
        /// The recipes service cannot be null error message
        /// </summary>
        public const string RecipesServiceCannotBeNull = "The recipes service cannot be null";

        /// <summary>
        /// The recipe failed to add error message
        /// </summary>
        public const string RecipeFailedToAdd = "The recipe failed to be added";

        /// <summary>
        /// The recipe failed to remove error message
        /// </summary>
        public const string RecipeFailedToRemove = "The recipe failed to be removed";

        /// <summary>
        /// The recipe failed to edit error message
        /// </summary>
        public const string RecipeFailedToEdit = "The recipe failed to be edited";
    }

    /// <summary>
    /// The user info response model error message
    /// </summary>
    public static class ResponseModelErrorMessages
    {
        /// <summary>
        /// The message cannot be null error message
        /// </summary>
        public const string MessageCannotBeNull = "The message cannot be null";
        /// <summary>
        /// The message cannot be empty error message
        /// </summary>
        public const string MessageCannotBeEmpty = "The message cannot be empty";
    }

    /// <summary>
    /// The error messages for the users service
    /// </summary>
    public static class UsersServiceServerErrorMessages
    {
        /// <summary>
        /// The user name already exists error message
        /// </summary>
        public const string UserNameAlreadyExists = "The username already exists";
        /// <summary>
        /// The account to create cannot be null error message
        /// </summary>
        public const string AccountToCreateCannotBeNull = "The account to create cannot be null";
    }

    /// <summary>
    /// The error messages for the planned meals controller
    /// </summary>
    public static class PlannedMealsControllerErrorMessages
    {
        /// <summary>
        /// The planned meals service cannot be null error message
        /// </summary>
        public const string PlannedMealsServiceCannotBeNull = "The planned meals service cannot be null";
    }

    /// <summary>
    /// The error message for the planned meals service
    /// </summary>
    public static class PlannedMealsServiceErrorMessages
    {
        /// <summary>
        /// The planned meals dal cannot be null error message
        /// </summary>
        public static string PlannedMealsDalCannotBeNull = "The planned meals dal cannot be null";
        /// <summary>
        /// The users dal cannot be null error message
        /// </summary>
        public static string UsersDalCannotBeNull = "The user dal cannot be null";
        /// <summary>
        /// The recipes Dal cannot be null error message
        /// </summary>
        public static string RecipesDalCannotBeNull = "The recipes service cannot be null";
        /// <summary>
        /// The session key cannot be null error message
        /// </summary>
        public static string SessionKeyCannotBeNull = "The session key cannot be null";
        /// <summary>
        /// The session key cannot be empty error message
        /// </summary>
        public static string SessionKeyCannotBeEmpty = "The session key cannot be empty";
        /// <summary>
        /// The invalid session error message
        /// </summary>
        public static string InvalidSession = "The session is invalid";
        /// <summary>
        /// The recipe already in planned meal error message
        /// </summary>
        public static string RecipeAlreadyInPlannedMeal =
            "The recipe is already in the planned meal category, cannot add duplicate recipes";
    }
    /// <summary>
    /// The error messages for the shopping list controller
    /// </summary>
    public static class ShoppingListControllerErrorMessages
    {
        /// <summary>
        /// The shopping list service cannot be null error message
        /// </summary>
        public static string ShoppingListServiceCannotBeNull = "The shopping list service cannot be null";
    }

    /// <summary>
    /// The error messages for the shopping list service
    /// </summary>
    public static class ShoppingListServiceErrorMessages
    {
        /// <summary>
        /// The users dal cannot be null error message
        /// </summary>
        public static string UsersDalCannotBeNull = "The user dal cannot be null";
        /// <summary>
        /// The planned meals dal cannot be null error message
        /// </summary>
        public static string PlannedMealsDalCannotBeNull = "The planned meals dal cannot be null";
        /// <summary>
        /// The ingredients dal cannot be null error message
        /// </summary>
        public static string IngredientsDalCannotBeNull = "The ingredients dal cannot be null";
        /// <summary>
        /// The recipes dal cannot be null error message
        /// </summary>
        public static string RecipesDalCannotBeNull = "The recipes dal cannot be null";
        /// <summary>
        /// The session key cannot be null error message
        /// </summary>
        public static string SessionKeyCannotBeNull = "The session key cannot be null";
        /// <summary>
        /// The session key cannot be empty error message
        /// </summary>
        public static string SessionKeyCannotBeEmpty = "The session key cannot be empty";
        /// <summary>
        /// The invalid session key error message
        /// </summary>
        public static string InvalidSessionKeyErrorMessage = "The session is invalid";
    }
}
