using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly string uri = "https://localhost:7244";

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> Details()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userService.GetUserById(userId);
            if (user == null) return NotFound();

            var userDTO = new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserName = user.UserName,
                Email = user.Email,
                // Password alanını isteğe bağlı hale getirebilirsiniz
            };

            return View(userDTO);
        }
    }
}
