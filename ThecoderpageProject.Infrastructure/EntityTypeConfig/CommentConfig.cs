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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Table name
            builder.ToTable("Comments");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(500);

            // Relationships
            builder.HasOne<Problem>() // Comment -> Problem
                .WithMany() // Bir Problem birden çok Yorum alabilir
                .HasForeignKey(c => c.ProblemId)
                .OnDelete(DeleteBehavior.Cascade); // Problem silindiğinde ilgili Yorumlar silinsin

            builder.HasOne<AppUser>() // Comment -> User
                .WithMany() // Bir Kullanıcı birden çok Yorum yazabilir
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silindiğinde ilgili Yorumlar silinmesin
        }
    }
}
