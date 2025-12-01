using Newtonsoft.Json;

namespace RestLesser.OData4
{
    /// <summary>
    /// 
    /// </summary>
    public class ODataObject4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("@odata.id")]
        public string ODataId { get; set; }
    }
}
