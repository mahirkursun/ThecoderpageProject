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
        Task<T> CreateVote(T vote);
        Task<T> GetVoteById(int id);
        Task<IEnumerable<T>> GetVotes();
        Task<T> UpdateVote(T vote);
    }
}
