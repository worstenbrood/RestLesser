using Restlesser.Builder.Models;
using System;
using System.Text;

namespace Restlesser.Builder
{
    internal class ClassGenerator(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer) : GeneratorBase(fullName, schemas, serializer)
    {
        /// <summary>
        /// Class access modifier, default is public
        /// </summary>
        public string ClassAccessModifier = "public";

        /// <summary>
        /// Specifies the access modifier for a property.
        /// </summary>
        public string PropertyAccessModifier = "public";

        /// <summary>
        /// Used for properties
        /// </summary>
        public string PropertySuffix = "{ get; set; }";

        /// <summary>
        /// Makes all properties nullable, default is false. This is useful when the OpenAPI spec does not specify required properties, or when you want to allow null values for all properties. Note that this will 
        /// make value types (like int, bool) nullable (int?, bool?) and reference types (like string) will be nullable with a '?' suffix (string?).
        /// </summary>
        public bool NullableProperties { get; set; } = false;

        /// <summary>
        /// Default type for properties with no type specified, default is object.
        /// </summary>
        public string DefaultPropertyType { get; set; } = "object";

        /// <summary>
        /// String format for array types, default is List<{0}>. The {0} will be replaced with the type of the array items. 
        /// For example, if the array items are of type string, the resulting type will be List<string>.
        /// </summary>
        public string ArrayTypeFormat { get; set; } = "List<{0}>";

        private string HandleObject(OpenApiObject? schema, bool nullable = true)
        {
            if (schema?.Items != null)
            {
                return $"{HandleType(schema.Items, nullable)}";
            }
            else if (schema?.Reference != null)
            {
                return $"{HandleClassReference(schema.Reference)}";
            }
            return HandleType(schema, nullable);
        }

        private string HandleArray(OpenApiObject? schema) => string.Format(ArrayTypeFormat, HandleObject(schema, false));

        private string HandleEnum(OpenApiObject? schema)
        {
            if (schema?.Reference != null)
            {
                return $"{HandleEnumReference(schema.Reference)}";
            }

            return "Enum";
        }

        private string HandleType(OpenApiObject? apiObject, bool nullable = true)
        {
            if (apiObject == null)
                return string.Empty;

            var result = apiObject?.Type switch
            {
                OpenApiType.String => "string",
                OpenApiType.Integer => "int",
                OpenApiType.Boolean => "bool",
                OpenApiType.Array => HandleArray(apiObject.Items),
                OpenApiType.Object => HandleObject(apiObject, nullable),
                OpenApiType.Enum => HandleEnum(apiObject.Items),
                null => "object",
                _ => throw new NotSupportedException()
            };

            // Make nullable
            if (NullableProperties && nullable)
            {
                result += '?';
            }
            return result;
        }

        private static string GetReferenceName(string reference) => reference.Split('/').Last();  
        
        private string HandleClassReference(string reference)
        {
            var refName = GetReferenceName(reference);
            if (Cache.Instance.Contains(refName))
                return ClassParser.GetName(refName);

            var generator = new ClassGenerator(refName, Schemas, Serializer) 
            { 
                NullableProperties = NullableProperties, 
                DefaultPropertyType = DefaultPropertyType, 
                ArrayTypeFormat = ArrayTypeFormat 
            };
            generator.GenerateFile();

            return ClassParser.GetName(refName);
        }

        private string HandleEnumReference(string reference)
        {
            var refName = GetReferenceName(reference);
            if (Cache.Instance.Contains(refName))
                return ClassParser.GetName(refName);

            var generator = new EnumGenerator(refName, Schemas, Serializer);
            generator.GenerateFile();

            return ClassParser.GetName(refName);
        }

        private static string HandlePropertyName(string propertyName) =>
            char.ToUpper(propertyName[0]) + propertyName[1..];
        
        private static string Indent(int level) => new (' ', level * 4);

        public string GenerateProperties(int level = 0)
        {
            if (Schema.Properties == null)
                return string.Empty;

            var indent = Indent(level);
            var sb = new StringBuilder();
            foreach (var prop in Schema.Properties)
            {
                sb.AppendLine($"{indent}[{Serializer.Property}(\"{prop.Key}\")]");
                sb.AppendLine($"{indent}{PropertyAccessModifier} {HandleType(prop.Value)} {HandlePropertyName(prop.Key)} {PropertySuffix}");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }

        public override string Generate()
        {
            var sb = new StringBuilder();
            var indent = Indent(1);
            sb.AppendLine(Serializer.Usings);
            sb.AppendLine($"namespace {Class.Namespace}");
            sb.AppendLine($"{{");
            sb.AppendLine($"{indent}{ClassAccessModifier} class {Class.Name}");
            sb.AppendLine($"{indent}{{");
            sb.AppendLine(GenerateProperties(2));
            sb.AppendLine($"{indent}}}");
            sb.AppendLine($"}}");
            return sb.ToString();
        }

        public override string ToString() => Class.FullName;
    }
}
