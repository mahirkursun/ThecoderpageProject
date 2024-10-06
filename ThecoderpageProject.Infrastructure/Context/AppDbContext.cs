using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Problem> Problems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAHIR\\MSSQLSERVER03; Database=ThecoderpageDb; Uid=sa; Pwd=123; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
