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
        private readonly IUserService _userService;

        public ReportController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        /*İncele*/
        public async Task<IActionResult> Index()
        {
            var reports = await _reportService.GetAllReports();
            foreach (var report in reports)
            {
                var user = await _userService.GetUserById(report.UserId);
               

                report.UserName = user?.UserName ?? string.Empty;
                

            }

            return View(reports);
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
