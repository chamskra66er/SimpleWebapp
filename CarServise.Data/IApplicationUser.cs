using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarServise.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task Add(ApplicationUser user);
        Task Deactivate(ApplicationUser user);
        Task Edit(string id, ApplicationUser user);

    }
}
