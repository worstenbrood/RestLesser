using System.Text;

namespace Restlesser.Builder
{
    public enum SerializerType
    {
        SystemTextJson,
        NewTonSoftJson
    }

    public class Serializer
    {
        public readonly string[] Libraries;
        public readonly string Usings;
        public readonly string PropertyAttribute;
        public readonly string EnumAttribute;

        public Serializer(SerializerType type)
        {
            // Libraries to use for the selected serializer
            Libraries = type switch
            {
                SerializerType.SystemTextJson =>
                [
                    "System.Text",
                    "System.Text.Json",
                    "System.Text.Json.Serialization"
                ],
                SerializerType.NewTonSoftJson =>
                [
                    "Newtonsoft.Json",

                ],
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            // Property attribute format for the selected serializer, {0} will be replaced with the property name
            PropertyAttribute = type switch
            {
                SerializerType.SystemTextJson => "JsonPropertyName(\"{0}\")",
                SerializerType.NewTonSoftJson => "JsonProperty(Name=\"{0}\")",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            EnumAttribute = type switch
            {
                _ => "EnumMember(Value = \"{0}\")"
            };

            // Generate using directives for the selected serializer
            var sb = new StringBuilder();
            foreach (var lib in Libraries)
            {
                sb.AppendLine($"using {lib};");
            }
            Usings = sb.ToString();
        }

        public string GetPropertyAttribute(string propertyName) => string.Format(PropertyAttribute, propertyName);
        public string GetEnumAttribute(string value) => string.Format(EnumAttribute, value);
    }
}
