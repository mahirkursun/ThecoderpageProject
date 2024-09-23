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
            builder.HasOne(p => p.User)
                .WithMany(u => u.Problems)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Problem)
                .HasForeignKey(c => c.ProblemId);

            // Category relationship
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Problems)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
