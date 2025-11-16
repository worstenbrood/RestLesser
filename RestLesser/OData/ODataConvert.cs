using System;

namespace RestLesser.OData
{
    /// <summary>
    /// Conversion methods
    /// </summary>
    public static class ODataConvert
    {
        /// <summary>
        /// Converts a <paramref name="value"/> to it's OData representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToODataValue(this object value)
        {
            return value switch
            {
                // Guid
                Guid guid => $"guid'{guid:D}'",
                // DateTime
                DateTime date => $"datetime'{date:s}'",
                // long
                long l => $"{l}L",
                // string
                string s => $"'{s}'",
                // others
                _ => value.ToString(),
            };
        }
    }
}
