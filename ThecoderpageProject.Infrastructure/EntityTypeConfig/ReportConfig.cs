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
            builder.Property(r => r.ReportReason)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(r => r.ReportedAt)
                .IsRequired();


            // Relationships
            builder.HasOne<Problem>() // Report -> Problem
                .WithMany() // Bir Problem birden çok Rapor alabilir
                .HasForeignKey(r => r.ProblemId)
                .OnDelete(DeleteBehavior.Cascade); // Problem silindiğinde ilgili Raporlar silinsin


            builder.HasOne<AppUser>() // Report -> User
                .WithMany() // Bir Kullanıcı birden çok Rapor yazabilir
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilgili Raporlar silinsin
        }
    }
}
