using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations
{
    public class ReservationServiceRepository : IReservationServiceRepository
    {
        private readonly EvoeventosContext _context;
        public ReservationServiceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<List<ReservationService>> GetAllReservationServices()
        {
            return await _context.ReservationServices.ToListAsync();
        }
        public async Task<ReservationService?> GetReservationServiceById(Guid Id)
        {
            return await _context.ReservationServices.FindAsync(Id);
        }
        public async Task<List<ReservationService>> GetReservationServicesByReservationId(Guid IdReservation)
        {
            return await _context.ReservationServices
                .Where(rs => rs.IdReservation == IdReservation)
                .ToListAsync();
        }
        public async Task<ReservationService> CreateReservationService(ReservationService ReservationService)
        {
            _context.ReservationServices.Add(ReservationService);
            await _context.SaveChangesAsync();
            return ReservationService;
        }
        public async Task<bool> DeleteReservationService(Guid Id)
        {
            var reservationService = await _context.ReservationServices.FindAsync(Id);
            if (reservationService == null)
            {
                return false;
            }
            _context.ReservationServices.Remove(reservationService);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ReservationService> UpdateReservationService(ReservationService UpdatedReservationService)
        {
            _context.ReservationServices.Update(UpdatedReservationService);
            await _context.SaveChangesAsync();
            return UpdatedReservationService;
        }
    }
}

