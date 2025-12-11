using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusTransactionRepository : IStatusTransactionRepository
    {
        private readonly EvoeventosContext _context;
        public StatusTransactionRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<StatusTransaction> GetStatusTransaction(Guid Id)
        {
            return await _context.StatusTransactions.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<StatusTransaction>> GetStatusTransactions()
        {
            return await _context.StatusTransactions.ToListAsync();
        }
        public async Task<bool> CreateStatusTransaction(StatusTransaction StatusTransaction)
        {
            try
            {
                _context.StatusTransactions.Add(StatusTransaction);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteStatusTransaction(Guid Id)
        {
            try
            {
                var StatusTransaction = await _context.StatusTransactions.FindAsync(Id);
                if (StatusTransaction == null)
                {
                    return false;
                }
                _context.StatusTransactions.Remove(StatusTransaction);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateStatusTransaction(Guid Id, StatusTransaction UpdatedStatusTransaction)
        {
            try
            {
                var existingStatusTransaction = await _context.StatusTransactions.FindAsync(Id);
                if (existingStatusTransaction == null)
                {
                    return false;
                }

                existingStatusTransaction.Name = UpdatedStatusTransaction.Name;
                existingStatusTransaction.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.StatusTransactions.Update(existingStatusTransaction);
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
