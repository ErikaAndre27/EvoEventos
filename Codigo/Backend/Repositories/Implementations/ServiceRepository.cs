using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EvoeventosContext _context;
        public ServiceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<Service> GetService(Guid Id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<Service>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }
        public async Task<bool> CreateService(Service Service)
        {
            try
            {
                _context.Services.Add(Service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteService(Guid Id)
        {
            try
            {
                var Service = await _context.Roles.FindAsync(Id);
                if (Service == null)
                {
                    return false;
                }
                _context.Roles.Remove(Service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> UpdateService(Guid Id, Service UpdatedService)
        {
            try
            {
                var ExistingService = await _context.Services.FindAsync(Id);
                if (ExistingService == null)
                {
                    return false;
                }

                ExistingService.Name = UpdatedService.Name;
                ExistingService.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.Services.Update(ExistingService);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
