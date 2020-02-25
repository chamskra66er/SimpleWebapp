using CarServise.Data;
using CarServise.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private readonly IForum _forumService;
        public NavigationMenuViewComponent(IForum forumService)
        {
            _forumService = forumService;
        }
        public IViewComponentResult Invoke()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                });
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(forums
                .Select(x=>x.Name)
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
