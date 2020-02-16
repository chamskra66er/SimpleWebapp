using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServise.Data.Models;

namespace CarServise.Models.ForumViewModels
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ImgUrl { get; set; }
    }
}
