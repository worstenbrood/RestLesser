using System.Text;
using System.Net.Http;
using RestLesser.DataAdapters;

namespace RestLesser.Http
{
    /// <summary>
    /// REST content formatter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestContent<T> : StringContent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">Content object</param>
        /// <param name="adapter">Data adapter</param>
        public RestContent(T content, IDataAdapter adapter) : 
            base(adapter.Serialize(content), adapter.Encoding)
        {
            Headers.ContentType = adapter.MediaTypeHeader;
        }
    }
}
