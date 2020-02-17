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
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var forums = _forumService.GeyAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Value = forum.Value,
                    ImgUrl = forum.ImageUrl
                });
            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var forum = _forumService.GetById(id);
            var model = new ForumDetailModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Descr = forum.Description,
                Val = forum.Value,
                Pat=forum.Path,
                ImgUrl=forum.ImageUrl,
                ImgCount = forum.ImageCount,
                FlUrl = forum.FileUrl,
                VidUrl = forum.VideoUrl,
                Start = forum.DateCreate,
                Finish = forum.DateFinish,
                Com = forum.Comment
            };         
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new AddForumModel();
            return View(model);
        }

    }

}
