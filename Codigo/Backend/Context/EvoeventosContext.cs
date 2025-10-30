using BackEvoEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Context
{
    public class EvoeventosContext : DbContext
    {
        public EvoeventosContext(DbContextOptions<EvoeventosContext> options) : base(options)
        { 
        }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoggingType> LoggingTypes { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(5).HasColumnName("Abbreviation");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdateAt");
                entity.ToTable("DocumentType");
            });
        }
    }
}
