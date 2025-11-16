using System;
using System.Threading.Tasks;

namespace RestLesser.OData
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <param name="client"></param>
    /// <param name="query"></param>
    public class ODataQuery<TClass>(ODataClient client, string query) : ODataUrlBuilder<TClass>(query)
    {
        private TClass[] _entries;

        /// <summary>
        /// Set entries (used later by the Post calls)
        /// </summary>
        /// <param name="entries">Entries to set</param>
        public void Set(TClass[] entries)
        {
            _entries = entries;
        }

        /// <summary>
        /// Set a single entry (used later by the Post calls)
        /// </summary>
        /// <param name="entry">Entry to set</param>
        public void Set(TClass entry)
        {
            _entries = [entry];
        }

        /// <summary>
        /// Get entries from the api using this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        /// <returns>An array of <typeparamref name="TClass"/></returns>
        public async Task<TClass[]> GetEntriesAsync()
        {
            return await client.GetEntriesAsync(this);
        }

        /// <summary>
        /// Get entries from the api using this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        /// <returns>An array of <typeparamref name="TClass"/></returns>
        public TClass[] GetEntries()
        {
            return client.GetEntries(this);
        }

        /// <summary>
        /// Get a single entry from the api using this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        /// <returns>A single <typeparamref name="TClass"/></returns>
        public Task<TClass> GetEntryAsync()
        {
            return client.GetEntryAsync(this);
        }

        /// <summary>
        /// Get a single entry from the api using this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        /// <returns>A single <typeparamref name="TClass"/></returns>
        public TClass GetEntry()
        {
            return client.GetEntry(this);
        }

        /// <summary>
        /// Post the entries set by the <see cref="Set(TClass)"/> and <see cref="Set(TClass[])"/> methods.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ODataUrlBuilder<TClass>> PostEntriesAsync()
        {
            if (_entries == null || _entries.Length == 0)
            {
                throw new ArgumentNullException(nameof(_entries), "Use Set() first.");
            }

            await client.PostEntriesAsync(this, _entries);
            return this;
        }

        /// <summary>
        /// Post the entries set by the <see cref="Set(TClass)"/> and <see cref="Set(TClass[])"/> methods.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public ODataUrlBuilder<TClass> PostEntries()
        {
            if (_entries == null || _entries.Length == 0)
            {
                throw new ArgumentNullException(nameof(_entries), "Use Set() first.");
            }

            client.PostEntries(this, _entries);
            return this;
        }

        /// <summary>
        /// Post a single entry, no need to call Set() before
        /// </summary>
        /// <param name="entry"></param>
        public async Task<ODataUrlBuilder<TClass>> PostEntryAsync(TClass entry)
        {
            await client.PostEntryAsync(this, entry);
            return this;
        }

        /// <summary>
        /// Post a single entry, no need to call Set() before
        /// </summary>
        /// <param name="entry"></param>
        public ODataUrlBuilder<TClass> PostEntry(TClass entry)
        {
            client.PostEntry(this, entry);
            return this;
        }

        /// <summary>
        /// Delete entries specified by this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        public async Task<ODataUrlBuilder<TClass>> DeleteEntriesAsync()
        {
            await client.DeleteEntriesAsync(this);
            return this;
        }

        /// <summary>
        /// Delete entries specified by this <see cref="ODataUrlBuilder{TClass}"/>
        /// </summary>
        public ODataUrlBuilder<TClass> DeleteEntries()
        {
            client.DeleteEntries(this);
            return this;
        }
    }
}
