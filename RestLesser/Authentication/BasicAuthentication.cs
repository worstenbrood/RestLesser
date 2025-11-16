using System.Net.Http;

namespace RestLesser.Authentication
{
    /// <summary>
    /// Authenticate using basic authentication
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    public class BasicAuthentication(string username, string password) : IAuthentication
    {
        /// <inheritdoc/>
        public void SetAuthentication(HttpRequestMessage request)
        {
            request.SetBasic(username, password);
        }
    }
}
