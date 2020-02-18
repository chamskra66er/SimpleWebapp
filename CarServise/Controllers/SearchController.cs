using CarServise.Data;
using CarServise.Models.ForumViewModels;
using CarServise.Models.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Controllers
{
    public class SearchController : Controller
    {
        private readonly IForum _forumServise;
        public SearchController(IForum forumService)
        {
            _forumServise = forumService;
        }
        public IActionResult Result(string searchQuery)
        {
            var forums = _forumServise.GetFilteredForums(searchQuery).ToList();
            var areNoResult = (!string.IsNullOrEmpty(searchQuery) && !forums.Any());
            var forumListing = forums.Select(forum => new ForumListingModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Value = forum.Value,
                ImgUrl = forum.ImageUrl
            });
            var model = new SearchResultModel
            {
                Forums = forumListing,
                SearchQuery = searchQuery,
                EmptySearchResult = areNoResult
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Result", new { searchQuery });
        }
    }
}
