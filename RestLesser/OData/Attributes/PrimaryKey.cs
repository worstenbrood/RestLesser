using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RestLesser.OData.Filter;

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
        private static PropertyInfo[] GetMemberInfo()
        {
            var members = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => Attribute.IsDefined(m, _attributeKey))
                .ToArray();
            if (members.Length == 0)
            {
                throw new ArgumentException($"No {_attributeKey.Name} attribute set in {Type.Name}");
            }
            return members;
        }

        private static readonly PropertyInfo[] _members = GetMemberInfo();

        /// <summary>
        /// First primary key
        /// </summary>
        public static PropertyInfo[] Keys => _members;

        /// <summary>
        /// Get primary key value of a given object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetValue(TClass o)
        {
            IEnumerable<string> keys;

            if (Keys.Length == 1)
            {
                keys = new[] { $"{Keys[0].GetValue(o).ToODataValue()}" };
            }
            else
            {
                keys = Keys.Select(k => $"{k.Name}={k.GetValue(o).ToODataValue()}");
            }

            var collector = new Collector<string>(keys);            
            return $"({collector})";
        }

        /// <summary>
        /// Set values of the primry keys
        /// </summary>
        /// <param name="o"></param>
        /// <param name="values"></param>
        public static void SetKeys(TClass o, params object[] values)
        {
            for (int i = 0; i < values.Length && i < Keys.Length; i++)
            {
                Keys[i].SetValue(o, values[i]);
            }
        }
    }
}
