using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.MVC.Models;

namespace ThecoderpageProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProblemService _problemService;

        public HomeController(ICategoryService categoryService, IProblemService problemService)
        {
            _categoryService = categoryService;
            _problemService = problemService;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            


            var categories = await _categoryService.GetCategories();
            var problems = categoryId.HasValue
                ? await _problemService.GetProblemsByCategory(categoryId.Value)
                : await _problemService.GetAll();

            var model = new HomeViewModel
            {
                Categories = categories,
                Problems = problems
            };

            return View(model);
        }
    }
}
