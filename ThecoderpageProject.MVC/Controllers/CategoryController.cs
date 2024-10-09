using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        string uri = "https://localhost:7244";

        // Tüm kategorileri getir
        public async Task<IActionResult> Categories()
        {
            var categories = await _categoryService.GetCategories();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/Category"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);


                }
            }
            return PartialView("_CategoryPartialView", categories);
        }
    }
}
