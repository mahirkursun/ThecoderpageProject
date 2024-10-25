using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Application.Models.VMs;
using System.Linq;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ILikeRepository<Like> _likeRepository;
        private readonly IProblemService _problemService;
        private readonly IUserService _userService;

        public LikeController(ILikeRepository<Like> likeRepository, IUserService userService, IProblemService problemService)
        {
            _likeRepository = likeRepository;
            _problemService = problemService;
            _userService = userService;
        }

        // GET: Admin/Like
        public async Task<IActionResult> Index()
        {
            var likes = await _likeRepository.GetAllLikes();
            var users = await _userService.GetAll();
            var problems = await _problemService.GetAll();

            var likeVMs = likes.Select(like => new LikeVM
            {
                Id = like.Id,
                ProblemId = like.ProblemId,
                ProblemTitle = problems.FirstOrDefault(p => p.Id == like.ProblemId)?.Title ?? "Unknown Problem",
                UserId = like.UserId,
                UserName = users.FirstOrDefault(u => u.Id == like.UserId)?.UserName ?? "Unknown User",
                LikeCount = likes.Count(l => l.ProblemId == like.ProblemId) // Example of LikeCount
            }).ToList();

            return View(likeVMs);
        }



        
    }
}
