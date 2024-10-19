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
    public interface ILikeService
    {
        Task<IEnumerable<LikeVM>> GetLikeByProblemId(int problemId);
        Task<IEnumerable<LikeVM>> GetAllLikes();
        Task CreateLike(CreateLikeDTO model);
        Task UpdateLike(UpdateLikeDTO model);
        Task DeleteLike(int problemId);
    }
}
