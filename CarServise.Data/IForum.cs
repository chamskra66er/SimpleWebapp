using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarServise.Data.Models;

namespace CarServise.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GeyAll();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}
