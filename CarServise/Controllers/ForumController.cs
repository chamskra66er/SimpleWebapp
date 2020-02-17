using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.ForumViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CarServise.Models;
using CarServise.Models.File;

namespace CarServise.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ForumController(IForum forumService, UserManager<ApplicationUser> userManager)
        {
            _forumService = forumService;
            _userManager = userManager;
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

            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;

            var model = new ForumDetailModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Descr = forum.Description,
                Val = forum.Value,
                ImgUrl=forum.ImageUrl,
                ImgCount = forum.ImageCount,
                FlUrl = forum.FileUrl,
                VidUrl = forum.VideoUrl,
                Start = forum.DateCreate,
                Finish = forum.DateFinish,
                Com = forum.Comment,
                FIO = user.FIO,
                Pat = user.UserName
            };         
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new AddForumModel();
            return View(model);
        }
        [Authorize]
        [HttpPost]        
        public IActionResult Report(ReportModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;

            Excel ls= new Excel();
            ls.CreateNewFile(model);
            return View("Detail");
        }

    }

}
