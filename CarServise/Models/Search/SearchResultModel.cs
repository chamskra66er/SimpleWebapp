using CarServise.Models.ForumViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.Search
{
    public class SearchResultModel
    {
        public IEnumerable<ForumListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResult { get; set; }
    }
}
