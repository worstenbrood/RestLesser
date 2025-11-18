using System;

namespace RestLesser.OData.Attributes
{
    /// <summary>
    /// Attribute to specify primary key field/property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class PrimaryKeyAttribute : Attribute
    {
    }
}
