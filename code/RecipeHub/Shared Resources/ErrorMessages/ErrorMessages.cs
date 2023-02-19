using Shared_Resources.Data.Settings;

namespace Shared_Resources.ErrorMessages
{
    /// <summary>
    /// The error messages for the user info
    /// </summary>
    public static class UserInfoErrorMessages
    {
        /// <summary>
        /// The username cannot be null error message
        /// </summary>
        public const string UsernameCannotBeNull = "The user name cannot be null";
        /// <summary>
        /// The username cannot be empty error message
        /// </summary>
        public const string UsernameCannotBeEmpty = "The user name cannot be empty";
        /// <summary>
        /// The first name cannot be null error message
        /// </summary>
        public const string FirstNameCannotBeNull = "The first name cannot be null";
        /// <summary>
        /// The first name cannot be empty error message
        /// </summary>
        public const string FirstNameCannotBeEmpty = "The first name cannot be empty";
        /// <summary>
        /// The last name cannot be null error message
        /// </summary>
        public const string LastNameCannotBeNull = "The last name cannot be null";
        /// <summary>
        /// The last name cannot be empty error message
        /// </summary>
        public const string LastNameCannotBeEmpty = "The last name cannot be empty";
        /// <summary>
        /// The email cannot be null error message
        /// </summary>
        public const string EmailCannotBeNull = "The email cannot be null";
        /// <summary>
        /// The email cannot be empty error message
        /// </summary>
        public const string EmailCannotBeEmpty = "The email cannot be empty";
    }

    /// <summary>
    /// The error messages for the Recipes class
    /// </summary>
    public static class RecipesErrorMessages
    {
        /// <summary>
        /// The author name cannot be null error message.
        /// </summary>
        public const string AuthorNameCannotBeNull = "The author name cannot be null";

        /// <summary>
        /// The recipe name cannot be null error message.
        /// </summary>
        public const string RecipeNameCannotBeNull = "The recipe name cannot be null";

        /// <summary>
        /// The recipe description cannot be null error message.
        /// </summary>
        public const string RecipeDescriptionCannotBeNull = "The recipe description cannot be null";
    }
    /// <summary>
    /// The error messages for the new accounts
    /// </summary>
    public static class NewAccountErrorMessages
    {
        /// <summary>
        /// The username cannot be null error messages
        /// </summary>
        public static string UsernameCannotBeNull = "The username cannot be null";
        /// <summary>
        /// The username cannot be empty error messages
        /// </summary>
        public static string UsernameCannotBeEmpty = "The username cannot be empty";
        /// <summary>
        /// The password cannot be null error messages
        /// </summary>
        public static string PasswordCannotBeNull = "The password cannot be null";
        /// <summary>
        /// The password cannot be empty error messages
        /// </summary>
        public static string PasswordCannotBeEmpty = "The password cannot be empty";
        /// <summary>
        /// The verified password cannot be null error messages
        /// </summary>
        public static string VerifiedPasswordCannotBeNull = "The verified password cannot be null";
        /// <summary>
        /// The verified password cannot be empty error messages
        /// </summary>
        public static string VerifiedPasswordCannotBeEmpty = "The verified password cannot be empty";
        /// <summary>
        /// The verified password must match password error messages
        /// </summary>
        public static string VerifiedPasswordMustMatchPassword =
            "The verified password must match the inputted password";
        /// <summary>
        /// The first name cannot be null error messages
        /// </summary>
        public static string FirstNameCannotBeNull = "The first name cannot be null";
        /// <summary>
        /// The first name cannot be empty error messages
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The first name cannot be empty";
        /// <summary>
        /// The last name cannot be null error messages
        /// </summary>
        public static string LastNameCannotBeNull = "The last name cannot be null";
        /// <summary>
        /// The last name cannot be empty error messages
        /// </summary>
        public static string LastNameCannotBeEmpty = "The last name cannot be empty";
        /// <summary>
        /// The email cannot be null error messages
        /// </summary>
        public static string EmailCannotBeNull = "The email cannot be null";
        /// <summary>
        /// The email cannot be empty error messages
        /// </summary>
        public static string EmailCannotBeEmpty = "The email cannot be empty";
        /// <summary>
        /// The email is in wrong format error message
        /// </summary>
        public static string EmailIsInWrongFormat = "The email is in the wrong format";
    }

