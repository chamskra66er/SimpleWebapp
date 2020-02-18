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
using ClosedXML.Excel;
using System.IO;

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
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Value = forum.Value,
                    ImgUrl = forum.ImageUrl
                });
            var model = new ForumSearchQuery
            {
                Forum = forums
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Topic",new { searchQuery});
        }
        public IActionResult Topic(string searchQuery)
        {
            var forums = new List<Forum>();
            forums = _forumService.GetFilteredForums(searchQuery).ToList();
            var forumListing = forums.Select(forum=> new ForumListingModel
            {
                Id=forum.Id,
                Name=forum.Title,
                Value = forum.Value,
                ImgUrl = forum.ImageUrl
            });
            var model = new ForumIndexModel
            {
                ForumList = forumListing
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

            XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Information");

            worksheet.Cell(1, 1).SetValue(model.FIO);
            worksheet.Cell(1, 2).SetValue(model.Pat);
            worksheet.Cell(1, 3).SetValue(model.Val);
            worksheet.Cell(1, 4).SetValue(model.Finish);

            MemoryStream MS = new MemoryStream();
            workbook.SaveAs(MS);
            MS.Position = 0;

            return new FileStreamResult(MS, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            { FileDownloadName = $"{user.Email}.xlsx" };
        }

    }

}
