using System;

namespace RestLesser
{
    /// <summary>
    /// Class to work with relative urls
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="relativeUri"></param>
    public class RelativeUri(string relativeUri) : Uri(Dummy, relativeUri)
    {
        private readonly static Uri Dummy = new("http://dummy");

        /// <summary>
        /// Return path
        /// </summary>
        public string Path => GetLeftPart(UriPartial.Path);
       
        /// <summary>
        /// Build PathAndQuery
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Query))
            {
                return $"{Path}?{Query}";
            }

            return Path;
        }
    }
}
