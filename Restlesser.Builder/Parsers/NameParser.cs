namespace Restlesser.Builder.Parsers
{
    internal class NameParser
    {
        public readonly string Name;
        public readonly string FullName;
        public readonly string Namespace;
        
        public static string GetNamespace(string fullName)
        {
            var lastDotIndex = fullName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }
            else
            {
                return fullName[..lastDotIndex];
            }
        }

        public static string GetName(string fullName)
        {
            var lastDotIndex = fullName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                return fullName;
            }
            else
            {
                return fullName[(lastDotIndex + 1)..];
            }
        }

        public NameParser(string fullName)
        {
            FullName = fullName;

            // Parse namespace and name from fullName
            var lastDotIndex = fullName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                Name = fullName;
                Namespace = string.Empty;
            }
            else
            {
                Name = fullName[(lastDotIndex + 1)..];
                Namespace = fullName[..lastDotIndex];
            }
        }
    }
}
