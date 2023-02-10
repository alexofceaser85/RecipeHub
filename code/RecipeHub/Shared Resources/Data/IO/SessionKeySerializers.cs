using System.Text.Json;

namespace Shared_Resources.Data.IO
{
    /// <summary>
    /// Serializes the session key file
    /// </summary>
    public static class SessionKeySerializers
    {
        private static readonly string SessionFilePath = string.Concat(AppContext.BaseDirectory.AsSpan(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal)), "..\\Shared Resources\\", "Session.txt");

        /// <summary>
        /// Saves the session key.
        /// </summary>
        public static void SaveSessionKey(string sessionKey)
        {
            var fileStream = new FileStream(SessionFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            try
            {
                JsonSerializer.Serialize(fileStream, sessionKey);
            }
            finally
            {
                fileStream.Close();
            }
        }

        /// <summary>
        /// Loads the session key.
        /// </summary>
        /// <returns>The loaded session key</returns>
        public static string LoadSessionKey()
        {
            var fileStream = new FileStream(SessionFilePath, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                return Convert.ToString(JsonSerializer.Deserialize(fileStream, typeof(string))) ?? "";
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
