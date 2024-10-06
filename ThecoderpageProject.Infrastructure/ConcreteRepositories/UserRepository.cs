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

    public class UserRepository : IUserRepository<AppUser>
    {
   

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        private  DbSet<AppUser> Users =>_context.Users; // Change this line
        public async Task<AppUser> CreateUser(AppUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<AppUser> DeleteUser(string id)
        {
            var user = await Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                await _context.SaveChangesAsync(); // Değişiklikleri kaydedin
            }
            return user;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            if (_context.Users == null) // Null kontrolü
            {
                throw new ArgumentNullException(nameof(_context.Users), "Users veritabanı tablosu null.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await Users.ToListAsync();
        }

        public async Task<AppUser> UpdateUser(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
