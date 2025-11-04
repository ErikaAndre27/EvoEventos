using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EvoeventosContext _context;
        public RoleRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRole(Guid id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<bool> CreateRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null)
                {
                    return false;
                }
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateRole(Guid id, Role updatedRole)
        {
            try
            {
                var existingRole = await _context.Roles.FindAsync(id);
                if (existingRole == null)
                {
                    return false;
                }

                existingRole.Name = updatedRole.Name;
                existingRole.UpdatedAt = DateTime.UtcNow;

                _context.Roles.Update(existingRole);
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
