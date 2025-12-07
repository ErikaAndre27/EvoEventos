using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IStatusReservationRepository
    {
        Task<List<StatusReservation>> GetStatusReservations();
        Task<StatusReservation> GetStatusReservation(Guid Id);
        Task<bool> CreateStatusReservation(StatusReservation StatusReservation);
        Task<bool> UpdateStatusReservation(Guid Id, StatusReservation UpdatedStatusReservation);
        Task<bool> DeleteStatusReservation(Guid Id);
    }
}
