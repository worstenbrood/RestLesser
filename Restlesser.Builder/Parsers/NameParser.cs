namespace Restlesser.Builder.Parsers
{
    internal class NameParser
    {
        public readonly string[] Parts;
        public readonly string Name;
        public readonly string FullName;
        public readonly string Namespace;
        
        public static string GetNamespace(string fullName) => string.Join('.', fullName.Split('.').Reverse().Skip(1).Reverse());

        public static string GetName(string fullName) => fullName.Split('.').Last();

        public string GetPath() => Path.Combine(Parts.Take(Parts.Length - 1).ToArray());

        public NameParser(string fullName)
        {
            Parts = fullName.Split('.');
            FullName = fullName;
            Name = Parts.Last();
            Namespace = string.Join('.', Parts[..^1]);
        }
    }
}
