using System;
using System.Collections.Generic;
using System.Text;

namespace CarServise.Data.Models
{
    public class Forum
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string FileUrl { get; set; }
        public string Value { get; set; }
        public string Cooment { get; set;}
    }
}
