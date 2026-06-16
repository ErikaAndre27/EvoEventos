using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces

{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservations();
        Task<Reservation?> GetReservationById(Guid Id);
        Task<List<Reservation>> GetReservationsByCustomerId(Guid CustomerId);
        Task<Reservation> CreateReservation(Reservation Reservation);
        Task<Reservation> UpdateReservation(Reservation UpdatedReservation);
        Task<bool> DeleteReservation(Guid Id);
    }
}
