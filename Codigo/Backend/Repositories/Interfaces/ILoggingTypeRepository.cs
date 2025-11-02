using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ILoggingTypeRepository
    {
        Task<List<LoggingType>> GetLoggingTypes();
        Task<LoggingType> GetLoggingType(Guid id);
        Task<bool> CreateLoggingType(Guid Id, LoggingType loggingType);
        Task<bool> UpdateLoggingType(Guid id, LoggingType updatedLoggingType);
        Task<bool> DeleteLoggingType(Guid Id, LoggingType updatedLoggingType);
    }
}
