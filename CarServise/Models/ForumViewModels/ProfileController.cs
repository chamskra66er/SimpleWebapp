using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.ProfileViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.ForumViewModels
{
    public class ProfileController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(u=>u.FIO)
                .Select(p=> new ProfileModel
                {
                    Id = Convert.ToInt32(p.Id),
                    FIO = p.FIO,
                    CompName = p.CompanyName,
                    OKPOname = p.OkpoName,
                    City = p.Sity,
                    Since = p.MemberSince,
                    Phone = p.PhoneNumber
                });
            var model = new ProfileListModel
            {
                Profiles = profiles
            };

            return View(model);
        }

    }
}
