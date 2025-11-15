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

        // Entidades existentes
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoggingType> LoggingTypes { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Entidades añadidas (servicios, recursos, cotizaciones, reservas, pagos, requests, reports, logs, estados, detalles...)
        public DbSet<Service> Services { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ServiceResource> ServiceResources { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<CategoryResource> CategoryResources { get; set; }
        public DbSet<PricingUnit> PricingUnits { get; set; }

        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<StatusQuotation> StatusQuotations { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }
        public DbSet<StatusReservation> StatusReservations { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<StatusPayment> StatusPayments { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<StatusRequest> StatusRequests { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<TargetObject> TargetObjects { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }

        public DbSet<StatusTransaction> StatusTransactions { get; set; }
        public DbSet<StatusResource> StatusResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -------------------------
            // Entidades ya existentes
            // -------------------------
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(5).HasColumnName("Abbreviation");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
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
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.HasOne(e => e.DocumentType)
                      .WithMany(t => t.Users)
                      .HasForeignKey(e => e.IdDocumentType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Role)
                      .WithMany(t => t.Users)
                      .HasForeignKey(e => e.IdRole)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("User");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(5).HasColumnName("Abbreviation");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.ToTable("CustomerType");
            });

            modelBuilder.Entity<LoggingType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.ToTable("LoggingType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdDocumentType).IsRequired().HasColumnName("IdDocumentType");
                entity.Property(e => e.DocumentNumber).IsRequired().HasColumnName("DocumentNumber");
                entity.Property(e => e.IdCustomerType).IsRequired().HasColumnName("IdCustomerType");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50).HasColumnName("Email");
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(14).HasColumnName("Phone");
                entity.Property(e => e.Address).HasMaxLength(100).HasColumnName("Address");
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.Notes).HasMaxLength(100).HasColumnName("Notes");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.HasOne(e => e.DocumentType)
                      .WithMany(t => t.Customers)
                      .HasForeignKey(e => e.IdDocumentType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.CustomerType)
                      .WithMany(t => t.Customers)
                      .HasForeignKey(e => e.IdCustomerType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Customer");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).IsRequired().HasColumnName("IdUser");
                entity.Property(e => e.IdLoggingType).IsRequired().HasColumnName("IdLoggingType");
                entity.Property(e => e.Identifier).IsRequired().HasMaxLength(50).HasColumnName("Identifier");
                entity.Property(e => e.Password).IsRequired().HasColumnName("Password");
                entity.Property(e => e.LastLogin).IsRequired().HasColumnName("LastLogin");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAT");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.HasOne(e => e.User)
                      .WithMany(t => t.Credential)
                      .HasForeignKey(e => e.IdUser)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.LoggingType)
                      .WithMany(t => t.Credentials)
                      .HasForeignKey(e => e.IdLoggingType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Credential");
            });

            // -------------------------
            // Nuevas entidades y configuración Fluent API
            // -------------------------
            modelBuilder.Entity<CategoryService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("CategoryService");
            });

            modelBuilder.Entity<CategoryResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("CategoryResource");
            });

            modelBuilder.Entity<PricingUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("PricingUnit");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.IdCategoryService).HasColumnName("IdCategoryService");
                entity.Property(e => e.IdPricingUnit).HasColumnName("IdPricingUnit");
                entity.HasOne(e => e.CategoryService)
                      .WithMany(c => c.Services)
                      .HasForeignKey(e => e.IdCategoryService)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.PricingUnit)
                      .WithMany(p => p.Services)
                      .HasForeignKey(e => e.IdPricingUnit)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Service");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.Property(e => e.IdCategoryResource).HasColumnName("IdCategoryResource");
                entity.HasOne(e => e.CategoryResource)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(e => e.IdCategoryResource)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Resource");
            });

            modelBuilder.Entity<ServiceResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.IdResource).IsRequired().HasColumnName("IdResource");
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.ServiceResources)
                      .HasForeignKey(e => e.IdService)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Resource)
                      .WithMany(r => r.ServiceResources)
                      .HasForeignKey(e => e.IdResource)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.ToTable("ServiceResource");
            });

            modelBuilder.Entity<StatusQuotation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusQuotation");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdCustomer).IsRequired().HasColumnName("IdCustomer");
                entity.Property(e => e.IdStatusQuotation).HasColumnName("IdStatusQuotation");
                entity.Property(e => e.EventDate).IsRequired();
                entity.Property(e => e.Guests).IsRequired();
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Customer)
                      .WithMany()
                      .HasForeignKey(e => e.IdCustomer)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.StatusQuotation)
                      .WithMany(s => s.Quotations)
                      .HasForeignKey(e => e.IdStatusQuotation)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Quotation");
            });

            modelBuilder.Entity<QuotationDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdQuotation).IsRequired().HasColumnName("IdQuotation");
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Quotation)
                      .WithMany(q => q.Details)
                      .HasForeignKey(e => e.IdQuotation)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.QuotationDetails)
                      .HasForeignKey(e => e.IdService)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("QuotationDetail");
            });

            modelBuilder.Entity<StatusReservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusReservation");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdQuotation).HasColumnName("IdQuotation");
                entity.Property(e => e.IdCustomer).IsRequired().HasColumnName("IdCustomer");
                entity.Property(e => e.IdStatusReservation).HasColumnName("IdStatusReservation");
                entity.Property(e => e.ReservationCode).HasMaxLength(30);
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Quotation)
                      .WithMany()
                      .HasForeignKey(e => e.IdQuotation)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.Customer)
                      .WithMany()
                      .HasForeignKey(e => e.IdCustomer)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.StatusReservation)
                      .WithMany(s => s.Reservations)
                      .HasForeignKey(e => e.IdStatusReservation)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Reservation");
            });

            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdReservation).IsRequired().HasColumnName("IdReservation");
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Reservation)
                      .WithMany(r => r.ReservationServices)
                      .HasForeignKey(e => e.IdReservation)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.ReservationServices)
                      .HasForeignKey(e => e.IdService)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("ReservationService");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("PaymentMethod");
            });

            modelBuilder.Entity<StatusPayment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusPayment");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdReservation).IsRequired().HasColumnName("IdReservation");
                entity.Property(e => e.IdPaymentMethod).IsRequired().HasColumnName("IdPaymentMethod");
                entity.Property(e => e.IdStatusPayment).HasColumnName("IdStatusPayment");
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.HasOne(e => e.Reservation)
                      .WithMany(r => r.Payments)
                      .HasForeignKey(e => e.IdReservation)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.PaymentMethod)
                      .WithMany(p => p.Payments)
                      .HasForeignKey(e => e.IdPaymentMethod)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.StatusPayment)
                      .WithMany(s => s.Payments)
                      .HasForeignKey(e => e.IdStatusPayment)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Payment");
            });

            // Requests / RequestDetails
            modelBuilder.Entity<StatusRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusRequest");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Abbreviation).HasMaxLength(10);
                entity.ToTable("EventType");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).IsRequired().HasColumnName("IdUser");
                entity.Property(e => e.IdStatusRequest).HasColumnName("IdStatusRequest");
                entity.Property(e => e.IdEventType).HasColumnName("IdEventType");
                entity.Property(e => e.Title).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.RequestedAt).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Requests) // corregido: usa la colección inversa Requests en User
                      .HasForeignKey(e => e.IdUser)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.StatusRequest)
                      .WithMany(s => s.Requests)
                      .HasForeignKey(e => e.IdStatusRequest)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.EventType)
                      .WithMany()
                      .HasForeignKey(e => e.IdEventType)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Request");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdRequest).IsRequired().HasColumnName("IdRequest");
                entity.Property(e => e.IdService).HasColumnName("IdService");
                entity.Property(e => e.IdResource).HasColumnName("IdResource");
                entity.Property(e => e.Quantity).IsRequired().HasDefaultValue(1);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Notes).HasMaxLength(400);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt);
                entity.HasOne(e => e.Request)
                      .WithMany(r => r.Details) // ahora usa la colección inversa
                      .HasForeignKey(e => e.IdRequest)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Service)
                      .WithMany()
                      .HasForeignKey(e => e.IdService)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Resource)
                      .WithMany()
                      .HasForeignKey(e => e.IdResource)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("RequestDetail");
            });

            // Reports
            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.ToTable("ReportType");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdReportType).IsRequired().HasColumnName("IdReportType");
                entity.Property(e => e.Title).HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.GeneratedAt).IsRequired();
                entity.Property(e => e.ContentUrl).HasMaxLength(400);
                entity.HasOne(e => e.ReportType)
                      .WithMany(rt => rt.Reports)
                      .HasForeignKey(e => e.IdReportType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Report");
            });

            // Logs
            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(80);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("ActionType");
            });

            modelBuilder.Entity<TargetObject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TableName).HasMaxLength(100);
                entity.ToTable("TargetObject");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.IdActionType).HasColumnName("IdActionType");
                entity.Property(e => e.IdTargetObject).HasColumnName("IdTargetObject");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.ReferenceId).HasMaxLength(100);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Logs) // ahora usa la colección inversa en User
                      .HasForeignKey(e => e.IdUser)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.ActionType)
                      .WithMany(a => a.Logs)
                      .HasForeignKey(e => e.IdActionType)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.TargetObject)
                      .WithMany(t => t.Logs)
                      .HasForeignKey(e => e.IdTargetObject)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Log");
            });

            modelBuilder.Entity<LogDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdLog).IsRequired().HasColumnName("IdLog");
                entity.Property(e => e.PropertyName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.OldValue).HasMaxLength(400);
                entity.Property(e => e.NewValue).HasMaxLength(400);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne(e => e.Log)
                      .WithMany(l => l.LogDetails) // ahora usa la colección inversa
                      .HasForeignKey(e => e.IdLog)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.ToTable("LogDetail");
            });

            // Status genéricos
            modelBuilder.Entity<StatusTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusTransaction");
            });

            modelBuilder.Entity<StatusResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("StatusResource");
            });
        }
    }
}
