using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetServices();
        Task<Service> GetService(Guid Id);
        Task<bool> CreateService(Service Service);
        Task<bool> UpdateService(Guid Id, Service updatedService);
        Task<bool> DeleteService(Guid Id);


    }
}
