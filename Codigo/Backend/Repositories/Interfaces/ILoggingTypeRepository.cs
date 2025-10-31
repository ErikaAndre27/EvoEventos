using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ILoggingTypeRepository
    {
        Task<List<LoggingType>> GetLoggingTypes();
        Task<LoggingType> GetLoggingType(int id);
    }
}
