using System.Text.Json.Nodes;
using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Utils.Json
{
    /// <summary>
    /// Holds the utils methods for json
    /// </summary>
    public class JsonUtils
    {
        private const int ServerErrorRequestCode = 500;
        private const int ServerAuthenticationNotValidErrorCode = 401;

        private const string RequestMessageJsonElementName = "message";
        private const string RequestCodeJsonElementName = "code";

        /// <summary>
        /// Gets the json string from an element.
        ///
        /// Precondition:
        /// parsedJson != null
        /// AND jsonElementName != null
        /// AND jsonElementName IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="parsedJson">The parsed json.</param>
        /// <param name="jsonElementName">Name of the json element.</param>
        /// <returns>The retrieved json string</returns>
        /// <exception cref="ArgumentException">The element name is not in the json string</exception>
        public static string GetJsonString(JsonNode parsedJson, string jsonElementName)
        {
            if (parsedJson == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.ParsedJsonCannotBeNull);
            }

            if (jsonElementName == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonElementNameCannotBeNull);
            }

            if (jsonElementName.Trim().Length == 0)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty);
            }

            var requestContentNode = parsedJson[jsonElementName];
            return verifyAndGetNode(requestContentNode);
        }

        private static string verifyAndGetNode(JsonNode? jsonNode)
        {
            if (jsonNode == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.RequestContentNodeCannotBeNull);
            }

            return jsonNode.ToString();
        }

        /// <summary>
        /// Gets the json string from a nested element.
        ///
        /// Precondition:
        /// parsedJson != null
        /// AND firstJsonElementName != null
        /// AND firstJsonElementName IS NOT empty
        /// AND secondJsonElementName != null
        /// AND secondJsonElementName IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="parsedJson">The parsed json.</param>
        /// <param name="firstJsonElementName">The name of the first json element.</param>
        /// <param name="secondJsonElementName">The name of the second json element.</param>
        /// <returns>The retrieved json string</returns>
        /// <exception cref="ArgumentException">The element names are not in the json string</exception>
        public static string GetJsonString(JsonNode parsedJson, string firstJsonElementName, string secondJsonElementName)
        {
            if (parsedJson == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.ParsedJsonCannotBeNull);
            }

            if (firstJsonElementName == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonElementNameCannotBeNull);
            }

            if (firstJsonElementName.Trim().Length == 0)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty);
            }

            if (secondJsonElementName == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeNull);
            }

            if (secondJsonElementName.Trim().Length == 0)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeEmpty);
            }

            var requestContentNode = parsedJson[firstJsonElementName]?[secondJsonElementName];
            return verifyAndGetNode(requestContentNode);
        }

        /// <summary>
        /// Verifies the and gets the request information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>The request information</returns>
        /// <exception cref="ArgumentException">If the request code indicates a server error</exception>
        public static string VerifyAndGetRequestInfo(JsonNode json)
        {
            var requestContent = GetJsonString(json, RequestMessageJsonElementName);
            var requestCode = GetJsonString(json, RequestCodeJsonElementName);

            if (int.Parse(requestCode) == ServerErrorRequestCode)
            {
                throw new ArgumentException(requestContent);
            }
            if (int.Parse(requestCode) == ServerAuthenticationNotValidErrorCode)
            {
                throw new UnauthorizedAccessException(UsersServiceErrorMessages.UnauthorizedAccessErrorMessage);
            }

            return requestContent;
        }

        /// <summary>
        /// Parses to json node.
        ///
        /// Precondition: json != null AND json IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>The parsed json node</returns>
        /// <exception cref="ArgumentException">If the preconditions are not met or if the json node cannot be parsed</exception>
        public static JsonNode ParseToJsonNode(string json)
        {
            if (json == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonToParseCannotBeNull);
            }

            if (json.Trim().Length == 0)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.JsonToParseCannotBeEmpty);
            }

            var parsedJson = JsonNode.Parse(json);

            if (parsedJson == null)
            {
                throw new ArgumentException(JsonUtilsErrorMessages.ParsedJsonCannotBeNull);
            }

            return parsedJson;
        }
    }
}
