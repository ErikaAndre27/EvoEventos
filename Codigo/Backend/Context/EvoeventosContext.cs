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

        // Entidades añadidas
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
                entity.Property(e => e.Notes).HasMaxLength(200).HasColumnName("Notes");
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
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100).HasColumnName("Password");
                entity.Property(e => e.LastLogin).IsRequired().HasColumnName("LastLogin");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.HasOne(e => e.User)
                      .WithMany(t => t.Credentials)
                      .HasForeignKey(e => e.IdUser)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.LoggingType)
                      .WithMany(t => t.Credentials)
                      .HasForeignKey(e => e.IdLoggingType)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Credential");
            });

            modelBuilder.Entity<CategoryService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("CategoryService");
            });

            modelBuilder.Entity<CategoryResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("CategoryResource");
            });

            modelBuilder.Entity<PricingUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).HasMaxLength(30);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.ToTable("PricingUnit");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20).HasColumnName("Name");
                entity.Property(e => e.Description).HasMaxLength(50).HasColumnName("Description");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,2)").HasColumnName("UnitPrice");
                entity.Property(e => e.Available).IsRequired().HasDefaultValue(true).HasColumnName("Available");
                entity.Property(e => e.External).HasColumnName("External");
                entity.Property(e => e.IdCategory).HasColumnName("IdCategory");
                entity.Property(e => e.IdPricingUnit).HasColumnName("IdPricingUnit");
                entity.Property(e => e.DurationHoursDefault).HasColumnName("DurationHoursDefault");
                entity.HasOne(e => e.CategoryService)
                      .WithMany(c => c.Services)
                      .HasForeignKey(e => e.IdCategory)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.PricingUnit)
                      .WithMany(p => p.Services)
                      .HasForeignKey(e => e.IdPricingUnit)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Service");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Description).HasMaxLength(50).HasColumnName("Description");
                entity.Property(e => e.SerialCode).HasMaxLength(20).HasColumnName("SerialCode");
                entity.Property(e => e.IdStatusResource).HasColumnName("IdStatusResource");
                entity.Property(e => e.PurchaseDate).HasColumnName("PurchaseDate");
                entity.Property(e => e.Value).HasColumnType("decimal(18,2)").HasColumnName("Value");
                entity.Property(e => e.LastMaintenanceDate).HasColumnName("LastMaintenanceDate");
                entity.Property(e => e.NextMaintenanceDate).HasColumnName("NextMaintenanceDate");
                entity.Property(e => e.ExternalProvider).HasMaxLength(20).HasColumnName("ExternalProvider");
                entity.Property(e => e.IsExternal).HasColumnName("IsExternal");
                entity.Property(e => e.IdCategoryResource).HasColumnName("IdCategoryResource");
                entity.HasOne(e => e.CategoryResource)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(e => e.IdCategoryResource)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Resource");
            });

            modelBuilder.Entity<ServiceResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.IdResource).IsRequired().HasColumnName("IdResource");
                entity.Property(e => e.QuantityRequired).IsRequired().HasColumnName("QuantityRequired");
                entity.Property(e => e.IsMandatory).HasColumnName("IsMandatory");
                entity.Property(e => e.UsageNotes).HasMaxLength(20).HasColumnName("UsageNotes");
                entity.Property(e => e.ExternalProvider).HasColumnName("ExternalProvider");
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
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.ToTable("StatusQuotation");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Consecutive).HasColumnName("Consecutive");
                entity.Property(e => e.IdRequest).HasColumnName("IdRequest");
                entity.Property(e => e.IdEventType).HasColumnName("IdEventType");
                entity.Property(e => e.IdCustomer).IsRequired().HasColumnName("IdCustomer");
                entity.Property(e => e.IdUser).IsRequired().HasColumnName("IdUser");
                entity.Property(e => e.IdStatusQuotation).HasColumnName("IdStatusQuotation");
                entity.Property(e => e.IsQuotationAccepted).HasColumnName("IsQuotationAccepted");
                entity.Property(e => e.EventDate).IsRequired().HasColumnName("EventDate");
                entity.Property(e => e.EventDurationHours).HasColumnType("decimal(10,2)").HasColumnName("EventDurationHours");
                entity.Property(e => e.EventLocation).HasMaxLength(50).HasColumnName("EventLocation");
                entity.Property(e => e.EventCity).HasMaxLength(50).HasColumnName("EventCity");
                entity.Property(e => e.ExpirationDate).HasColumnName("ExpirationDate");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)").HasColumnName("TotalAmount");
                entity.Property(e => e.Discount).HasColumnType("decimal(10,2)").HasColumnName("Discount");
                entity.Property(e => e.Notes).HasMaxLength(100).HasColumnName("Notes");
                entity.ToTable("Quotation");
            });

            modelBuilder.Entity<QuotationDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdQuotation).IsRequired().HasColumnName("IdQuotation");
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.Quantity).IsRequired().HasColumnName("Quantity");
                entity.Property(e => e.SubTotal).HasColumnType("decimal(10,2)").HasColumnName("SubTotal");
                entity.Property(e => e.DurationHours).HasColumnName("DurationHours");
                entity.Property(e => e.Notes).HasMaxLength(100).HasColumnName("Notes");
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
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.ToTable("StatusReservation");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdQuotation).HasColumnName("IdQuotation");
                entity.Property(e => e.IdCustomer).IsRequired().HasColumnName("IdCustomer");
                entity.Property(e => e.IdStatusReservation).HasColumnName("IdStatusReservation");
                entity.Property(e => e.ReservationCode).HasColumnName("ReservationCode");
                entity.Property(e => e.EventName).HasMaxLength(20).HasColumnName("EventName");
                entity.Property(e => e.EventType).HasMaxLength(30).HasColumnName("EventType");
                entity.Property(e => e.StartTime).IsRequired().HasColumnName("StartTime");
                entity.Property(e => e.EndTime).IsRequired().HasColumnName("EndTime");
                entity.Property(e => e.Location).HasMaxLength(30).HasColumnName("Location");
                entity.Property(e => e.City).HasMaxLength(50).HasColumnName("City");
                entity.Property(e => e.GuestsCount).HasColumnName("GuestsCount");
                entity.Property(e => e.Notes).HasMaxLength(200).HasColumnName("Notes");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)").HasColumnName("TotalAmount");
                entity.Property(e => e.TotalPaid).HasColumnType("decimal(18,2)").HasColumnName("TotalPaid");
                entity.Property(e => e.IdStatusPayment).HasColumnName("IdStatusPayment");
                entity.ToTable("Reservation");
            });

            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdService).IsRequired().HasColumnName("IdService");
                entity.Property(e => e.IdReservation).IsRequired().HasColumnName("IdReservation");
                entity.Property(e => e.Quantity).IsRequired().HasColumnName("Quantity");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10,2)").HasColumnName("TotalPrice");
                entity.Property(e => e.Notes).HasMaxLength(200).HasColumnName("Notes");
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
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.ToTable("PaymentMethod");
            });

            modelBuilder.Entity<StatusPayment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.ToTable("StatusPayment");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PaymentDate).IsRequired().HasColumnName("PaymentDate");
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)").HasColumnName("Amount");
                entity.Property(e => e.IdPaymentMethod).IsRequired().HasColumnName("IdPaymentMethod");
                entity.Property(e => e.PaymentReference).HasMaxLength(50).HasColumnName("PaymentReference");
                entity.Property(e => e.IdTransactionStatus).HasColumnName("IdTransactionStatus");
                entity.Property(e => e.RegisteredBy).HasColumnName("RegisteredBy");
                entity.Property(e => e.IdReservation).IsRequired().HasColumnName("IdReservation");
                entity.Property(e => e.Notes).HasMaxLength(100).HasColumnName("Notes");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.HasOne(e => e.Reservation)
                      .WithMany(r => r.Payments)
                      .HasForeignKey(e => e.IdReservation)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.PaymentMethod)
                      .WithMany(p => p.Payments)
                      .HasForeignKey(e => e.IdPaymentMethod)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.StatusTransaction)
                      .WithMany(s => s.Payments)
                      .HasForeignKey(e => e.IdTransactionStatus)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.ToTable("Payment");
            });

            // Requests / RequestDetails
            modelBuilder.Entity<StatusRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
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
                entity.Property(e => e.FullName).HasMaxLength(100).HasColumnName("FullName");
                entity.Property(e => e.Phone).HasMaxLength(14).HasColumnName("Phone");
                entity.Property(e => e.Email).HasMaxLength(50).HasColumnName("Email");
                entity.Property(e => e.EventDate).IsRequired().HasColumnName("EventDate");
                entity.Property(e => e.EventAttendees).HasColumnName("EventAttendees");
                entity.Property(e => e.EventLocation).HasMaxLength(50).HasColumnName("EventLocation");
                entity.Property(e => e.Message).HasMaxLength(100).HasColumnName("Message");
                entity.Property(e => e.IdStatusRequest).HasColumnName("IdStatusRequest");
                entity.Property(e => e.HandledBy).HasColumnName("HandledBy");
                entity.Property(e => e.IdEventType).HasColumnName("IdEventType");
                entity.ToTable("Request");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdRequest).IsRequired().HasColumnName("IdRequest");
                entity.Property(e => e.IdService).HasColumnName("IdService");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.ToTable("RequestDetail");
            });

            // Reports
            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.ToTable("ReportType");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(50).HasColumnName("Title"); 
                entity.Property(e => e.Description).HasMaxLength(200).HasColumnName("Description");
                entity.Property(e => e.IdReportType).IsRequired().HasColumnName("IdReportType");
                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.RangeStartDate).HasColumnName("RangeStartDate");
                entity.Property(e => e.RangeEndDate).HasColumnName("RangeEndDate");
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
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Description).HasMaxLength(200).HasColumnName("Description");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");
                entity.ToTable("ActionType");
            });

            modelBuilder.Entity<TargetObject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TableName).IsRequired().HasMaxLength(50).HasColumnName("TableName");
                entity.Property(e => e.Detail).HasMaxLength(200).HasColumnName("Detail");
                entity.ToTable("TargetObject");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdTargetObject).HasColumnName("IdTargetObject");
                entity.Property(e => e.IdActionType).HasColumnName("IdActionType");
                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.ToTable("Log");
            });

            modelBuilder.Entity<LogDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdLog).IsRequired().HasColumnName("IdLog");
                entity.Property(e => e.AffectedField).IsRequired().HasMaxLength(50).HasColumnName("AffectedField");
                entity.Property(e => e.PreviousValue).HasMaxLength(100).HasColumnName("PreviousValue");
                entity.Property(e => e.NewValue).HasMaxLength(100).HasColumnName("NewValue");
                entity.Property(e => e.CreatedAt).IsRequired().HasColumnName("CreatedAt");
                entity.ToTable("LogDetail");
            });

            // Status genéricos
            modelBuilder.Entity<StatusTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.ToTable("StatusTransaction");
            });

            modelBuilder.Entity<StatusResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.ToTable("StatusResource");
            });
        }
    }
}
