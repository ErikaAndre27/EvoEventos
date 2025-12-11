using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ReportTypeRepository: IReportTypeRepository
    {
        private readonly EvoeventosContext _context;
        public ReportTypeRepository(EvoeventosContext context)
        {
            _context = context;
        }

        public async Task<ReportType> GetReportType(Guid id)
        {
            return await _context.ReportTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReportType>> GetAllReportTypes()
        {
            return await _context.ReportTypes.ToListAsync();
        }

        public async Task<bool> CreateReportType(ReportType ReportType)
        {
            try
            {
                _context.ReportTypes.Add(ReportType);
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
