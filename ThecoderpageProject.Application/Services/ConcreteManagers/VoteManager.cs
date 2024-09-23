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

        public async Task Create(CreateVoteDTO model)
        {
            var vote = _mapper.Map<Vote>(model);
            await _voteRepository.CreateVote(vote); // Asenkron isimlendirme
        }

        public async Task<IEnumerable<VoteVM>> GetAll()
        {
            var votes = await _voteRepository.GetVotes(); // Tüm oyları al
            return _mapper.Map<IEnumerable<VoteVM>>(votes); // VM'e dönüştür
        }
    }
}
