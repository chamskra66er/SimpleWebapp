using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServise.Data;
using CarServise.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServise.Service
{
    public class ForumSevice : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumSevice(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.Id == id)
                .FirstOrDefault();
            return forum;
        }

        public IEnumerable<Forum> GetFilteredForums(string searchQuery)=>
            GetAll().Where(p => p.Title.Contains(searchQuery) || p.Description.Contains(searchQuery));

        public IEnumerable<Forum> GetAll() =>
            _context.Forums;
        //.Include(f => f.ImageUrl);


        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
