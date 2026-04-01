namespace ClientBuilder
{
    internal class ClassParser
    {
        public readonly string Name;
        public readonly string FullName;
        public readonly string Namespace;
        
        public ClassParser(string fullName)
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
