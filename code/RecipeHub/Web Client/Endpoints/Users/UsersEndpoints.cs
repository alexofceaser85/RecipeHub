using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Web_Client.Data.UserData;

namespace Web_Client.Endpoints.Users
{
    public static class UsersEndpoints
    {
        public static string Login(string username, string password)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7265/LoginUser?username={username}&password={password}");
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
                Session.Key = requestContent;
                return requestContent;
            }
        }

        public static void Logout(string sessionKey)
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
    }
}
