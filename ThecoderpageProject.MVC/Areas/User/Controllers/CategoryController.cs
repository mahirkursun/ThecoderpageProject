using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
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
    }
}
