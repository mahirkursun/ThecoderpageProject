using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;

namespace ThecoderpageProject.Application.Services.AbstractServices
{
    public interface IUserService
    {
        
        Task<UpdateUserDTO> GetUserById(string id);
        Task Update(UpdateUserDTO model);
        Task Delete(string id);
        Task<IEnumerable<UserVM>> GetAll();
        
    }
}
