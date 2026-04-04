using Restlesser.Builder.Models;
using Restlesser.Builder.Parsers;
using System.Text;

namespace Restlesser.Builder.Generators
{
    internal abstract class GeneratorBase(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer)
    {
        protected readonly NameParser Class = new (fullName);
        protected readonly Dictionary<string, OpenApiComponentSchema> Schemas = schemas;
        protected readonly OpenApiComponentSchema Schema = schemas[fullName];
        protected readonly Serializer Serializer = serializer;

        protected string Folder { get; set; } = "Models";
        protected static string Indent(int level) => new(' ', level * 4);
        protected static string GetReferenceName(string reference) => reference.Split('/').Last();
        protected static string GetPropertyName(string propertyName) =>
            char.ToUpper(propertyName[0]) + propertyName[1..];

        protected static string GetEnumValueName(object value)
        {
            var name = value.ToString() ?? throw new InvalidOperationException("Enum value cannot be null");
            // Ensure the name is a valid C# identifier
            if (!char.IsLetter(name[0]) && name[0] != '_')
            {
                name = "_" + name;
            }
            name = string.Concat(name.Select(c => char.IsLetterOrDigit(c) ? c : '_'));
            return name;
        }

        public abstract string Generate();

        private string GetPath(bool flat) => flat ? Folder : Class.GetPath();

        /// <summary>
        /// Generate class and references
        /// </summary>
        /// <param name="flat"></param>
        public void GenerateFile(bool flat = true)
        {
            if (Cache.Instance.Contains(Class.FullName))
                return;

            var path = GetPath(flat);

            // Create directory
            Directory.CreateDirectory(path);

            // Save file with UTF-8 encoding to support all characters
            File.WriteAllText($"{path}\\{Class.Name}.cs", Generate(), Encoding.UTF8);

            // Add to cache to prevent duplicate generation
            Cache.Instance.Add(Class.FullName);
        }
    }
}
