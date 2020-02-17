using CarServise.Data;
using CarServise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarServise.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        public Task Add(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task Deactivate(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
