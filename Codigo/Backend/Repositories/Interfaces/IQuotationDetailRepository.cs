using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IQuotationDetailRepository
    {
        Task<QuotationDetail> UpdateQuotationDetail(QuotationDetail quotationDetail);
        Task<bool>DeleteQuotationDetail(Guid Id);
    }
}
