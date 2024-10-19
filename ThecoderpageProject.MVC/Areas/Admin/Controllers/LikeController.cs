using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View(likes);
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

        // GET: Admin/Like/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Like/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProblemId,UserId,CreatedAt")] Like like)
        {
            if (ModelState.IsValid)
            {
                await _likeRepository.AddLike(like);
                return RedirectToAction(nameof(Index));
            }
            return View(like);
        }

        // GET: Admin/Like/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var like = await _likeRepository.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return View(like);
        }

        // POST: Admin/Like/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProblemId,UserId,CreatedAt")] Like like)
        {
            if (id != like.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _likeRepository.UpdateLike(like);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _likeRepository.GetLikeById(like.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(like);
        }

        // GET: Admin/Like/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var like = await _likeRepository.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return View(like);
        }

        // POST: Admin/Like/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _likeRepository.RemoveLike(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
