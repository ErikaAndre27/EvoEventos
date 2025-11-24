using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusResourceRepository : IStatusResourceRepository
    {

        private readonly EvoeventosContext _context;
        public StatusResourceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<StatusResource> GetStatusResource(Guid Id)
        {
            return await _context.StatusResources.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<StatusResource>> GetStatusResources()
        {
            return await _context.StatusResources.ToListAsync();
        }
        public async Task<bool> CreateStatusResource(StatusResource StatusResource)
        {
            try
            {
                _context.StatusResources.Add(StatusResource);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteStatusResource(Guid Id)
        {
            try
            {
                var StatusResource = await _context.StatusResources.FindAsync(Id);
                if (StatusResource == null)
                {
                    return false;
                }
                _context.StatusResources.Remove(StatusResource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateStatusResource(Guid Id, StatusResource UpdatedStatusResource)
        {
            try
            {
                var existingStatusResource = await _context.StatusResources.FindAsync(Id);
                if (existingStatusResource == null)
                {
                    return false;
                }

                existingStatusResource.Name = UpdatedStatusResource.Name;
                existingStatusResource.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.StatusResources.Update(existingStatusResource);
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
