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
        public string ImgUrl { get; set; }       
        public string UserId { get; set; }
    }
}
