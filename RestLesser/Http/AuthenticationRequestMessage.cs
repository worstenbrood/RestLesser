using System.Net.Http;
using RestLesser.Authentication;

namespace RestLesser.Http
{
    /// <summary>
    /// Authenticated request message
    /// </summary>
    public class AuthenticationRequestMessage : HttpRequestMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="method">Http method</param>
        /// <param name="url">Url</param>
        /// <param name="authentication">Authentication handler</param>
        public AuthenticationRequestMessage(HttpMethod method, string url, IAuthentication authentication = null) : base(method, url)
        {
            authentication?.SetAuthentication(this);
        }
    }
}
