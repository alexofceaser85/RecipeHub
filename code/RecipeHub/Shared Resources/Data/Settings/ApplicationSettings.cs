﻿namespace Shared_Resources.Data.Settings
{
    /// <summary>
    /// Holds the application settings
    /// </summary>
    public static class ServerSettings
    {
        /// <summary>
        /// The server URI
        /// </summary>
        public const string ServerUri = "https://localhost:7265/";
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

        /// <summary>
        /// The save session file path
        /// </summary>
        public static readonly string SaveSessionFilePath = string.Concat(AppContext.BaseDirectory.AsSpan(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal)), "..\\Shared Resources\\", "Session.txt");
    }

    /// <summary>
    /// The new account settings
    /// </summary>
    public static class NewAccountSettings
    {
        /// <summary>
        /// The minimum password length
        /// </summary>
        public static int MinimumPasswordLength = 6;
        /// <summary>
        /// The maximum password length
        /// </summary>
        public static int MaximumPasswordLength = 25;
        /// <summary>
        /// The email format
        /// </summary>
        public static string EmailFormat = "^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})";
    }
}
