using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult Create(int problemId, int commentId)
        {

            var model = new CreateReportDTO
            {
                ProblemId = problemId,
                CommentId = commentId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReportDTO reportDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reportDTO.UserId = userId;

            if (reportDTO.ProblemId > 0)
            {
                reportDTO.CommentId = null; // Eğer Problem varsa Comment 0 olmalı
            }
            else if (reportDTO.CommentId > 0)
            {
                reportDTO.ProblemId = null; // Eğer Comment varsa Problem 0 olmalı
            }
            else
            {
                TempData["Error"] = "Lütfen ya bir Problem ya da bir Comment seçin.";
                return View(reportDTO);
            }

            // Report kaydını oluştur
            await _reportService.CreateReport(reportDTO);
            TempData["Success"] = "Rapor başarıyla oluşturuldu.";

            // Comment rapor edilmişse CommentController'a yönlendir
            if (reportDTO.CommentId.HasValue)
            {
                return RedirectToAction("Index", "Comment");
            }

            // Problem rapor edilmişse ProblemController'a yönlendir
            return RedirectToAction("Index", "Problem");
        }
    }
}
