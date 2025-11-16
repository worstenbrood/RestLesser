using System.Linq;
using RestLesser.OData.Interfaces;

namespace RestLesser.OData.Filter
{
    /// <summary>
    /// Class that joins multiple conditions
    /// </summary>
    public class ConditionJoiner : ConditionBase<string>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="conditions"></param>
        public ConditionJoiner(params ICondition[] conditions) : base(string.Join(Constants.Query.ConditionSeparator, 
            conditions.Select(c => c.ToString())))
        {
        }
    }
}
