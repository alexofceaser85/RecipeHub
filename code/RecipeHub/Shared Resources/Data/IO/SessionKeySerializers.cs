using System.Text.Json;

namespace Shared_Resources.Data.IO
{
    /// <summary>
    /// Serializes the session key file
    /// </summary>
    public static class SessionKeySerializers
    {
        /// <summary>
        /// Saves the session key.
        /// </summary>
        public static void SaveSessionKey(string sessionKey, string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);

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
        public static string LoadSessionKey(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

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
