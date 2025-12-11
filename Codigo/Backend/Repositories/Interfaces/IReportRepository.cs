using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> CreateReport(Report Report);
        Task<List<Report>> GetAllReports();
        Task<List<Report>> GetReportsByUserId(Guid IdUser);
        Task<Report> GetReportId(Guid IdReport);
        Task<List<Report>> GetReportsByTypeId(Guid IdReportType);
        Task<Report> ReportExists(Guid IdReportType, DateOnly RangeStartDate, DateOnly RangeEndDate);
    }
}
