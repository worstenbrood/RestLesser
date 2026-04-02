using ClientBuilder.Models;
using System.Text;

namespace ClientBuilder
{
    internal class EnumGenerator(string fullName, Dictionary<string, OpenApiComponentSchema> schemas, Serializer serializer) : 
        GeneratorBase(fullName, schemas, serializer)
    {
        public override string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Serializer.Usings);
            sb.AppendLine($"namespace {Class.Namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public enum {Class.Name}");
            sb.AppendLine("    {");
            if (Schema.Enum != null)
            {
                foreach (var value in Schema.Enum)
                {
                    var name = value.ToString() ?? throw new InvalidOperationException("Enum value cannot be null");
                    // Ensure the name is a valid C# identifier
                    if (!char.IsLetter(name[0]) && name[0] != '_')
                    {
                        name = "_" + name;
                    }
                    name = string.Concat(name.Select(c => char.IsLetterOrDigit(c) ? c : '_'));
                    sb.AppendLine($"        {name},");
                }
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
