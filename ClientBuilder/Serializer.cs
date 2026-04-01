using System.Text;

namespace ClientBuilder
{
    public enum SerializerType
    {
        SystemTextJson,
        NewtonsoftJson
    }

    public class Serializer
    {
        public readonly string[] Libraries;
        public readonly string Property;
        public readonly string Usings;

        public Serializer(SerializerType type)
        {
            Libraries = type switch
            {
                SerializerType.SystemTextJson =>
                [
                    "System.Text",
                    "System.Text.Json",
                    "System.Text.Json.Serialization"
                ],
                SerializerType.NewtonsoftJson =>
                [
                    "Newtonsoft.Json"
                ],
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            Property = type == SerializerType.SystemTextJson ? "JsonPropertyName" : "JsonProperty";

            var sb = new StringBuilder();
            foreach (var lib in Libraries)
            {
                sb.AppendLine($"using {lib};");
            }
            Usings = sb.ToString();
        }
    }
}
