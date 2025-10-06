using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                   .HasColumnName("AuthorName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Surname)
                   .HasColumnName("AuthorSurname")
                   .HasMaxLength(100);

            builder.Property(a => a.Gender)
                   .HasConversion<int>() 
                   .IsRequired();

            builder.HasMany(a => a.Books)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(a => new { a.Name, a.Surname })
                   .IsUnique();
        }
    }
}
