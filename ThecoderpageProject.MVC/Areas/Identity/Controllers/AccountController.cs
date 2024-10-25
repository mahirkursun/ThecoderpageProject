using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.MVC.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Identity/Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Identity/Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
                if (result.Succeeded)
                {

                    var user = _userManager.FindByNameAsync(loginVM.UserName).Result;
                    var roles = _userManager.GetRolesAsync(user).Result;


                    // Kullanıcı girişi başarılıysa, yönlendirme yapabilirsiniz,
                    //Areas user role
                    if (user.Role == UserRole.Admin)
                    {

                        // Admin paneline yönlendir Problem listesine
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }




                }

                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış.");
            }
            // Giriş başarısızsa veya kullanıcı rolü yoksa
            return View(loginVM); // Anasayfaya yönlendir

        }


        // GET: Identity/Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Identity/Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Role = registerVM.Role,
                    CreatedAt = registerVM.CreatedAt

                };

                // Kullanıcıyı oluşturma
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    // Kayıt başarılıysa, kullanıcıyı yönlendirebilirsiniz
                    return RedirectToAction("Login", "Account");
                }

                // Hata varsa, hataları ModelState'e ekle
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Eğer model geçerli değilse veya hata varsa, formu tekrar göster
            return View(registerVM);
        }

        public IActionResult AccessDenied()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;
            var roles = _userManager.GetRolesAsync(user).Result;

            // Kullanıcının rolleri hakkında bilgi almak için
            ViewBag.UserRoles = roles;
            return View();
        }


        // GET: Identity/Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // Kullanıcı çıkış yaptıktan sonra anasayfaya yönlendir. Linke gitme
            return RedirectToAction("Index", "Home", new {area =""});


        }
    }
}
