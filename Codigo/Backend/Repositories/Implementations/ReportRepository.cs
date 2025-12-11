using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ReportRepository: IReportRepository
    {
        private readonly EvoeventosContext _context;
        public ReportRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<Report> CreateReport(Report Report)
        {
            try
            {
                _context.Reports.Add(Report);
                await _context.SaveChangesAsync();
                return Report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<Report>> GetAllReports()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<List<Report>> GetReportsByUserId(Guid id)
        {
            return await _context.Reports.Where(x => x.IdUser == id).ToListAsync();
        }

        public async Task<Report> GetReportId(Guid Id)
        {
            return await _context.Reports.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Report>> GetReportsByTypeId(Guid id)
        {
            return await _context.Reports.Where(x => x.IdReportType == id).ToListAsync();
        }

        public async Task<Report> ReportExists(Guid IdReportType, DateOnly RangeStartDate, DateOnly RangeEndDate)
        {
            return await _context.Reports.FirstOrDefaultAsync(c => c.IdReportType == IdReportType && c.RangeStartDate == RangeStartDate && c.RangeEndDate == RangeEndDate);
        }
    }
}
