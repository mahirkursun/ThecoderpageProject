using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Controllers
{
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IVoteService _voteService;
        private readonly ICategoryService _categoryService;

        public ProblemController(IProblemService problemService, IVoteService voteService, ICategoryService categoryService)
        {
            _problemService = problemService;
            _voteService = voteService;
            _categoryService = categoryService;
        }

        // Tüm problemleri getir
        public async Task<IActionResult> Problems()
        {
            var problems = await _problemService.GetAll();
            return PartialView("_ProblemsPartialView", problems);
        }

        // Belirli bir kategoriye göre problemleri getir
        public async Task<IActionResult> ProblemsByCategory(int categoryId)
        {
            var problems = await _problemService.GetProblemsByCategory(categoryId);
            return PartialView("_ProblemsPartialView", problems);
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
            return PartialView("_ProblemsPartialView", problemDTO);
        }
    }
}
