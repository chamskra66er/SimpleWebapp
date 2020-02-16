using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.ForumViewModels
{
    public class AddForumModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile UploadVideo { get; set; }
        public IFormFile UploadFile { get; set; }
        public IFormFile UploadImage { get; set; }
        public int ImageCount { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateFinish { get; set; }
    }
}
