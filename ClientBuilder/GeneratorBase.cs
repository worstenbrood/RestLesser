using ClientBuilder.Models;

namespace ClientBuilder
{
    internal class GeneratorBase(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer)
    {
        protected readonly ClassParser Class = new (fullName);
        protected readonly Dictionary<string, OpenApiComponentSchema> Schemas = schemas;
        protected readonly OpenApiComponentSchema Schema = schemas[fullName];
        protected readonly Serializer Serializer = serializer;
    }
}
