using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Application.Models.VMs;
using System.Linq;
using System.Threading.Tasks;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ILikeRepository<Like> _likeRepository;

        public LikeController(ILikeRepository<Like> likeRepository)
        {
            _likeRepository = likeRepository;
        }

        // GET: Admin/Like
        public async Task<IActionResult> Index()
        {
            var likes = await _likeRepository.GetAllLikes();
            var likeVMs = likes.Select(like => new LikeVM
            {
                ProblemId = like.ProblemId,
                UserId = like.UserId
            }).ToList();

            return View(likeVMs);
        }

        // GET: Admin/Like/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var like = await _likeRepository.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return View(like);
        }
    }
}
