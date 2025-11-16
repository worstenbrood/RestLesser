using System.Net.Http;

namespace RestLesser.Authentication
{
    /// <summary>
    /// Authentication using a Bearer token
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="token">Bearer token</param>
    public class TokenAuthentication(string token) : IAuthentication
    {
        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            request.SetToken(token);
        }
    }
}
