using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Enums;
using ThecoderpageProject.MVC.Models;

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

        public async Task<IActionResult> Index()
        {
            var reports = await _reportService.GetAllReports();
            var model = new UpdateProblemDTO
            {
                
                Reports = reports
            };

            return View(model);
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

            
            var existingReport = await _reportService.GetReportByUserAndProblem(userId, reportDTO.ProblemId.Value);
            if (existingReport != null)
            {
                TempData["Error"] = "Bu problemi daha önce rapor ettiniz.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            await _reportService.CreateReport(reportDTO);
            TempData["Success"] = "Rapor başarıyla oluşturuldu.";

            return RedirectToAction("Index", "Home", new { area = "", id = reportDTO.ProblemId });
        }


    }
}
