namespace Restlesser.Builder.Parsers
{
    internal class NameParser
    {
        public const char Separator = '.';

        public readonly string[] Parts;
        public readonly string Name;
        public readonly string FullName;
        public readonly string Namespace;
        public readonly string Path;
        
        public static string GetNamespace(string fullName) => string.Join(Separator, fullName.Split(Separator).Reverse().Skip(1).Reverse());

        public static string GetName(string fullName) => fullName.Split(Separator).Last();

        public NameParser(string fullName)
        {
            Parts = fullName.Split(Separator);
            FullName = fullName;
            Name = Parts.Last();
            Namespace = string.Join(Separator, Parts[..^1]);
            Path = System.IO.Path.Combine(Parts[..^1]);
        }
    }
}
