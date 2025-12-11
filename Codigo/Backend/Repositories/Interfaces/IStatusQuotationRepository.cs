using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusQuotationRepository
    {
        Task<List<StatusQuotation>> GetAllStatusQuotation();
        Task<StatusQuotation?> GetStatusQuotationById(Guid id);
        Task<StatusQuotation?> GetStatusQuotationByName(string name);
        Task<StatusQuotation> UpdateStatusQuotation(StatusQuotation statusQuotation);
        Task<bool> InitializeDefaultResponseStatuses();     
    }
}
