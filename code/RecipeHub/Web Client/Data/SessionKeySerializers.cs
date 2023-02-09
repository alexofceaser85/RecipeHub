using System.Text.Json;
using Web_Client.Data.UserData;

namespace Web_Client.Data
{
    /// <summary>
    /// Serializes the session key file
    /// </summary>
    public static class SessionKeySerializers
    {
        /// <summary>
        /// Saves the session key.
        /// </summary>
        public static void SaveSessionKey()
        {
            var fileStream = new FileStream("Session.txt", FileMode.OpenOrCreate, FileAccess.Write);

            try
            {
                JsonSerializer.Serialize(fileStream, Session.Key);
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
            var fileStream = new FileStream("Session.txt", FileMode.OpenOrCreate, FileAccess.Read);

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
