using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestLesser.OData.Interfaces
{
    /// <summary>
    /// Client interface
    /// </summary>
    public interface IODataClient
    {
        /// <summary>
        /// Get a single entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        T GetEntry<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Get a single entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        Task<T> GetEntryAsync<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Post a single entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entry"></param>
        void PostEntry<T>(ODataUrlBuilder<T> builder, T entry);

        /// <summary>
        /// Post a single entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entry"></param>
        Task PostEntryAsync<T>(ODataUrlBuilder<T> builder, T entry);

        /// <summary>
        /// Get multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        T[] GetEntries<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Get multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        Task<T[]> GetEntriesAsync<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Post multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entries"></param>
        void PostEntries<T>(ODataUrlBuilder<T> builder, T[] entries);

        /// <summary>
        /// Post multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entries"></param>
        Task PostEntriesAsync<T>(ODataUrlBuilder<T> builder, T[] entries);

        /// <summary>
        /// Delete multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        void DeleteEntries<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Delete multiple entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        Task DeleteEntriesAsync<T>(ODataUrlBuilder<T> builder);

        /// <summary>
        /// Put a single value
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entry"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task PutValueAsync<TClass, TProperty>(ODataUrlBuilder<TClass> builder, 
            TClass entry, Expression<Func<TClass, TProperty>> field, TProperty value);
        
        /// <summary>
        /// Put a single value
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="builder"></param>
        /// <param name="entry"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        void PutValue<TClass, TProperty>(ODataUrlBuilder<TClass> builder,
           TClass entry, Expression<Func<TClass, TProperty>> field, TProperty value);

        /// <summary>
        /// Query builder for given endpoint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        ODataUrlBuilder<T> Query<T>(string url);
    }
}