    /// <summary>
    /// The password validation error messages
    /// </summary>
    public static class PasswordValidationErrorMessages
    {
        /// <summary>
        /// The password is too short error messages
        /// </summary>
        public static string PasswordIsTooShort =
            $"The password is too short it must be at least {PasswordSettings.MinimumPasswordLength} characters long";
        /// <summary>
        /// The password is too long error messages
        /// </summary>
        public static string PasswordIsTooLong =
            $"The password is too short it must be at most {PasswordSettings.MaximumPasswordLength} characters long";
    }

    /// <summary>
    /// The error messages for the server utils
    /// </summary>
    public static class ServerUtilsErrorMessages
    {
        /// <summary>
        /// The HTTP method cannot be null error message
        /// </summary>
        public const string HttpMethodCannotBeNull = "Http method cannot be null";
        /// <summary>
        /// The request URI cannot be null error message
        /// </summary>
        public const string RequestUriCannotBeNull = "Request Uri cannot be null";
        /// <summary>
        /// The request URI cannot be empty error message
        /// </summary>
        public const string RequestUriCannotBeEmpty = "The request Uri cannot be empty";
        /// <summary>
        /// The HTTP client cannot be null error message
        /// </summary>
        public const string HttpClientCannotBeNull = "The http client cannot be null";
    }

    /// <summary>
    /// The error messages for the json utils
    /// </summary>
    public static class JsonUtilsErrorMessages
    {
        /// <summary>
        /// The json element name cannot be null error message
        /// </summary>
        public const string JsonElementNameCannotBeNull = "The json element name cannot be null";
        /// <summary>
        /// The json element name cannot be empty error message
        /// </summary>
        public const string JsonElementNameCannotBeEmpty = "The json element name cannot be empty";
        /// <summary>
        /// The json element name cannot be null error message
        /// </summary>
        public const string JsonNestedElementNameCannotBeNull = "The nested json element name cannot be null";
        /// <summary>
        /// The json element name cannot be empty error message
        /// </summary>
        public const string JsonNestedElementNameCannotBeEmpty = "The nested json element name cannot be empty";
        /// <summary>
        /// The request content node cannot be null error message
        /// </summary>
        public const string RequestContentNodeCannotBeNull = "The json content node cannot be null";
        /// <summary>
        /// The parsed json cannot be null error message
        /// </summary>
        public const string ParsedJsonCannotBeNull = "The parsed json cannot be null";
        /// <summary>
        /// The json to parse cannot be null error message
        /// </summary>
        public const string JsonToParseCannotBeNull = "The json to parse cannot be null";
        /// <summary>
        /// The json to parse cannot be empty error message
        /// </summary>
        public const string JsonToParseCannotBeEmpty = "The json to parse cannot be empty";
    }
    
    /// <summary>
    /// The error messages for the hashes
    /// </summary>
    public static class HashesErrorMessages
    {
        /// <summary>
        /// The password to hash cannot be null error message
        /// </summary>
        public const string PasswordToHashCannotBeNull = "The password to hash cannot be null";
        /// <summary>
        /// The password to hash cannot be empty error message
        /// </summary>
        public const string PasswordToHashCannotBeEmpty = "The password to hash cannot be empty";
    }

    /// <summary>
    /// The error messages for the users controller
    /// </summary>
    public class UsersControllerErrorMessages
    {
        /// <summary>
        /// The users service cannot be null error messages
        /// </summary>
        public static string UsersServiceCannotBeNull = "The users service cannot be null";
    }

