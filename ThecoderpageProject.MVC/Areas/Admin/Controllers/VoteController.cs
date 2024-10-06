﻿using Microsoft.AspNetCore.Mvc;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        // **UpVote** işlemi
        [HttpPost]
        public async Task<IActionResult> UpVote(int problemId, string userId)
        {
            var existingVote = await _voteService.GetVoteByUserIdAndProblemId(userId, problemId);

            if (existingVote != null)
            {
                if (existingVote.VoteType == VoteType.UpVote)
                {
                    // Beğeniyi geri çekme (oy silme)
                    await _voteService.RemoveVote(existingVote.Id);
                    TempData["Success"] = "UpVote geri çekildi.";
                }
                else
                {
                    // Eğer kullanıcı daha önce downvote verdiyse upvote'a çevir
                    existingVote.VoteType = VoteType.UpVote;
                    await _voteService.UpdateVote(existingVote);
                    TempData["Success"] = "DownVote, UpVote olarak güncellendi.";
                }
            }
            else
            {
                // Yeni UpVote ekle
                var vote = new Vote
                {
                    ProblemId = problemId,
                    UserId = userId,
                    VoteType = VoteType.UpVote,
                    VotedAt = DateTime.Now
                };
                await _voteService.AddVote(vote);
                TempData["Success"] = "UpVote başarıyla eklendi.";
            }

            return RedirectToAction("Index", "Problem", new { id = problemId });
        }

        // **DownVote** işlemi
        [HttpPost]
        public async Task<IActionResult> DownVote(int problemId, string userId)
        {
            var existingVote = await _voteService.GetVoteByUserIdAndProblemId(userId, problemId);

            if (existingVote != null)
            {
                if (existingVote.VoteType == VoteType.DownVote)
                {
                    // Beğeniyi geri çekme (oy silme)
                    await _voteService.RemoveVote(existingVote.Id);
                    TempData["Success"] = "DownVote geri çekildi.";
                }
                else
                {
                    // Eğer kullanıcı daha önce upvote verdiyse downvote'a çevir
                    existingVote.VoteType = VoteType.DownVote;
                    await _voteService.UpdateVote(existingVote);
                    TempData["Success"] = "UpVote, DownVote olarak güncellendi.";
                }
            }
            else
            {
                // Yeni DownVote ekle
                var vote = new Vote
                {
                    ProblemId = problemId,
                    UserId = userId,
                    VoteType = VoteType.DownVote,
                    VotedAt = DateTime.Now
                };
                await _voteService.AddVote(vote);
                TempData["Success"] = "DownVote başarıyla eklendi.";
            }

            return RedirectToAction("Index", "Problem", new { id = problemId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVote(int problemId, string userId)
        {
            var existingVote = await _voteService.GetVoteByUserIdAndProblemId(userId, problemId);

            if (existingVote != null)
            {
                await _voteService.RemoveVote(existingVote.Id);
                TempData["Success"] = "Oy geri çekildi.";
            }
            else
            {
                TempData["Error"] = "Oy bulunamadı."; // Kullanıcıya bir hata mesajı göster
            }

            return RedirectToAction("Index", "Problem"); // Problem listesinin bulunduğu Index'e geri dön
        }
    }
}
