using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        string uri = "https://localhost:7244";

        // Admin/User/Index // çalışmıyor: 404 not found hatası veriyor. Çünkü bu action'ın bir view'i yok.
        public async Task<IActionResult> Index()
        {
            
            List<UserVM> users = new List<UserVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/User"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserVM>>(apiResponse);
                }
            }
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }


        // Admin/User/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO user)
        {
            //kayıt işlemi
            if(!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
            }

            bool result = false;

            if(!result)
            {
                await _userService.Create(user);
                TempData["Success"] = $"{user.FirstName} {user.LastName} başarıyla eklendi";
                Console.WriteLine("başarılı");
            }
            else
            {
                TempData["Error"] = "Kullanıcı eklenirken bir hata oluştu";
                Console.WriteLine("hatalı");
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
