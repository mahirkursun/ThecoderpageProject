﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                var user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password,false,  false);
                    if (result.Succeeded)
                    {
                        // Kullanıcı girişi başarılıysa, yönlendirme yapabilirsiniz,
                        //Areas user role
                        if (user.Role == UserRole.Admin)
                        {
                            // Admin paneline yönlendir Problem listesine
                            return RedirectToAction("Index", "Home", new { area = "Admin/Problem" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "User/Problem" });
                        }




                    }
                }
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış.");
            }
            return View(loginVM);

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
                    PasswordHash = registerVM.Password,

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

        // GET: Identity/Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
