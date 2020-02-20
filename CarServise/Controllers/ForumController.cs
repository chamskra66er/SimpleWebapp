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
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace CarServise.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _host;
        public ForumController(IForum forumService, UserManager<ApplicationUser> userManager,
            IHostingEnvironment host)
        {
            _forumService = forumService;
            _userManager = userManager;
            _host = host;
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
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddForum(AddForumModel model, IFormFile UploadImage,
            IFormFile UploadVideo, IFormFile UploadFile)
        {
            var imageUri = "";
            var videoUri = "";
            var fileUri = "";

            if (model.UploadImage != null)
            {
                var contentDisposition = ContentDispositionHeaderValue.Parse(UploadImage.ContentDisposition);
                var fileName = contentDisposition.FileName.Trim('"');
                var pathHost = _host.WebRootPath;
                var parsePath = pathHost.Replace('\\', '/');
                var path = pathHost + $"/images/forum/{User.Identity.Name}" + fileName;
                imageUri = $"/images/forum/{User.Identity.Name}/" + fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await UploadImage.CopyToAsync(fileStream);
                }
            }
            else
            {
                imageUri = "/images/forum/default.png";
            }

            if (model.UploadVideo != null)
            {
                var contentDisposition = ContentDispositionHeaderValue.Parse(UploadVideo.ContentDisposition);
                var fileName = contentDisposition.FileName.Trim('"');
                var pathHost = _host.WebRootPath;
                var parsePath = pathHost.Replace('\\', '/');
                var path = pathHost + $"/images/forum/{User.Identity.Name}" + fileName;
                videoUri = $"/images/forum/{User.Identity.Name}/" + fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await UploadVideo.CopyToAsync(fileStream);
                }
            }
            else
            {
                videoUri = "/images/forum/default.mp4";
            }

            if (model.UploadFile != null)
            {
                var contentDisposition = ContentDispositionHeaderValue.Parse(UploadFile.ContentDisposition);
                var fileName = contentDisposition.FileName.Trim('"');
                var pathHost = _host.WebRootPath;
                var parsePath = pathHost.Replace('\\', '/');
                var path = pathHost + $"/images/forum/{User.Identity.Name}" + fileName;
                fileUri = $"/images/forum/{User.Identity.Name}/" + fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await UploadFile.CopyToAsync(fileStream);
                }
            }
            else
            {
                fileUri = "/images/forum/default.xlsx";
            }

            var forum = new Forum
            {
                Title = model.Title,
                Description = model.Description,
                VideoUrl = videoUri,
                ImageUrl = imageUri,
                FileUrl = fileUri,
                Path = User.Identity.Name,
                Value  =model.Value,
                Comment = model.Comment,
                DateCreate = DateTime.Now,
                DateFinish = model.DateFinish
            };
            await _forumService.Add();

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
