using System.Text.Json.Nodes;
using Shared_Resources.Data.IO;
using Shared_Resources.Model.Users;

namespace Desktop_Client.Endpoints.Users
{
    public static class UsersEndpoints
    {
        public static string Login(string username, string password)
        {
            //Move to service
            var previousSessionKey = SessionKeySerializers.LoadSessionKey();

            var client = new HttpClient();
            HttpRequestMessage request = null;
            request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7265/LoginUser?username={username}&password={password}&previousSessionKey={previousSessionKey}");
            var response = client.SendAsync(request).Result;
            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            var requestContent = JsonObject.Parse(json)["content"].ToString();
            var requestCode = JsonObject.Parse(json)["code"].ToString();

            //TODO Extract this
            if (int.Parse(requestCode) == 500)
            {
                throw new ArgumentException(requestContent);
            }
            else
            {
                //TODO Should not set direct to session key
                return requestContent;
            }
        }

        public static void Logout(string sessionKey)
        {
            try
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7265/LogoutUser?sessionKey={sessionKey}");
                var response = client.SendAsync(request).Result;

                using var content = response.Content;
                var json = content.ReadAsStringAsync().Result;
                var requestContent = JsonObject.Parse(json)["content"].ToString();
                var requestCode = JsonObject.Parse(json)["code"].ToString();

                //TODO Extract this
                if (int.Parse(requestCode) == 500)
                {
                    throw new ArgumentException(requestContent);
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        public static UserInfo GetUserInfo(string sessionKey)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7265/GetUserInfo?sessionKey={sessionKey}");
            var response = client.SendAsync(request).Result;

            using var content = response.Content;
            var json = content.ReadAsStringAsync().Result;

            var userName = JsonObject.Parse(json)["userInfo"]["userName"].ToString();
            var firstName = JsonObject.Parse(json)["userInfo"]["firstName"].ToString();
            var lastName = JsonObject.Parse(json)["userInfo"]["lastName"].ToString();
            var email = JsonObject.Parse(json)["userInfo"]["email"].ToString();

            var requestMessage = JsonObject.Parse(json)["message"].ToString();
            var requestCode = JsonObject.Parse(json)["code"].ToString();

            //TODO Extract this
            if (int.Parse(requestCode) == 500)
            {
                throw new ArgumentException(requestMessage);
            }
            else
            {
                return new UserInfo(userName, firstName, lastName, email);
            }
        }
    }
}
