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
    public interface IVoteService
    {
        Task<Vote> GetVoteByUserIdAndProblemId(int userId, int problemId);
        Task AddVote(Vote vote);
        Task UpdateVote(Vote vote);
        Task RemoveVote(int voteId);
    }
}
