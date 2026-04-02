using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restlesser.Builder.Models
{
    public enum OpenApiType
    {
        Object,
        Enum,
        Array,
        Primitive,
        Integer,
        String,
        Boolean,
    }

    public enum OpenApiFormat
    {
        Uuid,
        Int32,
        Int64,
        DateTime,
        Uri
    }

    public class OpenApi
    {
        public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.General)
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseLower)
            }
        };

        public static OpenApi? Load(string filePath) => JsonSerializer.Deserialize<OpenApi>(File.ReadAllText(filePath, Encoding.UTF8), JsonOptions);
        
        [JsonPropertyName("openapi")]
        public string? Version { get; set; }

        [JsonPropertyName("info")]
        public OpenApiInfo? Info { get; set; }

        [JsonPropertyName("paths")]
        public Dictionary<string, OpenApiPath>? Paths { get; set; }

        [JsonPropertyName("components")]
        public OpenApiComponents? Components { get; set; }
    }

    public class OpenApiComponents
    {
        [JsonPropertyName("schemas")]
        public Dictionary<string, OpenApiComponentSchema>? Schemas { get; set; }
    }

    public class OpenApiComponentSchema : OpenApiObject
    {
        [JsonPropertyName("required")]
        public List<string>? Required { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, OpenApiProperty>? Properties { get; set; }
    }

    public class OpenApiProperty : OpenApiObject
    {
        [JsonPropertyName("nullable")]
        public bool? Nullable { get; set; }
    }

    public class OpenApiPath
    {
        [JsonPropertyName("get")]
        public OpenApiOperation? Get { get; set; }
        
        [JsonPropertyName("post")]
        public OpenApiOperation? Post { get; set; }
        
        [JsonPropertyName("put")]
        public OpenApiOperation? Put { get; set; }

        [JsonPropertyName("delete")]
        public OpenApiOperation? Delete { get; set; }
    }

    public class OpenApiOperation
    {
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
        
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("parameters")]
        public List<OpenApiParameter>? Parameters { get; set; }

        [JsonPropertyName("requestBody")]
        public OpenApiRequestBody? RequestBody { get; set; }

        [JsonPropertyName("responses")]
        public Dictionary<string, OpenApiResponse>? Responses { get; set; }
    }
      
    public class OpenApiResponse
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("content")]
        public Dictionary<string, OpenApiMediaType>? Content { get; set; }
    }

    public class OpenApiRequestBody
    {
        [JsonPropertyName("content")]
        public Dictionary<string, OpenApiMediaType>? Content { get; set; }
    }

    public class OpenApiMediaType
    {
        [JsonPropertyName("schema")]
        public OpenApiObject? Schema { get; set; }
    }

    public class OpenApiInfo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("contact")]
        public OpenApiContact? Contact { get; set; }

        [JsonPropertyName("license")]
        public OpenApiLicense? License { get; set; }
    }

    public class OpenApiContact
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class OpenApiLicense
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class OpenApiParameter
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("in")]
        public string? In { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("schema")]
        public OpenApiObject? Schema { get; set; }
    }

    public class OpenApiObject
    {
        [JsonPropertyName("$ref")]
        public string? Reference { get; set; }

        [JsonPropertyName("type")]
        public OpenApiType? Type { get; set; }

        [JsonPropertyName("format")]
        public OpenApiFormat? Format { get; set; }

        [JsonPropertyName("items")]
        public OpenApiObject? Items { get; set; }

        [JsonPropertyName("enum")]
        public List<int>? Enum { get; set; }
    }
}
