using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.ForumViewModels;

namespace CarServise.Controllers
{
    public class ForumController:Controller
    {
        private readonly IForum _forumService;
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var forums = _forumService.GeyAll()
                .Select(forum=> new ForumListingModel
                {
                    Id=forum.Id,
                    Name=forum.Title,
                    Value = forum.Value
                });
            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

    }
}
