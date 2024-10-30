using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;

        }


        // Admin/Comment/Index
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAll();

            foreach (var comment in comments)
            {
                var user = await _userService.GetUserById(comment.UserId);

                comment.UserName = user?.UserName ?? string.Empty;
               

            }
            return View(comments);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDTO commentDTO, int problemId)
        {
            // Verify if the ProblemId exists
            var problemExists = await _commentService.GetCommentsByProblemId(commentDTO.ProblemId);
            if (problemExists == null)
            {
                TempData["Error"] = "Problem bulunamadı";
                return View(commentDTO);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            commentDTO.UserId = userId;
            commentDTO.ProblemId = problemId;
            await _commentService.Create(commentDTO);
            TempData["Success"] = $"{commentDTO.Content} başarıyla eklendi";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            var commentDTO = new UpdateCommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                UserId = comment.UserId,
                ProblemId = comment.ProblemId,
                CreatedAt = comment.CreatedAt
            };
            return View(commentDTO);


        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentDTO commentDTO)
        {
            

            await _commentService.Update(commentDTO);
            TempData["Success"] = $"{commentDTO.Content} başarıyla güncellendi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            var commentDTO = new UpdateCommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                UserId = comment.UserId,
                ProblemId = comment.ProblemId,
                CreatedAt = comment.CreatedAt
            };

            return View(commentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.Delete(id);
            TempData["Success"] = "Yorum başarıyla silindi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserById(comment.UserId);
            

            var commentDTO = new UpdateCommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                UserId = comment.UserId,
                ProblemId = comment.ProblemId,
                CreatedAt = comment.CreatedAt,
                UserName = user.UserName,
            };

            return View(commentDTO);
        }



    }
}
