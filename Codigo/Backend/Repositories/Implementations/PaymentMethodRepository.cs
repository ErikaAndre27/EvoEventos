using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly EvoeventosContext _context;
        public PaymentMethodRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<PaymentMethod> GetPaymentMethod(Guid Id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<PaymentMethod>> GetPaymentMethods()
        {
            return await _context.PaymentMethods.ToListAsync();
        }
        public async Task<bool> CreatePaymentMethod(PaymentMethod PaymentMethod)
        {
            try
            {
                _context.PaymentMethods.Add(PaymentMethod);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeletePaymentMethod(Guid Id)
        {
            try
            {
                var PaymentMethod = await _context.PaymentMethods.FindAsync(Id);
                if (PaymentMethod == null)
                {
                    return false;
                }
                _context.PaymentMethods.Remove(PaymentMethod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdatePaymentMethod(Guid Id, PaymentMethod UpdatedPaymentMethod)
        {
            try
            {
                var existingPaymentMethod = await _context.PaymentMethods.FindAsync(Id);
                if (existingPaymentMethod == null)
                {
                    return false;
                }

                existingPaymentMethod.Name = UpdatedPaymentMethod.Name;
                existingPaymentMethod.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.PaymentMethods.Update(existingPaymentMethod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
