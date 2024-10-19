using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Problem> Problems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAHIR\\MSSQLSERVER03; Database=ThecoderpageDb; Uid=sa; Pwd=123; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Default categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "NET" },
                new Category { Id = 2, Name = "Csharp" },
                new Category { Id = 3, Name = "HTML" },
                new Category { Id = 4, Name = "CSS" },
                new Category { Id = 5, Name = "Javascript" },
                new Category { Id = 6, Name = "Java" },
                new Category { Id = 7, Name = "React" },
                new Category { Id = 8, Name = "C++" },
                new Category { Id = 9, Name = "Python" },
                new Category { Id = 10, Name = "Angular" }
            );

            // Default admin user
            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<AppUser>();
            
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = adminUserId,
                    UserName = "mahirkursun",
                    NormalizedUserName = "MAHIRKURSUN",
                    Email = "mahirkrsn@gmail.com",
                    NormalizedEmail = "MAHIRKRSN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "Mhr.123"),
                    SecurityStamp = string.Empty,
                    FirstName = "Mahir",
                    LastName = "Kurşun",
                    Role = UserRole.Admin
                }
            );


            // AppUser'daki Role özelliğini string olarak saklıyoruz
            builder.Entity<AppUser>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // IdentityRole verilerini ekliyoruz
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );

            // Diğer model yapılandırmaları burada yapılabilir

            // En altta kalsın
            base.OnModelCreating(builder);
        }

    }
}
