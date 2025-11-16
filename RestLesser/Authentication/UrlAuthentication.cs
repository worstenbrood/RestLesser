using System.Net.Http;

namespace RestLesser.Authentication
{
    /// <summary>
    /// Authenticate with a custom url query parameter and value
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="key">Url query parameter</param>
    /// <param name="value">Value</param>
    public class UrlAuthentication(string key, string value) : IAuthentication
    {
        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            request.SetUrlAuthentication(key, value);
        }
    }
}
