﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.MVC.Models;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProblemService _problemService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        private readonly ILikeService _likeService;


        public HomeController(ICategoryService categoryService, IProblemService problemService, ICommentService commentService, IUserService userService, IReportService reportService, ILikeService likeService)
        {
            _categoryService = categoryService;
            _problemService = problemService;
            _commentService = commentService;
            _userService = userService;
            _reportService = reportService;
            _likeService = likeService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            var problems = await _problemService.GetAll();

            var comments = await _commentService.GetAll();
            var users = await _userService.GetAll();
            var reports = await _reportService.GetAllReports();
            var likes = await _likeService.GetAllLikes();

            var model = new HomeViewModel
            {
                Categories = categories,
                Problems = problems,
                Comments = comments,
                Users = users,
                Reports = reports,
                Likes = likes
            };

            return View(model);
        }
    }

   
}