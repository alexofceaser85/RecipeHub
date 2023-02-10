﻿using Shared_Resources.Data.Settings;
using Shared_Resources.Model.Users;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.Users
{
    /// <summary>
    /// The endpoints for the user methods
    /// </summary>
    public static class UsersEndpoints
    {
        private const string LoginUserServerMethodName = "LoginUser";
        private const string LogoutUserServerMethodName = "LogoutUser";
        private const string GetUserServerMethodName = "GetUserInfo";

        private const string UserInfoJsonElementName = "userInfo";
        private const string UserNameJsonElementName = "userName";
        private const string FirstNameJsonElementName = "firstName";
        private const string LastNameJsonElementName = "lastName";
        private const string EmailJsonElementName = "email";

        /// <summary>
        /// Logins the specified username and password combination.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key</param>
        /// <returns>The session key for the user</returns>
        /// <exception cref="System.ArgumentException">If there was an error with the server</exception>
        public static string Login(string username, string password, string previousSessionKey)
        {
            var serverMethodParameters =
                $"?username={username}&password={password}&previousSessionKey={previousSessionKey}";
            var requestUri = $"{ServerSettings.ServerUri}{LoginUserServerMethodName}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri);
            var requestContent = JsonUtils.VerifyAndGetRequestInfo(json);
            return requestContent;
        }

        /// <summary>
        /// Logs the user with the specified session key out of the system.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <exception cref="System.ArgumentException">If there was an error with the server</exception>
        public static void Logout(string sessionKey)
        {
            var serverMethodParameters = $"?sessionKey={sessionKey}";
            var requestUri = $"{ServerSettings.ServerUri}{LogoutUserServerMethodName}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        /// <exception cref="System.ArgumentException">If there is an error with the server</exception>
        public static UserInfo GetUserInfo(string sessionKey)
        {
            var serverMethodParameters = $"?sessionKey={sessionKey}";
            var requestUri = $"{ServerSettings.ServerUri}{GetUserServerMethodName}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var userName = JsonUtils.GetJsonString(json, UserInfoJsonElementName, UserNameJsonElementName);
            var firstName = JsonUtils.GetJsonString(json, UserInfoJsonElementName, FirstNameJsonElementName);
            var lastName = JsonUtils.GetJsonString(json, UserInfoJsonElementName, LastNameJsonElementName);
            var email = JsonUtils.GetJsonString(json, UserInfoJsonElementName, EmailJsonElementName);

            return new UserInfo(userName, firstName, lastName, email);
        }
    }
}
