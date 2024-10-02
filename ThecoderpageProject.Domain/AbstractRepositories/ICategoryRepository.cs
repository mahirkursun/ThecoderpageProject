using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface ICategoryRepository<T> where T : Category
    {
        Task<T> CreateCategory(T category);
        Task<T> GetCategoryById(int id);
        Task<T> UpdateCategory(T category);
        Task<IEnumerable<T>> GetCategories();
        Task<T> DeleteCategory(int id);
    }
}
