using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Data;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
        public IActionResult Create(int problemId)
        {

            var model = new CreateReportDTO
            {
                ProblemId = problemId
             
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReportDTO reportDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reportDTO.UserId = userId;

        
            

            // Report kaydını oluştur
            await _reportService.CreateReport(reportDTO);
            TempData["Success"] = "Rapor başarıyla oluşturuldu.";

            

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
