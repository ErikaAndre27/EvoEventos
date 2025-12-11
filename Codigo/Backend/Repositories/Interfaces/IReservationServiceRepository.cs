using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IReservationServiceRepository
    {
        Task<List<ReservationService>> GetAllReservationServices();
        Task<ReservationService?> GetReservationServiceById(Guid Id);
        Task<List<ReservationService>> GetReservationServicesByReservationId(Guid IdReservation);
        Task<ReservationService> CreateReservationService(ReservationService ReservationService);
        Task<ReservationService> UpdateReservationService(ReservationService UpdatedReservationService);
        Task<bool> DeleteReservationService(Guid Id);
    }
}
