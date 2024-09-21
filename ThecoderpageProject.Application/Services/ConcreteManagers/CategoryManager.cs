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

        public Task Create(CreateCategoryDTO model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryVM>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateCategoryDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
