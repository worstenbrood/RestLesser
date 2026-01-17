using System;

namespace RestLesser.DataAdapters
{
    /// <summary>
    /// Data adapter factory
    /// </summary>
    public static class AdapterFactory<T>
    {
        private static readonly IDataAdapter PrimitiveAdapter =
#if DEBUG
            new DebugAdapter(AdapterFactory.Get(Adapter.Primitives));
#else
        AdapterFactory.Get(Adapter.Primitives);
#endif
        /// <summary>
        /// Type of T
        /// </summary>
        public static readonly TypeCode TypeCode = Type.GetTypeCode(typeof(T));

        /// <summary>
        /// Return correct adapter based on type
        /// </summary>
        /// <param name="supplied"></param>
        /// <returns></returns>
        public static IDataAdapter Get(IDataAdapter supplied) =>
            TypeCode != TypeCode.Object ?
                // Use the primitive adapter
                PrimitiveAdapter :
                // Use the supplied adapter
                supplied;
    }

    /// <summary>
    /// Common data adapters
    /// </summary>
    public enum Adapter
    {
        /// <summary>
        /// Json
        /// </summary>
        Json,
        /// <summary>
        /// Json, but using ScnakeCase naming strategy
        /// </summary>
        SnakeCaseJson,
        /// <summary>
        /// Xml
        /// </summary>
        Xml,
        /// <summary>
        /// Primitibe types, <see cref="TypeCode"/>
        /// </summary>
        Primitives,

        /// <summary>
        /// Default adaptter
        /// </summary>
        Default = Json,
    }

    /// <summary>
    /// <see cref="IDataAdapter"/> factory
    /// </summary>
    public static class AdapterFactory
    {
        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static IDataAdapter Get(Adapter adapter) =>
            adapter switch
            {
                Adapter.Json => new JsonAdapter(),
                Adapter.SnakeCaseJson => new SnakeCaseJsonAdapter(),
                Adapter.Xml => new XmlAdapter(),
                Adapter.Primitives => new PrimitiveAdapter(),
                _ => throw new NotSupportedException(),
            };
    }
}