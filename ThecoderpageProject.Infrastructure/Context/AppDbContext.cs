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
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAHIR\\MSSQLSERVER03; Database=ThecoderpageDb; Uid=sa; Pwd=123; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Comment>()
                .HasOne(c => c.Problem)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProblemId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Report>()
                .HasOne(r => r.Problem)
                .WithMany(p => p.Reports)
                .HasForeignKey(r => r.ProblemId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Report>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Vote>()
                .HasOne(v => v.Problem)
                .WithMany(p => p.Votes)
                .HasForeignKey(v => v.ProblemId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            builder.Entity<Vote>()
                .HasOne(v => v.Comment)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.CommentId)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE NO ACTION

            //En altta kalsın.
            base.OnModelCreating(builder);
        }

    }
}
