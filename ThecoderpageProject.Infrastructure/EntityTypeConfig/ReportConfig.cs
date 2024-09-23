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
    public class ReportConfig : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            // Table name
            builder.ToTable("Reports");

            // Primary Key
            builder.HasKey(r => r.Id);

            // Properties
            builder.Property(r => r.Reason)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(r => r.ReportReason)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(r => r.ReportedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(r => r.Problem)
                .WithMany(p => p.Reports)
                .HasForeignKey(r => r.ProblemId);

            builder.HasOne(r => r.Comment)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CommentId);
        }
    }
}
