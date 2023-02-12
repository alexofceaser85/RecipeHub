using System.Text.Json.Nodes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace Shared_Resources.Utils.Server
{
    /// <summary>
    /// Holds utils methods for the server
    /// </summary>
    public static class ServerUtils
    {
        /// <summary>
        /// Requests json data from the server.
        ///
        /// Precondition:
        /// method != null
        /// AND requestUri != null
        /// AND requestUri IS NOT empty
        /// AND client 1= null
        /// Postcondition: None
        /// </summary>
        /// <param name="method">The http method to use.</param>
        /// <param name="requestUri">The request URI to use.</param>
        /// <param name="client">The request client</param>
        /// <returns>The json from the server</returns>
        /// <exception cref="ArgumentException">json from the server is null</exception>
        public static JsonNode RequestJson(HttpMethod method, string requestUri, HttpClient client)
        {
            if (method == null)
            {
                throw new ArgumentException(ServerUtilsErrorMessages.HttpMethodCannotBeNull); 
            }

            if (requestUri == null)
            {
                throw new ArgumentException(ServerUtilsErrorMessages.RequestUriCannotBeNull);
            }

            if (requestUri.Trim().Length == 0)
            {
                throw new ArgumentException(ServerUtilsErrorMessages.RequestUriCannotBeEmpty);
            }

            if (client == null)
            {
                throw new ArgumentException(ServerUtilsErrorMessages.HttpClientCannotBeNull);
            }

            var request = new HttpRequestMessage(method, requestUri);
            var response = client.SendAsync(request).Result;
            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            return JsonUtils.ParseToJsonNode(json);
        }
    }
}
