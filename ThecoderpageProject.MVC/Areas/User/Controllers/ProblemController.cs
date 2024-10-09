using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IVoteService _voteService;
        private readonly ICategoryService _categoryService;

        public ProblemController(IProblemService problemService, IVoteService voteService, ICategoryService categoryService) // Update constructor
        {
            _problemService = problemService;
            _voteService = voteService;
            _categoryService = categoryService;

        }


        // User/Problem/Index
        public async Task<IActionResult> Index()
        {
            var problems = await _problemService.GetAll(); 

            /*ÖNEMLİ */
            /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            foreach (var problem in problems)
            {
                // Kullanıcının bu problem için oy verip vermediğini kontrol edin
                var userVote = await _voteService.GetVoteByUserIdAndProblemId(userId, problem.Id);
                if (userVote != null)
                {
                    problem.UserVoteType = userVote.VoteType; // Kullanıcının verdiği oy tipini sakla (upvote veya downvote)
                }
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
            problemDTO.UserId = userId;

            await _problemService.Create(problemDTO);
            TempData["Success"] = $"{problemDTO.Title} başarıyla eklendi";
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Update(UpdateProblemDTO problemDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(problemDTO);
            }

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



    }
}
