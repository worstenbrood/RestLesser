using ClientBuilder.Models;

var openApi = OpenApi.Load("swagger.json");
Console.WriteLine($"OpenAPI Version: {openApi?.Version}");

foreach(var component in openApi?.Components?.Schemas ?? new Dictionary<string, OpenApiComponentSchema>())
{

   
}
