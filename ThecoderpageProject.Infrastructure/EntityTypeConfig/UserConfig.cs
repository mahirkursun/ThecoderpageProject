using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Infrastructure.EntityTypeConfig
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Role)
                .HasConversion<string>()
                .IsRequired();

            // Relationships
            builder.HasMany<Problem>() // User -> Problems
                .WithOne() // Bir Kullanıcı birden çok Problem oluşturabilir
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilgili Problemler silinsin

            builder.HasMany<Comment>() // User -> Comments
                .WithOne() // Bir Kullanıcı birden çok Yorum yapabilir
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silindiğinde ilgili Yorumlar silinsin

            builder.HasMany<Report>() // User -> Reports
                .WithOne() // Bir Kullanıcı birden çok Rapor yazabilir
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilgili Raporlar silinsin

            
        }
    }
}
