using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class ReportRepository : IReportRepository<Report>
    {
        private readonly List<Report> _reports = new List<Report>();

        public Task<Report> CreateReport(Report report)
        {
            _reports.Add(report);
            return Task.FromResult(report);
        }

        public Task<Report> DeleteReport(int id)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                _reports.Remove(report);
            }
            return Task.FromResult(report);
        }

        public Task<Report> GetReportById(int id)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(report);
        }

        public Task<IEnumerable<Report>> GetReports()
        {
            return Task.FromResult<IEnumerable<Report>>(_reports);
        }
    }
}
