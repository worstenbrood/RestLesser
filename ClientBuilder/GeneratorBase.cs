using ClientBuilder.Models;
using System.Text;

namespace ClientBuilder
{
    internal abstract class GeneratorBase(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer)
    {
        protected readonly ClassParser Class = new (fullName);
        protected readonly Dictionary<string, OpenApiComponentSchema> Schemas = schemas;
        protected readonly OpenApiComponentSchema Schema = schemas[fullName];
        protected readonly Serializer Serializer = serializer;

        protected string Folder { get; set; } = "Models";

        public abstract string Generate();

        public void GenerateFile()
        {
            if (Cache.Instance.Contains(Class.FullName))
                return;

            Directory.CreateDirectory(Folder);

            // Save file with UTF-8 encoding to support all characters
            File.WriteAllText($"{Folder}\\{Class.Name}.cs", Generate(), Encoding.UTF8);

            // Add to cache to prevent duplicate generation
            Cache.Instance.Add(Class.FullName);
        }
    }
}
