namespace Server.Data.Database
{
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
