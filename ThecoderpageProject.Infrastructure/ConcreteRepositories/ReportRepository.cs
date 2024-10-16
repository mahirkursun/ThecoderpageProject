using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.Context;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class ReportRepository : IReportRepository<Report>
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateReport(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteReport(int id)
        {
            var report = _context.Reports.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
           
        }

        public async Task<Report> GetReportById(int id)
        {
            return await  _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
           
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> GetReportByUserAndProblem(string userId, int problemId)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.UserId == userId && r.ProblemId == problemId);
        }
    }
}
