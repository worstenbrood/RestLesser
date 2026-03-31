using System.Text.Json.Serialization;

namespace ClientBuilder.Models
{
    public class Swagger
    {
        [JsonPropertyName("openapi")]
        public string? OpenApi { get; set; }

        [JsonPropertyName("info")]
        public SwaggerInfo? Info { get; set; }

        [JsonPropertyName("paths")]
        public Dictionary<string, SwaggerPath>? Paths { get; set; }

        [JsonPropertyName("components")]
        public SwaggerComponents? Components { get; set; }
    }

    public class SwaggerComponents
    {
        [JsonPropertyName("schemas")]
        public Dictionary<string, SwaggerComponentSchema>? Schemas { get; set; }
    }

    public class SwaggerComponentSchema
    {
        [JsonPropertyName("required")]
        public List<string>? Required { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, SwaggerProperty>? Properties { get; set; }
    }

    public class SwaggerProperty : SwaggerSchema
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("format")]
        public string? Format { get; set; }

        [JsonPropertyName("nullable")]
        public bool? Nullable { get; set; }

        [JsonPropertyName("items")]
        public SwaggerSchema? Items { get; set; }
    }

    public class SwaggerPath
    {
        [JsonPropertyName("get")]
        public SwaggerOperation? Get { get; set; }
        [JsonPropertyName("post")]
        public SwaggerOperation? Post { get; set; }
        [JsonPropertyName("put")]
        public SwaggerOperation? Put { get; set; }
        [JsonPropertyName("delete")]
        public SwaggerOperation? Delete { get; set; }
    }

    public class SwaggerOperation
    {
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
        
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("parameters")]
        public List<SwaggerParameter>? Parameters { get; set; }

        [JsonPropertyName("requestBody")]
        public SwaggerRequestBody? RequestBody { get; set; }

        [JsonPropertyName("responses")]
        public Dictionary<string, SwaggerResponse>? Responses { get; set; }
    }
      

    public class SwaggerResponse
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("content")]
        public Dictionary<string, SwaggerMediaType>? Content { get; set; }
    }

    public class SwaggerRequestBody
    {
        [JsonPropertyName("content")]
        public Dictionary<string, SwaggerMediaType>? Content { get; set; }
    }

    public class SwaggerMediaType
    {
        [JsonPropertyName("schema")]
        public SwaggerSchema? Schema { get; set; }
    }

    public class SwaggerSchema
    {
        [JsonPropertyName("$ref")]
        public string? Ref { get; set; }
    }

    public class SwaggerInfo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("contact")]
        public SwaggerContact? Contact { get; set; }

        [JsonPropertyName("license")]
        public SwaggerLicense? License { get; set; }
    }

    public class SwaggerContact
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class SwaggerLicense
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class SwaggerParameter
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
        public SwaggerParameterSchema? Schema { get; set; }
    }

    public class SwaggerParameterSchema
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("format")]
        public string? Format { get; set; }
    }
}
