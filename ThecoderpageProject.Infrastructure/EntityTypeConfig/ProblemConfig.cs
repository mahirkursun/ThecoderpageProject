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
    public class ProblemConfig : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            // Table name
            builder.ToTable("Problems");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(p => p.Status)
                .HasConversion<string>();

            // Relationships
            builder.HasOne<User>() // Problem -> User
                .WithMany() // Bir Kullanıcı birden çok Problem oluşturabilir
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilgili Problemler silinsin

            builder.HasOne<Category>() // Problem -> Category
                .WithMany() // Bir Kategori birden çok Problem içerebilir
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Kategori silindiğinde ilgili Problemleri de sil
        }
    }


}
