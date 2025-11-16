using System.Linq;
using RestLesser.OData.Interfaces;

namespace RestLesser.OData.Filter
{
    /// <summary>
    /// Class that joins multiple conditions
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="conditions"></param>
    public class ConditionJoiner(params ICondition[] conditions) : ConditionBase<string>(string.Join(Constants.Query.ConditionSeparator, 
            conditions.Select(c => c.ToString())))
    {
    }
}
