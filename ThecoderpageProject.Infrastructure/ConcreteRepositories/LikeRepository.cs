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
    public class LikeRepository : ILikeRepository<Like>
    {
        private readonly AppDbContext _context;

        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddLike(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> GetAllLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task<Like> GetLikeById(int id)
        {
            return await _context.Likes.FindAsync(id);
        }

        public async Task<Like> GetLikeByUserIdAndProblemId(string userId, int problemId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ProblemId == problemId);
        }

        public async Task<IEnumerable<Like>> GetLikesByProblemId(int problemId)
        {
            return await _context.Likes
                .Where(l => l.ProblemId == problemId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Like>> GetLikesByUserId(string userId)
        {
            return await _context.Likes
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }


        public async Task RemoveLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveLikeByUserIdAndProblemId(string userId, int problemId)
        {
            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ProblemId == problemId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLike(Like like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
        }
    }
}
