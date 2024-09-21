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
        Task<T> CreateReport(T report);
        Task<T> GetReportById(int id);
        Task<IEnumerable<T>> GetReports();
        Task<T> DeleteReport(int id);
    }
}
