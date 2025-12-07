using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethod>> GetPaymentMethods();
        Task<PaymentMethod> GetPaymentMethod(Guid Id);
        Task<bool> CreatePaymentMethod(PaymentMethod PaymentMethod);
        Task<bool> UpdatePaymentMethod(Guid Id, PaymentMethod UpdatedPaymentMethod);
        Task<bool> DeletePaymentMethod(Guid Id);
    }
}
