using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusPaymentRepository : IStatusPaymentRepository
    {
        private readonly EvoeventosContext _context;
        public StatusPaymentRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<List<StatusPayment>> GetAllStatusPayments()
        {
            return await _context.StatusPayments.ToListAsync();
        }
        public async Task<StatusPayment?> GetStatusPaymentById(Guid Id)
        {
            return await _context.StatusPayments.FindAsync(Id);
        }
        public async Task<StatusPayment> CreateStatusPayment(StatusPayment StatusPayment)
        {
            _context.StatusPayments.Add(StatusPayment);
            await _context.SaveChangesAsync();
            return StatusPayment;
        }
        public async Task<bool> DeleteStatusPayment(Guid Id)
        {
            var statusPayment = await _context.StatusPayments.FindAsync(Id);
            if (statusPayment == null)
            {
                return false;
            }
            _context.StatusPayments.Remove(statusPayment);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<StatusPayment> UpdateStatusPayment(StatusPayment UpdatedStatusPayment)
        {
            _context.StatusPayments.Update(UpdatedStatusPayment);
            await _context.SaveChangesAsync();
            return UpdatedStatusPayment;
        }
    }
}
