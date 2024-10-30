using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;

        public ProblemController(IProblemService problemService, ILikeService likeService,ICategoryService categoryService, IUserService userService, ICommentService commentService) // Update constructor
        {
            _problemService = problemService;
            _categoryService = categoryService;
            _userService = userService;
            _likeService = likeService;
            _commentService = commentService;


        }


        // Admin/Problem/Index
        public async Task<IActionResult> Index()
        {
            var problems = await _problemService.GetAll();
            var likes = await _likeService.GetAllLikes();
            var comments = await _commentService.GetAll();

            foreach (var problem in problems)
            {
                var user = await _userService.GetUserById(problem.UserId);
                var category = await _categoryService.GetCategoryById(problem.CategoryId);
                
                problem.UserName = user?.UserName ?? string.Empty;
                problem.Name = category?.Name ?? string.Empty;
                problem.Likes = likes.Where(l => l.ProblemId == problem.Id).ToList();
                problem.Comments = comments.Where(c => c.ProblemId == problem.Id).ToList();

            }

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
            problemDTO.UserId = userId ?? string.Empty;
            

            await _problemService.Create(problemDTO);
            TempData["Success"] = $"{problemDTO.Title} başarıyla eklendi";
            return RedirectToAction(nameof(Index));
        }

        // Admin/Problem/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var problem = await _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }
            var categories = await _categoryService.GetCategories();

            var problemDTO = new UpdateProblemDTO
            {
                Id = problem.Id,
                Title = problem.Title,
                Description = problem.Description,
                Status = problem.Status,
                CreatedAt = problem.CreatedAt,
                CategoryId = problem.CategoryId,
                UserId = problem.UserId,
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };
            return View(problemDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateProblemDTO problemDTO)
        {


            await _problemService.Update(problemDTO);
            TempData["Success"] = $"{problemDTO.Title} başarıyla güncellendi";
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Details(int id)
        {
            var problem = await _problemService.GetProblemById(id);
          

            if (problem == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserById(problem.UserId);
            var category = await _categoryService.GetCategoryById(problem.CategoryId);
            var likes = await _likeService.GetAllLikes();
            var comments = await _commentService.GetAll();

            foreach (var comment in comments)
            {
                var commentUser = await _userService.GetUserById(comment.UserId);
                comment.UserName = commentUser?.UserName ?? string.Empty;
            }

            var problemDTO = new UpdateProblemDTO
            {
                Id = problem.Id,
                Title = problem.Title,
                Description = problem.Description,
                Status = problem.Status,
                CreatedAt = problem.CreatedAt,
                CategoryId = problem.CategoryId,
                UserName = user.UserName,
                Name = category.Name,
                Likes = likes.Where(l => l.ProblemId == problem.Id).ToList(),
                Comments = comments.Where(c => c.ProblemId == problem.Id).ToList()
            };
            return View(problemDTO);
        }
    }
}