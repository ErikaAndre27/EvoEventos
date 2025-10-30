using BackEvoEventos.Models;
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

            });
        }
    }
}
