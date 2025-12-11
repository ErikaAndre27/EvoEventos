using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IQuotationRepository
    {
        Task<bool>CreateQuotation(Quotation Quotation);
        Task<Quotation> UpdateQuotation(Quotation Quotation);
        Task<bool> DeleteQuotation(Guid Id);
        Task<Quotation> GetQuotationByEventType(String EventType);
        Task<Quotation> GetQuotationByEmail(string Email);
        Task<Quotation> GetQuotationByCustomerName(string CustomerName);
        Task<Quotation> GetQuotationById(Guid IdStatusQuotation);

    }
}
