﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly ILikeService _likeService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;

        public ProblemController(IProblemService problemService, ILikeService likeService, ICategoryService categoryService, ICommentService commentService, IUserService userService, IReportService reportService ) // Update constructor
        {
            _problemService = problemService;
            _likeService = likeService;
            _categoryService = categoryService;
            _commentService = commentService;
            _userService = userService;
            _reportService = reportService;

        }


        // User/Problem/Index
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Kullanıcının problemlerini alın
            var problems = await _problemService.GetProblemsByUserId(userId);

            

            return View(problems);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategories();


            var model = new CreateProblemDTO
            {
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name // İsim eklenmeli
                }).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProblemDTO problemDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            problemDTO.UserId = userId;

            await _problemService.Create(problemDTO);
            TempData["Success"] = $"{problemDTO.Title} başarıyla eklendi";

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // User/Problem/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            var problemDTO = new UpdateProblemDTO
            {
                Id = problem.Id,
                Title = problem.Title,
                Description = problem.Description,
                Status = problem.Status,
                CreatedAt = problem.CreatedAt,
                CategoryId = problem.CategoryId,
                UserId = problem.UserId

            };
            return View(problemDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProblemStatus status)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            problem.Status = status;
            await _problemService.Update(problem);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            var problemDTO = new UpdateProblemDTO
            {
                Id = problem.Id,
                Title = problem.Title,
                Description = problem.Description,
                Status = problem.Status,
                CreatedAt = problem.CreatedAt,
                CategoryId = problem.CategoryId,
                UserId = problem.UserId,
            };
            return View(problemDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            await _problemService.Delete(id);
            TempData["Success"] = $"{problem.Title} başarıyla silindi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string userId)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            var problemDTO = new UpdateProblemDTO
            {
                Id = problem.Id,
                Title = problem.Title,
                Description = problem.Description,
                Status = problem.Status,
                CreatedAt = problem.CreatedAt,
                CategoryId = problem.CategoryId,
                UserId = problem.UserId,
                Users = (await _userService.GetAll()).ToList(),
                Comments = (await _commentService.GetCommentsByProblemId(id)).ToList(),
                Reports = (await _reportService.GetAllReports()).ToList(),
                Likes = await  _likeService.GetLikeByProblemId(id)
            };
            return View(problemDTO);
        }



    }
}
