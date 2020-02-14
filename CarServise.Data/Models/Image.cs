using System;
using System.Collections.Generic;
using System.Text;
using CarServise.Models;

namespace CarServise.Data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string ImgUrl4 { get; set; }
        public string ImgUrl5 { get; set; }
        public string ImgUrl6 { get; set; }
        public string ImgUrl7 { get; set; }
        public string ImgUrl8 { get; set; }
    }
}
