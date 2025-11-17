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
            services.AddScoped<ICustomerTypeRepository,CustomerTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

            return services;
        }
    }
}
