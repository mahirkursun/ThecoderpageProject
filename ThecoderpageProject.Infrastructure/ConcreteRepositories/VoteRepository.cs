using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class VoteRepository : IVoteRepository<Vote>
    {
        //Düzenle
        private readonly List<Vote> _votes = new List<Vote>();

        public Task<Vote> CreateVote(Vote vote)
        {
            _votes.Add(vote);
            return Task.FromResult(vote);
        }

        public Task<Vote> GetVoteById(int id)
        {
            var vote = _votes.FirstOrDefault(v => v.Id == id);
            return Task.FromResult(vote);
        }

        public Task<IEnumerable<Vote>> GetVotes()
        {
            return Task.FromResult<IEnumerable<Vote>>(_votes);
        }

        public Task<Vote> UpdateVote(Vote vote)
        {
            var existingVote = _votes.FirstOrDefault(v => v.Id == vote.Id);
            if (existingVote != null)
            {
                existingVote.VoteType = vote.VoteType; // Update other properties as needed
                // Continue updating other relevant fields
            }
            return Task.FromResult(existingVote);
        }
    }
}
