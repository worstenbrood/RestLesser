using RestLesser.Authentication;
using RestLesser.OData;
using System.Threading.Tasks;

namespace RestLesser.OData4
{
    /// <summary>
    /// OData4 
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="authentication"></param>
    public class ODataClient4(string baseUrl, IAuthentication authentication) : RestClient(baseUrl, authentication)
    {
        /// <summary>
        /// Generic method to fetch a collection of certain types and 
        /// be able to select which fields to select
        /// </summary>
        /// <typeparam name="TClass">Type to fetch</typeparam>
        /// <param name="builder">Url builder</param>
        /// <returns></returns>
        public async Task<TClass> GetEntryAsync<TClass>(ODataUrlBuilder<TClass> builder)
            where TClass : ODataObject4
        {
            return await GetAsync<TClass>(builder.ToString());
        }

        /// <summary>
        /// GetEntry sync
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public TClass GetEntry<TClass>(ODataUrlBuilder<TClass> builder)
            where TClass : ODataObject4
        {
            return Get<TClass>(builder.ToString());
        }
    }
}
