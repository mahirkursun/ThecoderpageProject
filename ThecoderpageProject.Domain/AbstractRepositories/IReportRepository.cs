using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface IReportRepository<T> where T : Report
    {
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report> GetReportById(int id);
        Task CreateReport(Report report);
        Task DeleteReport(int id);

        Task<Report> GetReportByUserAndProblem(string userId, int problemId);
    }
}
