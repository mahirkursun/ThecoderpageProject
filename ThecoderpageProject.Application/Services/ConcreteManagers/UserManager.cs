﻿using AutoMapper;
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

        public async Task Create(CreateUserDTO user)
        {
            var newUser = _mapper.Map<User>(user);

            // Ekstra loglama
            Console.WriteLine($"Kullanıcı ekleniyor: {newUser.FirstName} {newUser.LastName}");

            await _userRepository.CreateUser(newUser);
            Console.WriteLine("Kullanıcı eklendi.");

        }

        public async Task Update(UpdateUserDTO userDTO)
        {
            var user = await _userRepository.GetUserById(userDTO.Id);
            if (user != null)
            {
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.Role = userDTO.Role;
                user.Username = userDTO.UserName;
                user.Email = userDTO.Email;
                // Şifre güncellemesi yapılacaksa, burada kontrol edilebilir:
                if (userDTO.Password != null) { user.Password = userDTO.Password; }



                await _userRepository.UpdateUser(user); // Kullanıcıyı güncelle
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

        public async Task<UpdateUserDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new ArgumentNullException($"User with ID {id} not found.");  // Kullanıcı yoksa hata
            }
            return _mapper.Map<UpdateUserDTO>(user);
        }
    }
}
