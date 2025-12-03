using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusRequest
    {
        Task<StatusRequest> CreateStatusRequest(StatusRequest statusRequest);

        Task<StatusRequest?> GetById(int id);
        Task<StatusRequest?> GetStatusByName(string name);
        Task<List<StatusRequest>> GetAllStatus();
        Task<List<StatusRequest>> GetAllActiveAsync(); // Solo activos (si implementas soft delete)

        Task<StatusRequest> UpdateStatusRequest(StatusRequest statusRequest);

        Task<bool> DeleteStatusRequest(int id); // Soft delete o con validación
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
    }
}
