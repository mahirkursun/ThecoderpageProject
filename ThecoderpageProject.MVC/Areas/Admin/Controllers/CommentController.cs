using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }

        string uri = "https://localhost:7244";

        // Admin/Comment/Index
        public async Task<IActionResult> Index()
        {
           var comments = await _commentService.GetAll();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/Comment"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    comments = JsonConvert.DeserializeObject<List<CommentVM>>(apiResponse);
                }
            }
            return View(comments);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDTO commentDTO)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            commentDTO.UserId = userId;
            commentDTO.ProblemId = 1;// Şimdilik 1 girildi

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
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Girdiğiniz verileri kontrol edin";
                return View(commentDTO);
            }

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



    }
}
