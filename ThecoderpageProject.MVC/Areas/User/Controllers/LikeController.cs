using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.MVC.Models;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class LikeController : Controller
    {
        private readonly ILikeRepository<Like> _likeRepository;
        private readonly ILikeService _likeService;

        public LikeController(ILikeRepository<Like> likeRepository, ILikeService likeService)
        {
            _likeRepository = likeRepository;
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleLike(int problemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            

            var likes = await _likeService.GetLikeByProblemId(problemId);
            // If user is not authenticated, return forbidden
            if (string.IsNullOrEmpty(userId))
            {
                return Forbid();
            }

            // Check if the user has already liked the problem
            var like = await _likeRepository.GetLikeByUserIdAndProblemId(userId, problemId);

            if (like == null)
            {
                // If not liked, add a like
                like = new Like
                {
                    ProblemId = problemId,
                    UserId = userId,
                    CreatedAt = DateTime.Now
                };
                await _likeRepository.AddLike(like);
            }
            else
            {
                // If already liked, remove the like
                await _likeRepository.RemoveLike(like.Id);
            }

            //url /User/Problem/Details/2 ise olduğu yerde kalsın:
            if (Request.Headers["Referer"].ToString().Contains("User/Problem/Details/" + problemId))
            {
                return RedirectToAction("Details", "Problem", new { area = "User", id = problemId });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            // Redirect back to the page where the like action was triggered
            
        }


    }
}

