using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(Guid Id);
        Task<List<Payment>> GetPaymentsByReservationId(Guid ReservationId);
        Task<Payment> CreatePayment(Payment Payment);
        Task<Payment> UpdatePayment(Payment UpdatedPayment);
        Task<bool> DeletePayment(Guid Id);
    }
}
