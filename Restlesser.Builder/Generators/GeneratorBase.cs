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

        /// <summary>
        /// Destination folder for generated classes, default is "Models". T
        /// his can be customized to fit your project structure. 
        /// For example, you might want to use "Generated" or "ApiModels" instead. 
        /// The generator will create this folder if it doesn't exist and place the generated classes inside it.
        /// </summary>
        public string Folder { get; set; } = "Models";

        /// <summary>
        /// If true, all generated classes will be placed in a flat structure under the specified folder. 
        /// If false, the folder structure will mirror the namespace structure. Default is false.
        /// </summary>
        public bool FlatStructure { get; set; } = false;

        protected static string Indent(int level) => new(' ', level * 4);
        protected static string GetReferenceName(string reference) => reference.Split('/').Last();
        protected static string GetPropertyName(string propertyName) =>
            char.ToUpper(propertyName[0]) + propertyName[1..];

        protected string GetEnumValueName(object value)
        {
            var valueName = value.ToString() ?? throw new InvalidOperationException("Enum value cannot be null");
            var name = string.Empty;

            // Ensure the name is a valid C# identifier
            if (!char.IsLetter(valueName[0]) && valueName[0] != '_')
            {
                name = "_" + valueName;

            }

            // Replace invalid characters with underscores
            name = string.Concat(name.Select(c => char.IsLetterOrDigit(c) ? c : '_'));

            // If the original value name is not a valid C# identifier, add the EnumMember attribute with the original value
            if (name != valueName)
            {
                name = $"[{Serializer.GetEnumAttribute(valueName)}] {name}";
            }

            return name;
        }

        public abstract string Generate();

        private string GetPath() => FlatStructure ? Folder : Path.Combine(Folder, Class.Path);

        /// <summary>
        /// Generate class and references
        /// </summary>
        /// <param name="flat"></param>
        public void GenerateFile()
        {
            if (Cache.Instance.Contains(Class.FullName))
                return;

            var path = GetPath();

            // Create directory
            Directory.CreateDirectory(path);

            // Save file with UTF-8 encoding to support all characters
            File.WriteAllText($"{path}\\{Class.Name}.cs", Generate(), Encoding.UTF8);

            // Add to cache to prevent duplicate generation
            Cache.Instance.Add(Class.FullName);
        }
    }
}
