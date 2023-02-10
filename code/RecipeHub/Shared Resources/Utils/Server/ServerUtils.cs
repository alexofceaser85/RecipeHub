using System.Text.Json.Nodes;

namespace Shared_Resources.Utils.Server
{
    /// <summary>
    /// Holds utils methods for the server
    /// </summary>
    public static class ServerUtils
    {
        /// <summary>
        /// Requests json data from the server.
        /// </summary>
        /// <param name="method">The http method to use.</param>
        /// <param name="requestUri">The request URI to use.</param>
        /// <returns>The json from the server</returns>
        /// <exception cref="ArgumentException">json from the server is null</exception>
        public static JsonNode RequestJson(HttpMethod method, string requestUri)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(method, requestUri);
            var response = client.SendAsync(request).Result;
            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            var parsedJson = JsonNode.Parse(json);

            if (parsedJson == null)
            {
                //TODO EXTRACT MESSAGE
                throw new ArgumentException("json is null");
            }

            return parsedJson;
        }
    }
}
