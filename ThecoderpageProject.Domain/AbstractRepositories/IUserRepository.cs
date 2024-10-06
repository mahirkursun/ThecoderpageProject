using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Domain.AbstractRepositories
{
    public interface IUserRepository<T> where T : AppUser
    {
        Task<T> CreateUser(T user);
        Task<T> GetUserById(string id);
        Task<IEnumerable<T>> GetUsers();
        Task<T> UpdateUser(T user);
        Task<T> DeleteUser(string id);
    }
}
