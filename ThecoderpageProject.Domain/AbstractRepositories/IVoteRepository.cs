using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface IVoteRepository<T> where T : Vote
    {
        Task AddVote(T vote);
        Task<T> GetVoteByUserIdAndProblemId(string userId, int problemId);
        Task RemoveVote(int voteId);
        Task UpdateVote(T vote);
    }
}
