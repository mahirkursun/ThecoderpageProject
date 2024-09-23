using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(CreateReportDTO model)
        {
            var report = _mapper.Map<Report>(model);
            await _reportRepository.CreateReport(report); 
        }

        public async Task Delete(int id)
        {
            var report = await _reportRepository.GetReportById(id); 
            if (report != null)
            {
                await _reportRepository.DeleteReport(report.Id);
            }
            else
            {
                throw new KeyNotFoundException($"Report with ID {id} not found."); 
            }
        }

        public async Task<IEnumerable<ReportVM>> GetAll()
        {
            var reports = await _reportRepository.GetReports();
            return _mapper.Map<IEnumerable<ReportVM>>(reports); 
        }
    }
}
