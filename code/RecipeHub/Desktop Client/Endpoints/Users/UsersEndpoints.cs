using System.Text.Json.Nodes;
using Shared_Resources.Data.IO;
using Shared_Resources.Model.Users;

namespace Desktop_Client.Endpoints.Users
{
    /// <summary>
    /// The endpoints for the user methods
    /// </summary>
    public static class UsersEndpoints
    {
        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The content of the server response</returns>
        /// <exception cref="System.ArgumentException">If the server encounters an error</exception>
        public static string Login(string username, string password)
        {
            //TODO Move to service
            var previousSessionKey = SessionKeySerializers.LoadSessionKey();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7265/LoginUser?username={username}&password={password}&previousSessionKey={previousSessionKey}");
            var response = client.SendAsync(request).Result;
            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            var requestContent = JsonNode.Parse(json)["content"].ToString();
            var requestCode = JsonNode.Parse(json)["code"].ToString();

            if (int.Parse(requestCode) == 500)
            {
                throw new ArgumentException(requestContent);
            }

            return requestContent;
        }

        /// <summary>
        /// Logs the user with the specified session key out of the system.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <exception cref="System.ArgumentException">If the server encounters an error</exception>
        public static void Logout(string sessionKey)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7265/LogoutUser?sessionKey={sessionKey}");
            var response = client.SendAsync(request).Result;

            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            var requestContent = JsonNode.Parse(json)["content"].ToString();
            var requestCode = JsonNode.Parse(json)["code"].ToString();

            if (int.Parse(requestCode) == 500)
            {
                throw new ArgumentException(requestContent);
            }
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        /// <exception cref="System.ArgumentException">If the user encounters an error</exception>
        public static UserInfo GetUserInfo(string sessionKey)
        {
            using var client = new HttpClient();
            //TODO extract the local host part of the url
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7265/GetUserInfo?sessionKey={sessionKey}");
            var response = client.SendAsync(request).Result;

            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;

            var userName = JsonNode.Parse(json)["userInfo"]["userName"].ToString();
            var firstName = JsonNode.Parse(json)["userInfo"]["firstName"].ToString();
            var lastName = JsonNode.Parse(json)["userInfo"]["lastName"].ToString();
            var email = JsonNode.Parse(json)["userInfo"]["email"].ToString();
            var requestMessage = JsonNode.Parse(json)["message"].ToString();
            var requestCode = JsonNode.Parse(json)["code"].ToString();

            if (int.Parse(requestCode) == 500)
            {
                throw new ArgumentException(requestMessage);
            }

            return new UserInfo(userName, firstName, lastName, email);
        }
    }
}
