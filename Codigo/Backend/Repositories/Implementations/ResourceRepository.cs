using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly EvoeventosContext _context;
        public ResourceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<Resource> GetResource(Guid Id)
        {
            return await _context.Resources.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<Resource>> GetResources()
        {
            return await _context.Resources.ToListAsync();
        }
        public async Task<bool> CreateResource(Resource Resource)
        {
            try
            {
                _context.Resources.Add(Resource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteResource(Guid Id)
        {
            try
            {
                var Resource = await _context.Roles.FindAsync(Id);
                if (Resource == null)
                {
                    return false;
                }
                _context.Roles.Remove(Resource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> UpdateResource(Guid Id, Resource UpdatedResource)
        {
            try
            {
                var ExistingResource = await _context.Resources.FindAsync(Id);
                if (ExistingResource == null)
                {
                    return false;
                }

                ExistingResource.Name = UpdatedResource.Name;
                ExistingResource.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.Resources.Update(ExistingResource);
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
