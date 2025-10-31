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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Names).IsRequired().HasMaxLength(60).HasColumnName("Name");
                entity.Property(e => e.Surnames).IsRequired().HasMaxLength(50).HasColumnName("Surnames");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50).HasColumnName("Email");
                entity.Property(e => e.IdDocumentType).IsRequired().HasColumnName("IdDocumentType");
                entity.Property(e => e.DocumentNumber).IsRequired().HasMaxLength(12).HasColumnName("DocumentNumber");
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(14).HasColumnName("Phone");
                entity.Property(e => e.Address).HasMaxLength(100).HasColumnName("Address");
                entity.Property(e => e.IdRole).IsRequired().HasColumnName("IdRole");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdateAt");
                entity.HasOne(e => e.DocumentType)
                      .WithMany(t => t.Users)
                      .HasForeignKey(e => e.IdDocumentType);
                entity.HasOne(e => e.Role)
                      .WithMany(t => t.Users)
                      .HasForeignKey(e => e.IdRole);
                entity.ToTable("User");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(5).HasColumnName("Abbreviation");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdateAt");
                entity.ToTable("CustomerType");
            });

            modelBuilder.Entity<LoggingType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdateAt");
                entity.ToTable("LoggingType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdateAt");
                entity.ToTable("Role");
            });



        }
}   }
