using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();
        Task<Role> GetRole(Guid id);
        Task<bool> CreateRole(Role role);
        Task<bool> UpdateRole(Guid id, Role updatedRole); 
        Task<bool> DeleteRole(Guid id);

    }
}
