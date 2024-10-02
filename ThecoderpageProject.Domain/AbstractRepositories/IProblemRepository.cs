using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface IProblemRepository<T> where T : Problem
    {
        Task<T> CreateProblem(T problem);
        Task<T> UpdateProblem(T problem);
        Task<T> GetProblemById(int id);
        Task<IEnumerable<T>> GetProblems();
        Task<T> DeleteProblem(int id);

    }
}
