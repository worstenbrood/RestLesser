using Newtonsoft.Json;

namespace RestLesser.OData4.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Result4<T>
    {
        /// <summary>
        /// OData context
        /// </summary>
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

        /// <summary>
        /// value array
        /// </summary>
        [JsonProperty("value")]
        public T[] Value { get; set; }
    }
}
