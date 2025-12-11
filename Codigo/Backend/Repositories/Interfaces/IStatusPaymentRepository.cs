using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusPaymentRepository
    {
        Task<List<StatusPayment>> GetAllStatusPayments();
        Task<StatusPayment?> GetStatusPaymentById(Guid Id);
        Task<StatusPayment> CreateStatusPayment(StatusPayment StatusPayment);
        Task<StatusPayment> UpdateStatusPayment(StatusPayment UpdatedStatusPayment);
        Task<bool> DeleteStatusPayment(Guid Id);
    }
}