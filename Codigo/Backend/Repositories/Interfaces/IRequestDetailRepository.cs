using BackEvoEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IRequestDetailRepository
    {
        
        Task<RequestDetail> GetRequestDetailById(Guid Id);

        Task<List<RequestDetail>>GetAllRequestDetail();
    }
}
