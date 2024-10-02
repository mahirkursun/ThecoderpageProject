using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;

namespace ThecoderpageProject.Application.Services.AbstractServices
{
    public interface IProblemService
    {
        Task Create(CreateProblemDTO model);

        Task Update(UpdateProblemDTO model);
        Task<UpdateProblemDTO> GetProblemById(int id);
        Task Delete(int id);

        Task<IEnumerable<ProblemVM>> GetAll(); 

    }
}
