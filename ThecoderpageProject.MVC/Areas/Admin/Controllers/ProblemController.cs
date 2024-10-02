using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService) // Update constructor
        {
            _problemService = problemService;
           
        }

        string uri = "https://localhost:7244";

        // Admin/Problem/Index
        public async Task<IActionResult> Index()
        {
            List<ProblemVM> problems = new List<ProblemVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/Problem"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    problems = JsonConvert.DeserializeObject<List<ProblemVM>>(apiResponse);
                }
            }
            return View(problems);
        }

        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProblemDTO problemDTO)
        {
            

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(problemDTO);
            }

            await _problemService.Create(problemDTO);
            TempData["Success"] = $"{problemDTO.Title} başarıyla eklendi";
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