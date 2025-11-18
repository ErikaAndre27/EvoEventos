using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IResourceRepository
    {
        Task<List<Resource>> GetResources();
        Task<Resource> GetResource(Guid Id);
        Task<bool> CreateResource(Resource Resource);
        Task<bool> UpdateResource(Guid Id, Resource updatedResource);
        Task<bool> DeleteResource(Guid Id);
    }
}
