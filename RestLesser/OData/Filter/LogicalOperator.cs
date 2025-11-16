namespace RestLesser.OData.Filter
{
    /// <summary>
    /// Logical operator
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="op"></param>
    public class LogicalOperator(Operator op) : ConditionBase<Operator>(op.Lower())
    {
    }
}
