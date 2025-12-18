using System.Diagnostics;
using System.Net.Http.Headers;

namespace RestLesser.DataAdapters
{
    /// <summary>
    /// Adapter that outputs the data to debug console
    /// </summary>
    public class DebugAdapter(IDataAdapter dataAdapter) : IDataAdapter
    {
        /// <inheritdoc/>
        public MediaTypeWithQualityHeaderValue MediaTypeHeader => 
            dataAdapter.MediaTypeHeader;

        /// <inheritdoc/>
        public T Deserialize<T>(string data)
        {
            Debug.WriteLine($"Response: {data}");
            return dataAdapter.Deserialize<T>(data);
        }

        /// <inheritdoc/>
        public string Serialize<T>(T data)
        {
            var result = dataAdapter.Serialize(data);
            Debug.WriteLine($"Request: {result}");
            return result;
        }
    }
}
