using CarServise.Data;
using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServise.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(ApplicationUser user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Deactivate(ApplicationUser user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(string id, ApplicationUser user)
        {
            var profile = GetById(id);
            profile.FIO = user.FIO;
            profile.CompanyName = user.CompanyName;
            profile.OkpoName = user.OkpoName;
            profile.PhoneNumber = user.PhoneNumber;
            profile.Email = user.Email;
            _context.ApplicationUsers.Update(profile);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return _context.ApplicationUsers.FirstOrDefault(p => p.Id == id);
        }
    }
}
