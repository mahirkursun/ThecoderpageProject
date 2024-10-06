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
    public class VoteRepository : IVoteRepository<Vote>
    {

        private readonly AppDbContext _context;

        public VoteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddVote(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
        }

        public async Task<Vote> GetVoteByUserIdAndProblemId(string userId, int problemId)
        {
            return await _context.Votes.FirstOrDefaultAsync(v => v.UserId == userId && v.ProblemId == problemId);
        }

        

        public async Task RemoveVote(int voteId)
        {
            var vote = await _context.Votes.FindAsync(voteId);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
                await _context.SaveChangesAsync();
            }
        }

        public Task UpdateVote(Vote vote)
        {
            _context.Votes.Update(vote);
            return _context.SaveChangesAsync();
        }
    }
}
