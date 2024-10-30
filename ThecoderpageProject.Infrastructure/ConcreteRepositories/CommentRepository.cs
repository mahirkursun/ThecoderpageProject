using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.Context;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class CommentRepository : ICommentRepository<Comment>
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Comment> Comments => _context.Comments;


        //Düzenle
        public async Task<Comment> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            var comment = await Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment != null)
            {
                Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            if(_context.Comments == null)
            {
                throw new KeyNotFoundException($"Comment with ID {id} not found.");
            }
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await Comments.ToListAsync();
        }

        
    }
}
