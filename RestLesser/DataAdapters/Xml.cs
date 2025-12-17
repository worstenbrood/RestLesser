using System.Xml.Serialization;

namespace RestLesser.DataAdapters
{
    /// <summary>
    /// Generic static <see cref="XmlSerializer"/> cache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Xml<T>
    {
        private static readonly XmlSerializer _xmlSerializer = new(typeof(T));

        /// <summary>
        /// Return static instance
        /// </summary>
        public static XmlSerializer Serializer => _xmlSerializer;
    }
}
