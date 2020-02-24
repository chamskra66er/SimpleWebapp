using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.ForumViewModels
{
    public class ForumSearchQuery
    {
        public IEnumerable<ForumListingModel> Forum { get; set; }
        public string SearchQuery { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
