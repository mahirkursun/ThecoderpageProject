using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Data;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /*İncele*/
        public async Task<IActionResult> Index()
        {
            var reports = await _reportService.GetAllReports();
            return View(reports);
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
        public async Task<IActionResult> Create(CreateReportDTO model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen geçerli bir rapor nedeni seçin.";
                return View(model);
            }





            if (model.ProblemId > 0)
            {
                model.CommentId = null; // Eğer Problem varsa Comment 0 olmalı
            }
            else if (model.CommentId > 0)
            {
                model.ProblemId = null; // Eğer Comment varsa Problem 0 olmalı
            }
            else
            {
                TempData["Error"] = "Lütfen ya bir Problem ya da bir Comment seçin.";
                return View(model);
            }

            // Report kaydını oluştur
            await _reportService.CreateReport(model);
            TempData["Success"] = "Rapor başarıyla oluşturuldu.";

            // Comment rapor edilmişse CommentController'a yönlendir
            if (model.CommentId.HasValue)
            {
                return RedirectToAction("Index", "Comment");
            }

            // Problem rapor edilmişse ProblemController'a yönlendir
            return RedirectToAction("Index", "Problem");
        }
        // Rapor detaylarını gösterir
        public async Task<IActionResult> Details(int id)
        {
            var report = await _reportService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _reportService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }
            var model = new UpdateReportDTO
            {
                Id = report.Id,
                ProblemId = report.ProblemId,
                CommentId = report.CommentId,
                ReportReason = report.ReportReason,
                UserId = report.UserId,
                ReportedAt = report.ReportedAt
            };
            return View(model);
        }

        // Raporu silme işlemi
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _reportService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            await _reportService.DeleteReport(id);
            TempData["Success"] = "Rapor başarıyla silindi.";
            return RedirectToAction("Index");
        }


    }
}
