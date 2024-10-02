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
    public class VoteManager : IVoteService
    {
        private readonly IVoteRepository<Vote> _voteRepository;
        private readonly IMapper _mapper;

        public VoteManager(IVoteRepository<Vote> voteRepository, IMapper mapper)
        {
            _voteRepository = voteRepository;
            _mapper = mapper;
        }

        public async Task AddVote(Vote vote)
        {
            await _voteRepository.AddVote(vote);
        }

        public async Task<Vote> GetVoteByUserIdAndProblemId(int userId, int problemId)
        {
            return await _voteRepository.GetVoteByUserIdAndProblemId(userId, problemId);
        }

        public async Task RemoveVote(int voteId)
        {
            await _voteRepository.RemoveVote(voteId);
        }

        public async Task UpdateVote(Vote vote)
        {
            await _voteRepository.UpdateVote(vote);
        }

       
    }
}
