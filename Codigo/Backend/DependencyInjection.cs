using BackEvoEventos.Context;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BackEvoEventos
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = _configuration.GetConnectionString("EvoeventosConnection");
            connectionString = _configuration["ConnectionStrings:EvoeventosConnection"];

            services.AddDbContext<Context.EvoeventosContext>(options =>
                options.UseSqlServer(connectionString)); // Usar UseSqlServer para SQL Server
            services.AddScoped<IRoleRepository, RoleRepository>(); // Inyección de dependencia para RoleRepository
            services.AddScoped<ICategoryResourceRepository, CategoryResourceRepository>();
            services.AddScoped<ICustomerTypeRepository,CustomerTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestDetailRepository, RequestDetailRespository>();
            services.AddScoped<IQuotationDetailRepository, QuotationDetailRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<IStatusQuotationRepository, StatusQuotationRepository>();
            services.AddScoped<IStatusRequestRepository, StatusRequestRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceResourceRepository, ServiceResourceRepository>();
            services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IStatusPaymentRepository, StatusPaymentRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IReservationServiceRepository, ReservationServiceRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPricingUnitRepository, PricingUnitRepository>();
            services.AddScoped<ICategoryServiceRepository, CategoryServiceRepository>();
            services.AddScoped<IStatusTransactionRepository, StatusTransactionRepository>();
            services.AddScoped<IStatusResourceRepository, StatusResourceRepository>();
            services.AddScoped<IStatusReservationRepository, StatusReservationRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();


            return services;
        }
    }
}
