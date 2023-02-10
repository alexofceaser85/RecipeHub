using System.Text.Json.Nodes;

namespace Shared_Resources.Utils.Json
{
    /// <summary>
    /// Holds the utils methods for json
    /// </summary>
    public class JsonUtils
    {
        private const int ServerErrorRequestCode = 500;
        private const string RequestMessageJsonElementName = "message";
        private const string RequestCodeJsonElementName = "code";

        /// <summary>
        /// Gets the json string from an element.
        /// </summary>
        /// <param name="parsedJson">The parsed json.</param>
        /// <param name="jsonElementName">Name of the json element.</param>
        /// <returns>The retrieved json string</returns>
        /// <exception cref="ArgumentException">The element name is not in the json string</exception>
        public static string GetJsonString(JsonNode parsedJson, string jsonElementName)
        {
            var requestContentNode = parsedJson[jsonElementName];

            if (requestContentNode == null)
            {
                //TODO ADD MESSAGE
                throw new ArgumentException();
            }

            return requestContentNode.ToString();
        }

        /// <summary>
        /// Gets the json string from a nested element.
        /// </summary>
        /// <param name="parsedJson">The parsed json.</param>
        /// <param name="firstJsonElementName">The name of the first json element.</param>
        /// <param name="secondJsonElementName">The name of the second json element.</param>
        /// <returns>The retrieved json string</returns>
        /// <exception cref="ArgumentException">The element names are not in the json string</exception>
        public static string GetJsonString(JsonNode parsedJson, string firstJsonElementName, string secondJsonElementName)
        {
            var requestContentNode = parsedJson[firstJsonElementName]?[secondJsonElementName];

            if (requestContentNode == null)
            {
                //TODO ADD MESSAGE
                throw new ArgumentException();
            }

            return requestContentNode.ToString();
        }

        /// <summary>
        /// Verifies the and get request information.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the request code indicates a server error</exception>
        public static string VerifyAndGetRequestInfo(JsonNode json)
        {
            var requestContent = JsonUtils.GetJsonString(json, RequestMessageJsonElementName);
            var requestCode = JsonUtils.GetJsonString(json, RequestCodeJsonElementName);

            if (int.Parse(requestCode) == ServerErrorRequestCode)
            {
                throw new ArgumentException(requestContent);
            }

            return requestContent;
        }
    }
}
