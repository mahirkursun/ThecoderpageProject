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
    public class VoteConfig : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            // Table name
            builder.ToTable("Votes");

            // Primary Key
            builder.HasKey(v => v.Id);

            // Properties
            builder.Property(v => v.VoteType)
                .HasConversion<string>()
                .IsRequired();

            // Relationships
            builder.HasOne<Problem>() // Vote -> Problem
                .WithMany() // Bir Problem birden çok Oylama alabilir
                .HasForeignKey(v => v.ProblemId)
                .OnDelete(DeleteBehavior.Cascade); // Problem silindiğinde ilgili Oylamalar silinsin

            builder.HasOne<User>() // Vote -> User
                .WithMany() // Bir Kullanıcı birden çok Oylama yapabilir
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilgili Oylamalar silinsin
        }
    }
}
