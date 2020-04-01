using NameValuePairs.Core.Entities;
using NameValuePairs.Repositories;
using System.Collections.Generic;

namespace NameValuePairs.Models
{
    public class MainModel
    {
        private readonly INameValuePairRepository Repository;

        private FilterSetting FilterSetting { get; set; }

        public MainModel(INameValuePairRepository repository)
        {
            Repository = repository;
        }

        public IList<NameValuePair> Add(NameValuePair pair)
        {
            Repository.Add(pair);
            return ClearFilter();
        }

        public IList<NameValuePair> Filter(FilterSetting setting)
        {
            FilterSetting = setting;
            return Repository.Filter(FilterSetting);
        }

        public IList<NameValuePair> ClearFilter()
        {
            FilterSetting = null;
            return Repository.List();
        }

        public IList<NameValuePair> SortByName()
        {
            return Repository.SortByName(FilterSetting);
        }

        public IList<NameValuePair> SortByValue()
        {
            return Repository.SortByValue(FilterSetting);
        }

        public IList<NameValuePair> Delete(IList<NameValuePair> pairs)
        {
            Repository.RemoveRange(pairs);
            return Repository.Filter(FilterSetting);
        }
    }
}
