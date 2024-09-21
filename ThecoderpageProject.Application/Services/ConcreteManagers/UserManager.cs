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
    public class UserManager : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository<User> userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public Task Create(CreateUserDTO model)
        {
            throw new NotImplementedException();
        }
        public Task Update(UpdateUserDTO model) {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserVM>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserVM> GetFullName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
