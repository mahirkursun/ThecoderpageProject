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
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(user); // Hatalı veri girildiyse formu tekrar göster
            }

            await _userService.Create(user);
            TempData["Success"] = $"{user.FirstName} {user.LastName} başarıyla eklendi";
            return RedirectToAction(nameof(Index));

        }

        // Admin/User/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetUserById(id); // Kullanıcıyı id ile al
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
                
            };

            return View(userDTO); // Güncellenmiş kullanıcı bilgileri ile view'i döndür
        }

        // Admin/User/Update/5
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen girdiğiniz verileri kontrol edin.";
                return View(userDTO); // Hatalı veri varsa formu tekrar göster
            }

            await _userService.Update(userDTO); // Kullanıcıyı güncelle
            TempData["Success"] = $"{userDTO.FirstName} {userDTO.LastName} başarıyla güncellendi";
            return RedirectToAction(nameof(Index)); // Güncelleme sonrası liste sayfasına dön
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserById(id); // Kullanıcıyı id ile al
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password

            };

            return View(userDTO); // Kullanıcıyı silmek için onay sayfasını döndür
        }

        // Admin/User/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userService.GetUserById(id); // Kullanıcıyı id ile al
            if (user == null)
            {
                return NotFound();
            }

            await _userService.Delete(id); // Kullanıcıyı sil
            TempData["Success"] = $"{user.FirstName} {user.LastName} başarıyla silindi.";
            return RedirectToAction(nameof(Index)); // Silme sonrası liste sayfasına dön
        }

        //Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserById(id); // Kullanıcıyı id ile al
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password

            };

            return View(userDTO); // Kullanıcıyı silmek için onay sayfasını döndür
        }




    }
}
