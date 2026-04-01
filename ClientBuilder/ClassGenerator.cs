using ClientBuilder.Models;
using System.Text;

namespace ClientBuilder
{
    internal class ClassGenerator
    {
        private readonly ClassParser _class;
        private readonly Dictionary<string, OpenApiComponentSchema> _schemas;
        private readonly OpenApiComponentSchema _schema;
        private readonly Serializer _serializer;

        public ClassGenerator(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer)
        {
            _class = new ClassParser(fullName);
            _schemas = schemas;
            _schema = _schemas[fullName];
            _serializer = serializer;
        }

        private string HandleType(OpenApiProperty? property)
        {
            if (property == null)
                return string.Empty;

            // Handle types
            return property.Type switch
            {
                OpenApiType.Array => $"List<{property?.Items?.Type}>",
                OpenApiType.String => "string",
                OpenApiType.Integer => "int",
                OpenApiType.Boolean => "bool",
                OpenApiType.Object => "object",
                OpenApiType.Enum => HandleRef(property?.Reference ?? string.Empty),
                null => "object",
                _ => throw new NotSupportedException()
            };
        }

        private string HandleRef(string reference)
        {
            var refName = reference.Split('/').Last();
            if (Cache.Instance.Contains(refName))
                return refName;
            var generator = new ClassGenerator(refName, _schemas, _serializer);
            generator.GenerateFile();
            return refName;
        }

        public string GenerateProperties(int level = 0)
        {
            if (_schema.Properties == null)
                return string.Empty;

            var indent = new string(' ', level * 4);
            var sb = new StringBuilder();
            foreach (var prop in _schema.Properties)
            {
                var propName = char.ToUpper(prop.Key[0]) + prop.Key.Substring(1);
                sb.AppendLine($"{indent}[{_serializer.Property}(\"{prop.Key}\")]");
                sb.AppendLine($"{indent}public {HandleType(prop.Value)} {propName} {{ get; set; }}");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }

        public string GenerateClass()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_serializer.Usings);
            sb.AppendLine($"namespace {_class.Namespace}");
            sb.AppendLine($"{{");
            sb.AppendLine($"    public class {_class.Name}");
            sb.AppendLine($"    {{");
            sb.AppendLine(GenerateProperties(2));
            sb.AppendLine($"    }}");
            sb.AppendLine($"}}");

            // Add to cache to prevent duplicate generation
            Cache.Instance.Add($"{_class.FullName}");

            return sb.ToString();
        }

        public void GenerateFile()
        {
            using var writer = new StreamWriter($"{_class.Name}.cs");
            writer.Write(GenerateClass());
        }
    }
}
