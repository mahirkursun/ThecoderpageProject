using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Application.Services.AbstractServices
{
    public interface IReportService
    {
        Task<IEnumerable<ReportVM>> GetAllReports();
        Task<Report> GetReportById(int id);
        Task CreateReport(CreateReportDTO model);
        Task DeleteReport(int id);
    }
}
