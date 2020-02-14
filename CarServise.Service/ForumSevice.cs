using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GeyAll() => 
            _context.Forums.Include(f => f.ImageUrl);


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
