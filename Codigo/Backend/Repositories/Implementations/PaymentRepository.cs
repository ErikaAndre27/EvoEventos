using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations

{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EvoeventosContext _context;
        public PaymentRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreatePayment(Payment Payment)
        {
            _context.Payments.Add(Payment);
            await _context.SaveChangesAsync();
            return Payment;
        }
        public async Task<bool> DeletePayment(Guid Id)
        {
            var payment = await _context.Payments.FindAsync(Id);
            if (payment == null)
            {
                return false;
            }
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment> GetPaymentById(Guid Id)
        {
            return await _context.Payments.FindAsync(Id);
        }
        public async Task<List<Payment>> GetPaymentsByReservationId(Guid ReservationId)
        {
            return await _context.Payments
                .Where(p => p.ReservationId == ReservationId)
                .ToListAsync();
        }
        public async Task<Payment> UpdatePayment(Payment UpdatedPayment)
        {
            _context.Payments.Update(UpdatedPayment);
            await _context.SaveChangesAsync();
            return UpdatedPayment;
        }
    }
}