    /// <summary>
    /// The users service error messages
    /// </summary>
    public class UsersServiceErrorMessages
    {
        /// <summary>
        /// The users endpoints cannot be null error messages
        /// </summary>
        public static string UsersEndpointsCannotBeNull = "The user endpoints cannot be null";
        /// <summary>
        /// The user name cannot be null error messages
        /// </summary>
        public static string UsernameCannotBeNull = "The user name cannot be null";
        /// <summary>
        /// The user name cannot be empty error messages
        /// </summary>
        public static string UsernameCannotBeEmpty = "The user name cannot be empty";
        /// <summary>
        /// The password cannot be null error messages
        /// </summary>
        public static string PasswordCannotBeNull = "The password cannot be null";
        /// <summary>
        /// The password cannot be empty error messages
        /// </summary>
        public static string PasswordCannotBeEmpty = "The password cannot be empty";
        /// <summary>
        /// The session key load file cannot be null error messages
        /// </summary>
        public static string SessionKeyLoadFileCannotBeNull = "The session key load file cannot be null";
        /// <summary>
        /// The session key load file cannot be empty error messages
        /// </summary>
        public static string SessionKeyLoadFileCannotBeEmpty = "The session key load file cannot be empty";
        /// <summary>
        /// The account to create cannot be null error message
        /// </summary>
        public const string AccountToCreateCannotBeNull = "The account to create cannot be null";
        /// <summary>
        /// The unauthorized access error message
        /// </summary>
        public const string UnauthorizedAccessErrorMessage = "The session timed out redirecting to login";
    }

    /// <summary>
    /// The users service error messages
    /// </summary>
    public class RecipesServiceErrorMessages
    {
        /// <summary>
        /// The recipes endpoints cannot be null error message
        /// </summary>
        public static string RecipesEndpointsCannotBeNull = "The recipes endpoints cannot be null";

        /// <summary>
        /// The user service cannot be null
        /// </summary>
        public static string UserServiceCannotBeNull = "The user service cannot be null";

        /// <summary>
        /// The search term cannot be null error message
        /// </summary>
        public static string SearchTermCannotBeNull = "The search term cannot be null";
        
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
    }

    /// <summary>
    /// The error messages for the user service view model
    /// </summary>
    public class UsersServiceViewModelErrorMessages
    {
        /// <summary>
        /// The users service cannot be null error messages
        /// </summary>
        public static string UsersServiceCannotBeNull = "The users service cannot be null";
    }

    /// <summary>
    /// The error messages for the user service view model
    /// </summary>
    public class RecipesViewModelErrorMessages
    {
        /// <summary>
        /// The recipes service cannot be null error messages
        /// </summary>
        public static string RecipesServiceCannotBeNull = "The recipes service cannot be null";
        
        /// <summary>
        /// The ingredients service cannot be null error messages
        /// </summary>
        public static string IngredientsServiceCannotBeNull = "The ingredients service cannot be null";
    }

    /// <summary>
    /// The error messages for the session key
    /// </summary>
    public static class SessionKeyErrorMessages
    {
        /// <summary>
        /// The session key cannot be null error messages
        /// </summary>
        public const string SessionKeyCannotBeNull = "The session key cannot be null";
        /// <summary>
        /// The session key cannot be empty error messages
        /// </summary>
        public const string SessionKeyCannotBeEmpty = "The session key cannot be empty";
    }

    /// <summary>
    /// The error messages for the users endpoints
    /// </summary>
    public static class UsersEndpointsErrorMessages
    {
        /// <summary>
        /// The client cannot be null error message
        /// </summary>
        public static string ClientCannotBeNull = "The client cannot be null";
    }
    
    /// <summary>
    /// The error messages for the users endpoints
    /// </summary>
    public static class RecipesEndpointsErrorMessages
    {
        /// <summary>
        /// The client cannot be null error message
        /// </summary>
        public const string ClientCannotBeNull = "The client cannot be null";
    }
}
