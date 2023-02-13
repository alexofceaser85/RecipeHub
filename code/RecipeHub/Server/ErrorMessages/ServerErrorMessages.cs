namespace Server.ErrorMessages
{
    /// <summary>
    /// The error messages for the users service
    /// </summary>
    public static class ServerUsersServiceErrorMessages
    {
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
}
