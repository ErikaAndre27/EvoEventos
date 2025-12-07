using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusReservationRepository : IStatusReservationRepository
    {
        private readonly EvoeventosContext _context;
        public StatusReservationRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<StatusReservation> GetStatusReservation(Guid Id)
        {
            return await _context.StatusReservations.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<StatusReservation>> GetStatusReservations()
        {
            return await _context.StatusReservations.ToListAsync();
        }
        public async Task<bool> CreateStatusReservation(StatusReservation StatusReservation)
        {
            try
            {
                _context.StatusReservations.Add(StatusReservation);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteStatusReservation(Guid id)
        {
            try
            {
                var StatusReservation = await _context.StatusReservations.FindAsync(id);
                if (StatusReservation == null)
                {
                    return false;
                }
                _context.StatusReservations.Remove(StatusReservation);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateStatusReservation(Guid id, StatusReservation updatedStatusReservation)
        {
            try
            {
                var existingStatusReservation = await _context.StatusReservations.FindAsync(id);
                if (existingStatusReservation == null)
                {
                    return false;
                }

                existingStatusReservation.Name = updatedStatusReservation.Name;
                existingStatusReservation.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.StatusReservations.Update(existingStatusReservation);
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
