using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarServise.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FIO { get; set; }
        public string CompanyName { get; set; }
        public string OkpoName { get; set; }
        public string Sity { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
