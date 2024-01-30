using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /*
        Завдання 3*
        Продовжуйте завданя 2 (цього уроку).
        Спробуйте налаштувати все без застосування DataAnnotations.
        Частіше Ви будете зустрічати налаштування через Fluent API (Приклад), тому варто вміти реалізовувати двома способами.
 */
    public class ContextApp : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=HomeTaskFirst; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorConfiguration());
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).HasColumnName("Product_Id");
            builder.Property(p => p.Name).HasMaxLength(80);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Created).HasColumnType("Date");
            builder.Ignore(p => p.Error);
        }
    }

    public class ErrorConfiguration : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.HasAlternateKey(e => e.AlterId);
            builder.Property(p => p.AlterId).HasColumnName("Error_AlternativeId");  
        }
    }
}
