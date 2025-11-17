using System.IO;
using System.Text;
using RestLesser.DataAdapters;

namespace RestLesser.OAuth.Storage
{
    /// <summary>
    /// Token storage provider that loads and saves to local disk
    /// </summary>
    public class LocalStorage : ITokenStorage
    {
        /// <summary>
        /// Json adapter
        /// </summary>
        public static readonly JsonAdapter Adapter = new ();

        static LocalStorage()
        {
            Adapter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        }

        /// <inheritdoc/>
        public TokenData Load(string filename) => Adapter.Deserialize<TokenData>(File.ReadAllText(filename, Encoding.UTF8));
        
        /// <inheritdoc/>
        public void Save(string filename, TokenData token) => File.WriteAllText(filename, Adapter.Serialize(token), Encoding.UTF8);
    }
}
