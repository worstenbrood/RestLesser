using RestLesser.Authentication;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestLesser.Examples.TeamCity
{
    /// <summary>
    /// 
    /// </summary>
    public class TeamCityAuthentication : IAuthentication
    {
        private readonly HttpClient _client;

        protected readonly IAuthentication? Authentication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        private TeamCityAuthentication(string url)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(url),
            };
        }

        /// <summary>
        /// Token auth
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        public TeamCityAuthentication(string url, string token) : this(url)
        {
            Authentication = new TokenAuthentication(token);
        }

        /// <summary>
        /// Token auth
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public TeamCityAuthentication(string url, string username, string password) : this(url)
        {
            Authentication = new BasicAuthentication(username, password);
        }

        private string GetToken()
        {
            const string path = "authenticationTest.html?csrf";
            using var request = new HttpRequestMessage(HttpMethod.Get, path);
            Authentication?.SetAuthentication(request);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            using HttpResponseMessage response = _client.SendAsync(request).Sync();
            return response.Content.ReadAsStringAsync().Sync();
        }

        public void SetAuthentication(HttpRequestMessage request)
        {
            // Set authentication
            Authentication?.SetAuthentication(request);

            // Set csrf token
            request.SetHeader("X-TC-CSRF-Token", GetToken());
        }
    }
}
