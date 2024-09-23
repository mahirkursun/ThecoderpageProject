using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        private readonly List<Category> _categories = new List<Category>();

        public Task<Category> CreateCategory(Category category)
        {
            _categories.Add(category);
            return Task.FromResult(category);
        }

        public Task<Category> DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            return Task.FromResult(category);
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            return Task.FromResult<IEnumerable<Category>>(_categories);
        }

        public Task<Category> GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(category);
        }

        public Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name; // Update other properties as needed
                // Continue updating other relevant fields
            }
            return Task.FromResult(existingCategory);
        }
    }
}
