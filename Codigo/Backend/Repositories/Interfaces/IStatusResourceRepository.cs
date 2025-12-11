using BackEvoEventos.Models;


namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusResourceRepository
    {
        Task<List<StatusResource>> GetStatusResources();
        Task<StatusResource> GetStatusResource(Guid id);
        Task<bool> CreateStatusResource(StatusResource StatusResource);
        Task<bool> UpdateStatusResource(Guid Id, StatusResource UpdatedStatusResource); 
        Task<bool> DeleteStatusResource(Guid Id);
    }
}
