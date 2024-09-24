using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            List<CategoryVM> categories = new List<CategoryVM>();
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
