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
    public class ReservedItemConfiguration : IEntityTypeConfiguration<ReservedItem>
    {
        public void Configure(EntityTypeBuilder<ReservedItem> builder)
        {
            builder.ToTable("ReservedItems");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.FinCode)
                   .HasColumnName("FinCode")
                   .HasMaxLength(7)
                   .IsRequired();

            builder.Property(r => r.StartDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(r => r.EndDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(r => r.Status)
                   .HasConversion<int>() 
                   .IsRequired();

            builder.HasOne(r => r.Book)
                   .WithMany(b => b.ReservedItems)
                   .HasForeignKey(r => r.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => r.FinCode)
                   .IsUnique();
        }
    }

}  
