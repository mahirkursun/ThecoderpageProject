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

        public async Task Create(CreateUserDTO model)
        {
            var user = _mapper.Map<User>(model);
            await _userRepository.CreateUser(user); // Asenkron isimlendirme
        }

        public async Task Update(UpdateUserDTO model)
        {
            var user = await _userRepository.GetUserById(model.Id); // Kullanıcıyı ID ile bul
            if (user != null)
            {
                _mapper.Map(model, user); // DTO'dan mevcut kullanıcıya verileri kopyala
                await _userRepository.UpdateUser(user); // Güncelle
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {model.Id} not found."); // Hata mesajı
            }
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetUserById(id); // Kullanıcıyı ID ile bul
            if (user != null)
            {
                await _userRepository.DeleteUser(user.Id); // Sil
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {id} not found."); // Hata mesajı
            }
        }

        public async Task<IEnumerable<UserVM>> GetAll()
        {
            var users = await _userRepository.GetUsers(); // Tüm kullanıcıları al
            return _mapper.Map<IEnumerable<UserVM>>(users); // VM'e dönüştür
        }

       
    }
}
