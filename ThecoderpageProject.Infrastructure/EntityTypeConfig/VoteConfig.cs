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
    public class VoteConfig: IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            // Table name
            builder.ToTable("Votes");

            // Primary Key
            builder.HasKey(v => v.Id);

            // Properties
            builder.Property(v => v.IsUpvote)
                .IsRequired();

            builder.Property(v => v.VoteType)
                .HasConversion<string>()
                .IsRequired();

            // Relationships
            builder.HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId);

            builder.HasOne(v => v.Problem)
                .WithMany(p => p.Votes)
                .HasForeignKey(v => v.ProblemId);

            builder.HasOne(v => v.Comment)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.CommentId);
        }
    }
}
