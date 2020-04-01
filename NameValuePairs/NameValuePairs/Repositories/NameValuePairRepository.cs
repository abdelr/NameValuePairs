using System;
using System.Collections.Generic;
using NameValuePairs.Core.Constraints;
using NameValuePairs.Core.Entities;

namespace NameValuePairs.Repositories
{
    public class NameValuePairRepository : INameValuePairRepository
    {
        private readonly INameValuePairConstraints nameValuePairConstraints;

        public NameValuePairRepository(INameValuePairConstraints nameValuePairConstraints)
        {
            
        }

        public void Add(NameValuePair pair)
        {
            throw new NotImplementedException();
        }

        public IList<NameValuePair> Filter(FilterSetting setting = null)
        {
            throw new NotImplementedException();
        }

        public IList<NameValuePair> List()
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IList<NameValuePair> range)
        {
            throw new NotImplementedException();
        }

        public IList<NameValuePair> SortByName(FilterSetting setting = null)
        {
            throw new NotImplementedException();
        }

        public IList<NameValuePair> SortByValue(FilterSetting setting = null)
        {
            throw new NotImplementedException();
        }
    }
}
