using RestLesser.OData.Interfaces;

namespace RestLesser.OData.Filter
{
    /// <summary>
    /// Condition base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="value"></param>
    public class ConditionBase<T>(string value) : ICondition
    {
        /// <summary>
        /// Value
        /// </summary>
        protected readonly string Value = value;

        /// <summary>
        /// Returns <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value; 
    }
}
