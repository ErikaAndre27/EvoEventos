using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IServiceResourceRepository
    {
        Task<List<ServiceResource>> GetServiceResources();
        Task<ServiceResource> GetServiceResource(Guid Id);
        Task<bool> CreateServiceResource(ServiceResource ServiceResource);
        Task<bool> UpdateServiceResource(Guid Id, ServiceResource UpdatedServiceResource);
        Task<bool> DeleteServiceResource(Guid Id);
    }
}
