using ClientBuilder.Models;
using System.Text;
using System.Text.Json;

var swagger = JsonSerializer.Deserialize<Swagger>(File.ReadAllText("swagger.json", Encoding.UTF8));
Console.WriteLine($"OpenAPI Version: {swagger?.OpenApi}");
