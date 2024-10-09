using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Application.Services.ConcreteManagers
{
    public class ReportManager : IReportService
    {
        private readonly IReportRepository<Report> _reportRepository;
        private readonly IMapper _mapper;

        public ReportManager(IReportRepository<Report> reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task CreateReport(CreateReportDTO model)
        {
            var report = new Report
            {
                ProblemId = model.ProblemId,
                CommentId = model.CommentId,
                ReportReason = model.ReportReason,
                ReportedAt = DateTime.UtcNow,
                UserId = model.UserId
                
            };

            await _reportRepository.CreateReport(report);
        }
        public async Task DeleteReport(int id)
        {
            await _reportRepository.DeleteReport(id);
        }

        public  async Task<IEnumerable<ReportVM>> GetAllReports()
        {
            var reports = await _reportRepository.GetAllReports();
            return  _mapper.Map<IEnumerable<ReportVM>>(reports);

        }

        public async Task<Report> GetReportById(int id)
        {
            return await _reportRepository.GetReportById(id);
        }

      
    }
}
