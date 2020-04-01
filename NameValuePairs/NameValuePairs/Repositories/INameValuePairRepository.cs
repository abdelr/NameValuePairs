using NameValuePairs.Core.Entities;
using System.Collections.Generic;

namespace NameValuePairs.Repositories
{
    /// <summary>
    /// Repository managing the NameValuePairs
    /// </summary>
    public interface INameValuePairRepository
    {
        /// <summary>
        /// Checks constraints and Adds a new NameValuePair
        /// </summary>
        void Add(NameValuePair pair);

        /// <summary>
        /// Removes a range of NameValuePairs
        /// </summary>
        void RemoveRange(IList<NameValuePair> range);

        /// <summary>
        /// List all NameValuePairs
        /// </summary>
        IList<NameValuePair> List();

        /// <summary>
        /// List filtered NameValuePairs
        /// </summary>
        IList<NameValuePair> Filter(FilterSetting setting = null);

        /// <summary>
        /// List filtered NameValuePairs sorted by name
        /// </summary>
        IList<NameValuePair> SortByName(FilterSetting setting = null);

        /// <summary>
        /// List filtered NameValuePairs sorted by value
        /// </summary>
        IList<NameValuePair> SortByValue(FilterSetting setting);
    }
}
