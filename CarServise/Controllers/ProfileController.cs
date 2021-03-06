﻿using CarServise.Data;
using CarServise.Data.Models;
using CarServise.Models.ProfileViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarServise.Models.ForumViewModels
{
    [Authorize(Roles = "Admins")]
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
                .OrderByDescending(u=>u.MemberSince)
                .Select(p=> new ProfileModel
                {
                    UserId = p.Id,
                    FIO = p.FIO,
                    CompName = p.CompanyName,
                    OKPOname = p.OkpoName,
                    City = p.Sity,
                    Since = p.MemberSince,
                    Phone = p.PhoneNumber,
                    Email = p.Email
                });
            var model = new ProfileListModel
            {
                Profiles = profiles
            };

            return View(model);
        }
        public IActionResult Edit(string id)
            {
            var user = _userService.GetById(id);
            var model = new ProfileModel
            {
                UserId = user.Id,
                FIO = user.FIO,
                CompName = user.CompanyName,
                OKPOname = user.OkpoName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Since = user.MemberSince
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(string id, ProfileModel profile)
        {
            var user = _userService.Edit(id, profile);
            return RedirectToAction("Index","Profile");
        }

    }
}
