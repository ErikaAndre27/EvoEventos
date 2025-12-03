using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEvoEventos.Repositories.Implementations
{
    public class QuotationDetailRepository : IQuotationDetailRepository
    {
        private readonly EvoeventosContext _context;
        public QuotationDetailRepository(EvoeventosContext context)
        {
          _context = context;
        }
        public async Task<QuotationDetail> UpdateQuotationDetail(QuotationDetail quotationDetail)
        {
            var existingDetail = await _context.QuotationDetails
        .FirstOrDefaultAsync(qd => qd.Id == quotationDetail.Id);

            if (existingDetail == null)
            {
                throw new Exception($"No se encontró el detalle de cotización con ID {quotationDetail.Id}");
            }
            _context.Entry(existingDetail).CurrentValues.SetValues(quotationDetail);
            await _context.SaveChangesAsync();
            return existingDetail;
        }
        public async Task<bool> DeleteQuotationDetail(Guid Id)
        {
            var detail = await _context.QuotationDetails.FindAsync(Id);

            if (detail == null)
                return false;

            _context.QuotationDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
