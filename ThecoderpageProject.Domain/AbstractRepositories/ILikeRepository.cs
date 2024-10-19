using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface ILikeRepository<T> where T : Like
    {
        Task AddLike(T like); // Düzeltilmiş metod imzası
        Task UpdateLike(T like); // Düzeltilmiş metod imzası
        Task<T> GetLikeById(int id);
        Task<IEnumerable<T>> GetAllLikes();
        Task<T> GetLikeByUserIdAndProblemId(string userId, int problemId);
        Task<IEnumerable<T>> GetLikesByProblemId(int problemId);
        Task<IEnumerable<T>> GetLikesByUserId(string userId);
        Task RemoveLike(int id); // Düzeltilmiş metod imzası
        Task RemoveLikeByUserIdAndProblemId(string userId, int problemId);
    }

}

