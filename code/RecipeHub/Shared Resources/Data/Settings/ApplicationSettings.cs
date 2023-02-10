namespace Shared_Resources.Data.Settings
{
    /// <summary>
    /// Holds the application settings
    /// </summary>
    public static class ServerSettings
    {
        /// <summary>
        /// The server URI
        /// </summary>
        public const string ServerUri = $"https://localhost:7265/";
    }

    /// <summary>
    /// The session key settings
    /// </summary>
    public static class SessionKeySettings
    {
        /// <summary>
        /// The session key characters
        /// </summary>
        public const string SessionKeyCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// The session key length
        /// </summary>
        public const int SessionKeyLength = 50;
    }
}
