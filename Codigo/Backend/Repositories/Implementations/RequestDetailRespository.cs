using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEvoEventos.Repositories.Implementations
{
    public class RequestDetailRespository : IRequestDetailRepository
    {
        private readonly EvoeventosContext _context;

        public RequestDetailRespository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<RequestDetail> GetRequestDetailById(Guid Id)
        {
            return await _context.RequestDetails
            .Include(rd => rd.Request)        // Incluir datos del Request
            .Include(rd => rd.Service)        // Incluir datos del Service
            .FirstOrDefaultAsync(rd => rd.Id == Id);
        }
        public async Task<List<RequestDetail>> GetAllRequestDetail()
        {
            return await _context.RequestDetails.ToListAsync();
        }
    }
}
