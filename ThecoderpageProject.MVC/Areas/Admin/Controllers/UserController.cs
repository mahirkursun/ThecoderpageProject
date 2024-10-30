using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Admin/User/Index
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        // Admin/User/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
                // Password alanını isteğe bağlı hale getirebilirsiniz
            };

            return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen girdiğiniz verileri kontrol edin.";
                return View(userDTO);
            }

            await _userService.Update(userDTO);
            TempData["Success"] = $"{userDTO.FirstName} {userDTO.LastName} başarıyla güncellendi";
            return RedirectToAction(nameof(Index));
        }

        // Admin/User/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
                // Password alanını isteğe bağlı hale getirebilirsiniz
            };

            return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            await _userService.Delete(id);
            TempData["Success"] = $"{user.FirstName} {user.LastName} başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        // Admin/User/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
                // Password alanını isteğe bağlı hale getirebilirsiniz
            };

            return View(userDTO);
        }
    }
}
