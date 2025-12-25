using System.Net.Http.Headers;
using System.Text;

namespace RestLesser.DataAdapters
{
    /// <summary>
    /// Data adapter interface
    /// </summary>
    public interface IDataAdapter
    {
        /// <summary>
        /// Media type header to sent
        /// </summary>
        MediaTypeWithQualityHeaderValue MediaTypeHeader { get; }

        /// <summary>
        /// Encoding
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// Serialize an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        string Serialize<T>(T data);

        /// <summary>
        /// Deserialize an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        T Deserialize<T>(string data);
    }
}
