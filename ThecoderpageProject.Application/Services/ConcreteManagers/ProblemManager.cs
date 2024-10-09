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

        public async Task Create(CreateProblemDTO model)
        {


            var problem = _mapper.Map<Problem>(model);
        
            await _problemRepository.CreateProblem(problem);
        }

        public async Task Update(UpdateProblemDTO problemDTO)
        {
            var problem = await _problemRepository.GetProblemById(problemDTO.Id);
            if (problem == null)
            {
                throw new KeyNotFoundException($"Problem with ID {problemDTO.Id} not found.");
            }
            problem.Title = problemDTO.Title;
            problem.Description = problemDTO.Description;
            problem.Status = problemDTO.Status;
            problem.CreatedAt = problemDTO.CreatedAt;
            problem.UserId = problemDTO.UserId;
            problem.CategoryId = problemDTO.CategoryId;
            await _problemRepository.UpdateProblem(problem);
        }
        public async Task<UpdateProblemDTO> GetProblemById(int id)
        {
            var problem = await _problemRepository.GetProblemById(id);
            if (problem == null)
            {
                throw new KeyNotFoundException($"Problem with ID {id} not found.");
            }
            return _mapper.Map<UpdateProblemDTO>(problem);

        }

        public async Task Delete(int id)
        {
            var problem = await _problemRepository.GetProblemById(id);
            if (problem != null)
            {
                await _problemRepository.DeleteProblem(problem.Id);
            }
            else
            {
                throw new KeyNotFoundException($"Problem with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<ProblemVM>> GetAll()
        {
            var problems = await _problemRepository.GetProblems();
            return _mapper.Map<IEnumerable<ProblemVM>>(problems);
        }

        public Task<IEnumerable<ProblemVM>> GetProblemsByCategory(int categoryId)
        {
            var problems = _problemRepository.GetProblems().Result.Where(x => x.CategoryId == categoryId);
            return Task.FromResult(_mapper.Map<IEnumerable<ProblemVM>>(problems));


        }
    }
}