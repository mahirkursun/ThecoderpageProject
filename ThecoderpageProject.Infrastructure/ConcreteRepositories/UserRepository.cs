using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using static ThecoderpageProject.Infrastructure.ConcreteRepositories.UserRepository;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{

    public class UserRepository : IUserRepository<User>
    {
        private readonly List<User> _users = new List<User>();

        public Task<User> CreateUser(User user)
        {
            _users.Add(user);
            return Task.FromResult(user);
        }

        public Task<User> DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.FromResult(user);
        }

        public Task<User> GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        public Task<User> UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username; // Update other properties as needed
                existingUser.Email = user.Email; // Example property
            }
            return Task.FromResult(existingUser);
        }
    }
}
