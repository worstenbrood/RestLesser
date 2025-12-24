using System.Net;
using RestLesser.OData;
using RestLesser.Authentication;
using RestLesser.DataAdapters;
using RestLesser.Examples.ExactOnline.Models;

namespace RestLesser.Examples.ExactOnline
{
    public class ExactClient(IAuthentication authentication) : ODataClient(ApiUrl, authentication)
    {
        protected const string ApiUrl = "https://start.exactonline.be";
        protected const string ApiPath = "api/v1";

        // We need this in case we get an 500 response from the api
        protected static readonly IDataAdapter JsonAdapter = new JsonAdapter();
        
        /// <summary>
        /// Our accounting division, needs to be set before using GetDivPath
        /// </summary>
        public int? AccountingDivision;

        /// <summary>
        /// Returns ApiPath + "/" + path or ApiPath + "/" AccountingDivision + "/" + path
        /// </summary>
        /// <param name="path"></param>
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
                throw new HttpRequestException($"HTTP Status {response.StatusCode}: {errorResponse.Error.Code} / {errorResponse.Error.Message.Value}");
            }

            throw new HttpRequestException($"HTTP Status {response.StatusCode}: {body}");
        }
    }
} 
