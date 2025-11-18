using Microsoft.EntityFrameworkCore;
using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;

namespace BackEvoEventos.Repositories.Implementations

{
    public class ReservationRepository : IReservationRepository
    {
        private readonly EvoeventosContext _context;
        public ReservationRepository(EvoeventosContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Quotation)
                .Include(r => r.StatusReservation)
                .Include(r => r.StatusPayment)
                .ToListAsync();
        }
        public async Task<Reservation?> GetReservationById(Guid Id)
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Quotation)
                .Include(r => r.StatusReservation)
                .Include(r => r.StatusPayment)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<Reservation>> GetReservationsByCustomerId(Guid CustomerId)
        {
            return await _context.Reservations
                .Where(r => r.IdCustomer == CustomerId)
                .Include(r => r.Customer)
                .Include(r => r.Quotation)
                .Include(r => r.StatusReservation)
                .Include(r => r.StatusPayment)
                .ToListAsync();
        }
        public async Task<Reservation> CreateReservation(Reservation Reservation)
        {
            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();
            return Reservation;
        }
        public async Task<bool> DeleteReservation(Guid Id)
        {
            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(r => r.Id == Id);
            if (reservation == null)
                return false;
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Reservation> UpdateReservation(Reservation UpdatedReservation)
        {
            _context.Reservations.Update(UpdatedReservation);
            await _context.SaveChangesAsync();
            return UpdatedReservation;
        }

    }
}

