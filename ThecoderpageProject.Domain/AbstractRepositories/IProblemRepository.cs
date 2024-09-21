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
        Task CreateProblem(T problem);
        Task GetProblemById(int id);
        Task<IEnumerable<T>> GetProblems();
        Task UpdateProblem(T problem);
        Task DeleteProblem(int id);

    }
}
