using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.Context;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Category> Categories => _context.Categories;

        public async Task<Category> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }

        

        public async Task<Category> GetCategoryById(int id)
        {
            if(_context.Categories == null)
            {
                throw new ArgumentNullException(nameof(_context.Categories), "Categories database table is null.");
            }
            var category =await  _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

       
        

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {

            return await _context.Categories.ToListAsync();

        }


    }
}
