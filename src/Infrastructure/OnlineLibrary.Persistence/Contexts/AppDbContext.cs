using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=OnlineLibrary;Trusted_connection=True;TrustServerCertificate=True");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecuteAssembly());

        //    modelBuilder.Entity<Book>()
        //        .HasMany(c => c.Authors)
        //        .WithOne(p => p.Book)
        //        .HasForeignKey(p => p.BookId);

        //    modelBuilder
        //        .Entity<Book>()
        //        .HasIndex(p => p.Name)
        //        .IsUnique();
        //}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ReservedItem> ReservedItems { get; set; }


    }
}
