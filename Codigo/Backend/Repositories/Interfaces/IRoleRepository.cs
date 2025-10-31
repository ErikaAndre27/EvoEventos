using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();
        Task<Role> GetRole(int id);
    }
}
