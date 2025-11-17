using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ServiceResourceRepository : IServiceResourceRepository
    {
        private readonly EvoeventosContext _context;
        public ServiceResourceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<ServiceResource> GetServiceResource(Guid Id)
        {
            return await _context.ServiceResources.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<ServiceResource>> GetServiceResources()
        {
            return await _context.ServiceResources.ToListAsync();
        }
        public async Task<bool> CreateServiceResource(ServiceResource ServiceResource)
        {
            try
            {
                _context.ServiceResources.Add(ServiceResource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteServiceResource(Guid Id)
        {
            try
            {
                var ServiceResource = await _context.ServiceResources.FindAsync(Id);
                if (ServiceResource == null)
                {
                    return false;
                }
                _context.ServiceResources.Remove(ServiceResource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> UpdateServiceResource(Guid Id, ServiceResource UpdatedServiceResource)
        {
            try
            {
                var ExistingServiceResource = await _context.ServiceResources.FindAsync(Id);
                if (ExistingServiceResource == null)
                {
                    return false;
                }

                ExistingServiceResource.QuantityRequired = UpdatedServiceResource.QuantityRequired; //Revisar
                ExistingServiceResource.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.ServiceResources.Update(ExistingServiceResource);
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
