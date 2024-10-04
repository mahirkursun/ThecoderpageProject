using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Application.Services.ConcreteManagers
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateCategory(category);
        }
        public async Task Update(UpdateCategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetCategoryById(categoryDTO.Id); // Fix for CS1061: Use GetCategoryById instead of GetByIdAsync
            if (category != null)
            {
                category.Name = categoryDTO.Name;
                await _categoryRepository.UpdateCategory(category);
            }
            else
            {
                throw new KeyNotFoundException("Category not found");
            }
        }
        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category != null)
            {
                await _categoryRepository.DeleteCategory(category.Id);
            }
            else
            {
                throw new KeyNotFoundException("Category not found");
            }
        }

        


        public async Task<UpdateCategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            return _mapper.Map<UpdateCategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryVM>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryVM>>(categories);

        }
    }

}
