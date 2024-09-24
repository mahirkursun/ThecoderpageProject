using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.Context;
using static ThecoderpageProject.Infrastructure.ConcreteRepositories.UserRepository;

namespace ThecoderpageProject.Infrastructure.ConcreteRepositories
{

    public class UserRepository : IUserRepository<User>
    {
   

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        private  DbSet<User> Users =>_context.Users; // Change this line
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> DeleteUser(int id)
        {
            var user = await Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                await _context.SaveChangesAsync(); // Değişiklikleri kaydedin
            }
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            if (_context.Users == null) // Null kontrolü
            {
                throw new ArgumentNullException(nameof(_context.Users), "Users veritabanı tablosu null.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
