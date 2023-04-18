namespace Server.Data.Settings
{
    /// <summary>
    /// Holds the settings for the server
    /// </summary>
    public static class ServerSettings
    {
        /// <summary>
        /// The default successful connection message
        /// </summary>
        public static string DefaultSuccessfulConnectionMessage = "Returned Okay";
        /// <summary>
        /// The session time out length in minutes
        /// </summary>
        public static double SessionTimeOutLengthInMinutes = -86400000;
        /// <summary>
        /// The removed time out session keys thread interval
        /// </summary>
        public static int RemovedTimeOutSessionKeysThreadInterval = 3600000;
        /// <summary>
        /// The removed planned meals thread interval
        /// </summary>
        public static int RemovedPlannedMealsThreadInterval = 3600000;
    }

    /// <summary>
    /// Holds the settings for the database
    /// </summary>
    public static class DatabaseSettings
    {
        /// <summary>
        /// The connection string to the database
        /// </summary>
        public static string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RecipeHubDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}