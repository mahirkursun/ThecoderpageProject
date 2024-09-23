using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class CommentRepository : ICommentRepository<Comment>
    {
        private readonly List<Comment> _comments = new List<Comment>();

        public Task<Comment> CreateComment(Comment comment)
        {
            _comments.Add(comment);
            return Task.FromResult(comment);
        }

        public Task<Comment> DeleteComment(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _comments.Remove(comment);
            }
            return Task.FromResult(comment);
        }

        public Task<Comment> GetCommentById(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(comment);
        }

        public Task<IEnumerable<Comment>> GetComments()
        {
            return Task.FromResult<IEnumerable<Comment>>(_comments);
        }

        public Task<Comment> UpdateComment(Comment comment)
        {
            var existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
            if (existingComment != null)
            {
                existingComment.Content = comment.Content; // Update other properties as needed
                // Continue updating other relevant fields
            }
            return Task.FromResult(existingComment);
        }
    }
}
