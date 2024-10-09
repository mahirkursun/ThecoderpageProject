using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.MVC.Models;

namespace ThecoderpageProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated; // Kullanýcý giriþ yapmýþ mý?

            // Kullanýcý giriþ yapmamýþsa, kýsýtlamalarla anasayfaya yönlendir
            if (!isAuthenticated)
            {
                ViewBag.Message = "Giriþ yapmadýnýz. Beðeni, yorum veya rapor oluþturamazsýnýz.";
                return View(); // Giriþ yapmamýþ kullanýcý için anasayfa görünümü
            }

            // Kullanýcý giriþ yapmýþsa, normal anasayfa görünümünü göster
            return View(); // Giriþ yapmýþ kullanýcý için anasayfa görünümü
        }
    }
}
