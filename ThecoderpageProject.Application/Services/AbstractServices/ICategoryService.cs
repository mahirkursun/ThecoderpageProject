using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Application.Services.AbstractServices
{
    public interface ICategoryService
    {
        Task Create(CreateCategoryDTO model);
        Task<UpdateCategoryDTO> GetCategoryById(int id);
        Task Update(UpdateCategoryDTO model);
        Task Delete(int id);

        Task<IEnumerable<CategoryVM>> GetCategories();

    }
}
