using BackEvoEventos.Dtos;
using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllRequests();
        Task<bool> CreateRequest(CreateRequestDto RequestDto);
        Task<Request> UpdateRequest(Request UpdateRequest);
        Task<bool> DeleteRequest(Guid Id);
        Task<Request> GetRequestById(Guid Id);
    }
}
