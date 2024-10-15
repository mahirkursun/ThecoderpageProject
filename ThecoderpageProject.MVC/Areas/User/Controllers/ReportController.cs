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

            Console.WriteLine($"ProblemId: {reportDTO.ProblemId}, UserId: {reportDTO.UserId}, ReportReason: {reportDTO.ReportReason}");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reportDTO.UserId = userId;




            // Report kaydını oluştur
            await _reportService.CreateReport(reportDTO);
            TempData["Success"] = "Rapor başarıyla oluşturuldu.";



            // Problem rapor edilmişse ProblemController'a yönlendir
            return RedirectToAction("Index", "Home", new { area = "" });
        }


    }
}
