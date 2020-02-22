using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.ProfileViewModels
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string FIO { get; set; }
        public string CompName { get; set; }
        public string OKPOname { get; set; }
        public string City { get; set; }
        public DateTime Since { get; set; }
        public string Phone{get; set;}
        public string Email { get; set; }
    }
}
