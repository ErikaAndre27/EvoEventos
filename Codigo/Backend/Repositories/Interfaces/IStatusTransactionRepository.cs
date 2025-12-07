using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusTransactionRepository
    {
        Task<List<StatusTransaction>> GetStatusTransactions();
        Task<StatusTransaction> GetStatusTransaction(Guid Id);
        Task<bool> CreateStatusTransaction(StatusTransaction StatusTransaction);
        Task<bool> UpdateStatusTransaction(Guid Id, StatusTransaction UpdatedStatusTransaction);
        Task<bool> DeleteStatusTransaction(Guid Id);
    }
}
