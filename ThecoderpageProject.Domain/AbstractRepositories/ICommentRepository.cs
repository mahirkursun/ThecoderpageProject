using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface ICommentRepository<T> where T : Comment
    {
        Task<T> CreateComment(T comment);
        Task<T> GetCommentById(int id);
        Task<IEnumerable<T>> GetComments();
        Task<T> UpdateComment(T comment);
        Task<T> DeleteComment(int id);
    }
}
