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
            //builder
            //    .Property(p => p.Name)
            //    .HasColumnName("AuthorName")
            //    .HasMaxLength(100)
            //    .IsRequired();

            ////builder
            ////    .Property(p => p.Price)
            ////    .HasColumnType("decimal(6,2)")
            ////    .IsRequired();

            //builder
            //    .HasKey(p => p.Id);

            //builder
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();


            //builder
            //   .HasIndex(p => p.Name)
            //   .IsUnique();

            ////builder
            ////    .HasMany(c => c.Authors)
            ////    .WithOne(p => p.Book)
            ////    .HasForeignKey(p => p.BookId);

            //builder
            //    .HasIndex(p => p.Name)
            //    .IsUnique();
        }

    }
}
