namespace Restlesser.Builder
{
    internal class Cache() : HashSet<string>
    {
        public static readonly Cache Instance = [];
    }
}
