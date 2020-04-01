using NameValuePairs.Core.Constraints;
using NameValuePairs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameValuePairs.Repositories
{
    /// <summary>
    /// Repository managing the NameValuePairs
    /// </summary>
    public class NameValuePairRepository : INameValuePairRepository
    {
        private readonly List<NameValuePair> Elements = new List<NameValuePair>();
        private readonly INameValuePairConstraints NameValuePairConstraints;

        public NameValuePairRepository(INameValuePairConstraints nameValuePairConstraints)
        {
            NameValuePairConstraints = nameValuePairConstraints;
        }

        /// <summary>
        /// Checks constraints and Adds a new NameValuePair
        /// </summary>
        public void Add(NameValuePair pair)
        {
            Elements.Add(NameValuePairConstraints.Match(pair));
        }

        /// <summary>
        /// Removes a range of NameValuePairs
        /// </summary>
        public void RemoveRange(IList<NameValuePair> range)
        {
            foreach (var item in range)
                Elements.Remove(item);
        }

        /// <summary>
        /// List all NameValuePairs
        /// </summary>
        public IList<NameValuePair> List()
        {
            //Returns a copy to avoid the caller to mess with the data
            return Elements.ToList();
        }

        private IEnumerable<NameValuePair> PrepareFilterQuery(FilterSetting setting)
        {
            IEnumerable<NameValuePair> query = Elements;
            if (setting != null)
            {
                if (setting.Type == FilterSetting.ValueType.NAME)
                {
                    query = query.Where(x => x.Name.Contains(setting.Value));
                }
                else
                {
                    query = query.Where(x => x.Value.Contains(setting.Value));
                }
            }
            return query;
        }

        /// <summary>
        /// List filtered NameValuePairs
        /// </summary>
        public IList<NameValuePair> Filter(FilterSetting setting)
        {
            return PrepareFilterQuery(setting).ToList();
        }

        public IList<NameValuePair> SortBy(FilterSetting setting, Func<NameValuePair, string> command)
        {
            return PrepareFilterQuery(setting).OrderBy(command).ToList();
        }

        /// <summary>
        /// List filtered NameValuePairs sorted by name
        /// </summary>
        public IList<NameValuePair> SortByName(FilterSetting setting = null)
        {
            return SortBy(setting, (NameValuePair x) => x.Name);
        }

        /// <summary>
        /// List filtered NameValuePairs sorted by value
        /// </summary>
        public IList<NameValuePair> SortByValue(FilterSetting setting = null)
        {
            return SortBy(setting, (NameValuePair x) => x.Value);
        }
    }
}
