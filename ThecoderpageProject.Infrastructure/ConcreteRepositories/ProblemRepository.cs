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
    public class ProblemRepository : IProblemRepository<Problem>
    {
        private readonly AppDbContext _context;

        public ProblemRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Problem> Problems => _context.Problems;

        public async Task<Problem> CreateProblem(Problem problem)
        {
            
            await Problems.AddAsync(problem);
            await _context.SaveChangesAsync();
            return problem;


        }

        public async Task<Problem> UpdateProblem(Problem problem)
        {
            _context.Problems.Update(problem);
            await _context.SaveChangesAsync();
            return problem;
        }

        public async Task<Problem> DeleteProblem(int id)
        {
            var problem = await Problems.FirstOrDefaultAsync(p => p.Id == id);
            if (problem != null)
            {
                Problems.Remove(problem);
                await _context.SaveChangesAsync();
            }
            return problem;
        }

        public async Task<Problem> GetProblemById(int id)
        {
            if (_context.Problems == null)
            {
                throw new ArgumentNullException(nameof(_context.Problems), "Problems database table is null.");
            }
            var problem = await _context.Problems.FirstOrDefaultAsync(p => p.Id == id);
            return problem;
        }

        public async Task<IEnumerable<Problem>> GetProblems()
        {
            return await Problems.ToListAsync();
        }



    }
}