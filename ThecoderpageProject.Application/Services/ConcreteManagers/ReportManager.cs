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


        public Task Create(CreateReportDTO model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReportVM>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
