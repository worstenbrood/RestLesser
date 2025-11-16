using System.Net.Http;

namespace RestLesser.Authentication
{
    /// <summary>
    /// Authenticate using custom http header/value.
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="header">Header</param>
    /// <param name="value">Value (token)</param>
    public class HeaderAuthentication(string header, string value) : IAuthentication
    {
        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            request.SetHeader(header, value);
        }
    }
}
