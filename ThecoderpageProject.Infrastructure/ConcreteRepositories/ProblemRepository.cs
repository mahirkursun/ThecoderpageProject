using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class ProblemRepository : IProblemRepository<Problem>
    {
        public ProblemRepository() { }
        private readonly List<Problem> _problems = new List<Problem>();

        public Task CreateProblem(Problem problem)
        {
            _problems.Add(problem);
            return Task.CompletedTask;
        }

        public Task DeleteProblem(int id)
        {
            var problem = _problems.FirstOrDefault(p => p.Id == id);
            if (problem != null)
            {
                _problems.Remove(problem);
            }
            return Task.CompletedTask;
        }

        public Task<Problem> GetProblemById(int id)
        {
            var problem = _problems.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(problem);
        }

        public Task<IEnumerable<Problem>> GetProblems()
        {
            return Task.FromResult<IEnumerable<Problem>>(_problems);
        }

        public Task UpdateProblem(Problem problem)
        {
            var existingProblem = _problems.FirstOrDefault(p => p.Id == problem.Id);
            if (existingProblem != null)
            {
                existingProblem.Title = problem.Title; // Update other properties as needed
                existingProblem.Description = problem.Description; // Example property
                                                                   // Continue updating other relevant fields
            }
            return Task.CompletedTask;
        }

        Task IProblemRepository<Problem>.GetProblemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
