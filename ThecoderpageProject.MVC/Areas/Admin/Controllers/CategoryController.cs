using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        string uri = "https://localhost:7244";

        // GET: /Admin/Category/Index
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();// Tüm kategorileri al
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/Category"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);


                }
            }
            return View(categories);


        }


        public IActionResult Create()
        {
            return View();
        }

        // Admin/Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO category)
        {
            //kayıt işlemi
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(category); // Hatalı veri girildiyse formu tekrar göster
            }

            await _categoryService.Create(category);
            TempData["Success"] = $"{category.Name} başarıyla eklendi";
            return RedirectToAction(nameof(Index));

        }

        // Admin/Category/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = new UpdateCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                
            };
            return View(categoryDTO);
        }

        // Admin/Category/Update/5
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(categoryDTO); // Hatalı veri girildiyse formu tekrar göster
            }

            await _categoryService.Update(categoryDTO);
            TempData["Success"] = $"{categoryDTO.Name} başarıyla güncellendi";
            return RedirectToAction(nameof(Index));
        }

        // Admin/Category/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = new UpdateCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,

            };
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.Delete(id);
            TempData["Success"] = $"{category.Name} başarıyla silindi";
            return RedirectToAction(nameof(Index));

        }

        // Admin/Category/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = new UpdateCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,

            };

            return View(categoryDTO);
        }


    }
}
