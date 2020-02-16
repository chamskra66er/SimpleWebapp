using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarServise.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }       
        public string VideoUrl { get; set; }
        public string FileUrl { get; set; }
        public string ImageUrl { get; set; }
        public int ImageCount { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
        public string Comment { get; set;}
        public DateTime DateCreate { get; set; }
        public DateTime DateFinish { get; set; }
    }
}
