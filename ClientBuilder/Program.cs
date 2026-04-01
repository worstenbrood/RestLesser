using ClientBuilder;
using ClientBuilder.Models;

var openApi = OpenApi.Load("swagger.json");
Console.WriteLine($"OpenAPI Version: {openApi?.Version}");

var serializer = new Serializer(SerializerType.NewtonsoftJson);
var schemas = openApi?.Components?.Schemas ?? new Dictionary<string, OpenApiComponentSchema>();

foreach (var component in schemas)
{
    var c = new ClassGenerator(component.Key, schemas, serializer)
    {
        NullableProperties = true,
    };

    c.GenerateFile();
}
