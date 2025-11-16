using System.Net.Http;
using System.Net.Http.Headers;
using RestLess.Authentication;
using RestLess.OAuth.Models;
using RestLess.OAuth.Provider;

namespace RestLess.OAuth.Authentication
{
    /// <summary>
    /// IAuthentication implementation of an ITokenProvider for use with RestClient
    /// </summary>
    public class OAuthAuthentication : IAuthentication
    {
        private readonly ITokenProvider _provider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">TokenProvider</param>
        public OAuthAuthentication(ITokenProvider provider)
        {
            _provider = provider;
        }

        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            TokenResponse response = _provider.GetToken();
            request.SetToken(response.AccessToken);
        }
    }
}
