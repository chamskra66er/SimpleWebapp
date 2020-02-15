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
        private readonly IImage _imageService;
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
            var images = _imageService.GetImagesByForm(id);
            var postListing = images.Select(p => new Image
            {
                Id = p.Id,
                User=p.User,
                UserId=p.User.Id,
                ImgUrl=p.ImgUrl

            });
            var model = new
            {
                postListing,
                forum
            };
            return View(model);
        }

    }

}
