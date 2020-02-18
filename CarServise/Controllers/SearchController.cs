using CarServise.Data;
using CarServise.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.Search
{
    public class SearchController:Controller
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
        }
        [HttpPost]
        public IActionResult Serach(string searchQuery)
        {
            return RedirectToAction("Result", new { searchQuery});
        }

    }
}
