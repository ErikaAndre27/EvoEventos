using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class LoggingTypeRepository : ILoggingTypeRepository
    {
        private readonly EvoeventosContext _context;
        public LoggingTypeRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<LoggingType> GetLoggingType(Guid id)
        {
            return await _context.LoggingTypes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<LoggingType>> GetLoggingTypes()
        {
            return await _context.LoggingTypes.ToListAsync();
        }

        public async Task<bool> CreateLoggingType(Guid Id, LoggingType loggingType)
        {
            try
            {
                _context.LoggingTypes.Add(loggingType);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> DeleteLoggingType(Guid id, LoggingType loggingType)
        {
            try
            {
                var role = await _context.LoggingTypes.FindAsync(id);
                if (role == null)
                {
                    return false;
                }
                _context.LoggingTypes.Remove(loggingType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task<bool> UpdateLoggingType(Guid id, LoggingType updatedLoggingType)
        {
            try
            {
                var existingLoggingType = await _context.LoggingTypes.FindAsync(id);
                if (existingLoggingType == null)
                {
                    return false;
                }

                existingLoggingType.Name = updatedLoggingType.Name;
                existingLoggingType.UpdatedAt = DateTime.UtcNow;

                _context.LoggingTypes.Update(existingLoggingType);
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
