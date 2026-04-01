namespace ClientBuilder
{
    internal class Cache() : HashSet<string>
    {
        public static readonly Cache Instance = [];
    }
}
