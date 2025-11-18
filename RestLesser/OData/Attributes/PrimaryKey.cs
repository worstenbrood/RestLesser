using System;
using System.Linq;
using System.Reflection;

namespace RestLesser.OData.Attributes
{
    /// <summary>
    /// Class that caches primary key per type
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class PrimaryKey<TClass>
    {
        /// <summary>
        /// <see cref="Type"/> of TCLass
        /// </summary>
        public static readonly Type Type = typeof(TClass);

        private static readonly Type _attributeKey = typeof(PrimaryKeyAttribute);
        private static readonly MemberInfo[] _members = Type.GetMembers(BindingFlags.Instance | BindingFlags.Public)
            .Where(m => Attribute.IsDefined(m, _attributeKey))
            .ToArray();

        /// <summary>
        /// First primary key
        /// </summary>
        public static MemberInfo[] Keys => _members;

        /// <summary>
        /// Get primary key value of a given object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetValue(TClass o)
        {
            var keys = Keys.Select(k => $"{k.Name}={k.GetValue(o).ToODataValue()}");
            return $"({string.Join(Constants.Query.ParameterSeparator, keys)})";
        }
    }
}
