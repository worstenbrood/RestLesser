using RestLesser.Authentication;
using RestLesser.OData;
using RestLesser.OData4.Models;
using System.Threading.Tasks;

namespace RestLesser.OData4
{
    /// <summary>
    /// OData4 
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="authentication"></param>
    public class ODataClient4(string baseUrl, IAuthentication authentication) : ODataClient(baseUrl, authentication)
    {
        /// <inheritdoc/>
        public override TClass[] GetEntries<TClass>(ODataUrlBuilder<TClass> builder)
        {
            var result = Get<Result4<TClass>>(builder.ToString());
            return result.Value;
        }

        /// <inheritdoc/>
        public override async Task<TClass[]> GetEntriesAsync<TClass>(ODataUrlBuilder<TClass> builder)
        {
            var result = await GetAsync<Result4<TClass>>(builder.ToString());
            return result.Value;
        }
    }
}
