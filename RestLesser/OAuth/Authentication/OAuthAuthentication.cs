using System.Net.Http;
using RestLesser.Authentication;
using RestLesser.OAuth.Models;
using RestLesser.OAuth.Provider;

namespace RestLesser.OAuth.Authentication
{
    /// <summary>
    /// IAuthentication implementation of an ITokenProvider for use with RestClient
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="provider">TokenProvider</param>
    public class OAuthAuthentication(ITokenProvider provider) : IAuthentication
    {
        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            TokenResponse response = provider.GetToken();
            request.SetToken(response.AccessToken);
        }
    }
}
