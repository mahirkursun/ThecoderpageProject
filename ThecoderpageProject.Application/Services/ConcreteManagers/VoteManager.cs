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
        public Task Create(CreateVoteDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VoteVM>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
