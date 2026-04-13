using Restlesser.Builder.Models;
using Restlesser.Builder.Parsers;
using System.Text;

namespace Restlesser.Builder.Generators
{
    internal class Generator(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer) : GeneratorBase(fullName, schemas, serializer)
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
                return $"{HandleReference(schema.Reference)}";
            }
            return HandleType(schema, nullable);
        }

        private string HandleArray(OpenApiObject? schema) => string.Format(ArrayTypeFormat, HandleObject(schema, false));

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
                OpenApiType.Enum => HandleObject(apiObject.Items),
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

        /// <summary>
        /// Generate a reference generator for the given reference. 
        /// This is used to generate a separate class for the referenced schema, 
        /// and return the name of the generated class to be used as the type of the property that references it.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public Generator CreateReferenceGenerator(string reference) => new (reference, Schemas, Serializer) 
        {
            // Copy properties from the current generator to ensure consistency in generated code
            NullableProperties = NullableProperties, 
            DefaultPropertyType = DefaultPropertyType, 
            ArrayTypeFormat = ArrayTypeFormat,
            ClassAccessModifier = ClassAccessModifier,
            PropertyAccessModifier = PropertyAccessModifier,
            PropertySuffix = PropertySuffix,
            Folder = Folder,
            FlatStructure = FlatStructure
        };

        private string HandleReference(string reference)
        {
            var refName = GetReferenceName(reference);
            if (Cache.Instance.Contains(refName))
                return NameParser.GetName(refName);

            // Generate reference
            var generator = CreateReferenceGenerator(refName);
            generator.GenerateFile();

            return NameParser.GetName(refName);
        }
                       
        public string GenerateProperties(int level = 0)
        {
            if (Schema.Properties == null)
                return string.Empty;

            var indent = Indent(level);
            var sb = new StringBuilder();
            foreach (var prop in Schema.Properties)
            {
                sb.AppendLine($"{indent}[{Serializer.GetPropertyAttribute(prop.Key)}]");
                sb.AppendLine($"{indent}{PropertyAccessModifier} {HandleType(prop.Value)} {GetPropertyName(prop.Key)} {PropertySuffix}");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }

        public string GenerateClass()
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

        /// <summary>
        /// Generates enum values for the enum defined in the OpenAPI schema. 
        /// It ensures that the enum values are valid C# identifiers by replacing 
        /// invalid characters with underscores and prefixing with an underscore if 
        /// the name starts with a non-letter character. The generated enum values are 
        /// returned as a string that can be used in the enum definition.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GenerateEnumValues(int level = 0)
        {
            if (Schema.Enum == null) 
                return string.Empty;

            var indent = Indent(level);
            return string.Join(",\r\n", Schema.Enum.Select(v => $"{indent}{GetEnumValueName(v)}"));
        }

        public string GenerateEnum()
        {
            var sb = new StringBuilder();
            var indent = Indent(1);
            sb.AppendLine(Serializer.Usings);
            sb.AppendLine($"namespace {Class.Namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"{indent}public enum {Class.Name}");
            sb.AppendLine($"{indent}{{");
            if (Schema.Enum != null)
            {
               sb.AppendLine(GenerateEnumValues(2));
            }
            sb.AppendLine($"{indent}}}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string Generate()
        {
            if(Schema.Enum != null)
            {
                return GenerateEnum();
            }

            return GenerateClass();
        }

        public override string ToString() => Class.FullName;
    }
}
