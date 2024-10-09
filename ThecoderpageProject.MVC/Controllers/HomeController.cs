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
            var isAuthenticated = User.Identity.IsAuthenticated; // Kullan�c� giri� yapm�� m�?

            // Kullan�c� giri� yapmam��sa, k�s�tlamalarla anasayfaya y�nlendir
            if (!isAuthenticated)
            {
                ViewBag.Message = "Giri� yapmad�n�z. Be�eni, yorum veya rapor olu�turamazs�n�z.";
                return View(); // Giri� yapmam�� kullan�c� i�in anasayfa g�r�n�m�
            }

            // Kullan�c� giri� yapm��sa, normal anasayfa g�r�n�m�n� g�ster
            return View(); // Giri� yapm�� kullan�c� i�in anasayfa g�r�n�m�
        }
    }
}
