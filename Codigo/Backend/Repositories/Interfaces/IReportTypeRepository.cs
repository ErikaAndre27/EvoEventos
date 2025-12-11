using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IReportTypeRepository
    {
        Task<List<ReportType>> GetAllReportTypes();
        Task<ReportType> GetReportType(Guid Id);
        Task<bool> CreateReportType(ReportType ReportType);


    }
}
