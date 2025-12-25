using System.Net;
using RestLesser.OData;
using RestLesser.Authentication;
using RestLesser.DataAdapters;
using RestLesser.Examples.ExactOnline.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace RestLesser.Examples.ExactOnline
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="authentication"></param>
    public class ExactClient(IAuthentication authentication) : ODataClient(ApiUrl, authentication)
    {
        /// <summary>
        /// 
        /// </summary>
        protected const string ApiUrl = "https://start.exactonline.be";
        
        /// <summary>
        /// 
        /// </summary>
        protected const string ApiPath = "api/v1";

        /// <summary>
        ///  We need this in case we get an 500 response from the api
        /// </summary>
        protected static readonly IDataAdapter JsonAdapter = AdapterFactory.Get(Adapter.Json);
        
        /// <summary>
        /// Our accounting division, needs to be set before using GetDivPath
        /// </summary>
        public int? AccountingDivision;

        /// <summary>
        /// Returns ApiPath + "/" + path or ApiPath + "/" AccountingDivision + "/" + path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="api"></param>
        /// <returns></returns>
        protected string GetUrl(string path, bool api = false) => api ? $"/{ApiPath}/{path}" : $"/{ApiPath}/{AccountingDivision}/{path}";

        /// <summary>
        /// Override response handling so we can deserialize Exact specific error messages
        /// </summary>
        /// <param name="response">Http response</param>
        /// <returns>Body content</returns>
        /// <exception cref="HttpRequestException"></exception>
        protected override async Task<string> HandleResponse(HttpResponseMessage response)
        {
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return body;
            }

            // https://support.exactonline.com/community/s/knowledge-base#All-All-DNO-Content-respcodeserrorhandling
            if (response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = JsonAdapter.Deserialize<ErrorResponse>(body);
                throw new HttpRequestException($"HTTP Status {response.StatusCode}: {errorResponse?.Error?.Code} / {errorResponse?.Error?.Message?.Value}");
            }

            throw new HttpRequestException($"HTTP Status {response.StatusCode}: {body}");
        }
    }
} 
