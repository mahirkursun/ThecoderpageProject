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
    public class ProblemManager : IProblemService
    {
        private readonly IProblemRepository<Problem> _problemRepository;
        private readonly IMapper _mapper;

        public ProblemManager(IProblemRepository<Problem> problemRepository, IMapper mapper) 
        {
            _problemRepository = problemRepository;
            _mapper = mapper;

        }
        public Task Create(CreateProblemDTO model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProblemVM>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
