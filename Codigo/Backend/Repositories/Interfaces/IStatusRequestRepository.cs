using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusRequestRepository
    {
        Task<StatusRequest> CreateStatusRequest(StatusRequest statusRequest);
        Task<StatusRequest?> GetStatusRequestById(Guid id);
        Task<StatusRequest?> GetStatusRequestByName(string name);
        Task<List<StatusRequest>> GetAllStatusRequest();
        Task<StatusRequest> UpdateStatusRequest(StatusRequest statusRequest);
        Task<bool> DeleteStatusRequest(Guid id); 

    }
}
