using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IEventTypeRepository
    {
        // Para frontend (dropdowns)
        Task<List<EventType>> GetAllEventTypes();
        Task<EventType?> GetEventTypeById(Guid id);

        // Para admin/asesor (mantenimiento)
        Task<EventType> CreateEventType(EventType eventType);
        Task<EventType> UpdateEventType(EventType eventType);
        Task<bool> DeleteEventType(Guid id); // Con validación de uso

        // Utilidades
        Task<bool> ExistsEventType(Guid id);
        Task<EventType?> GetEventTypeByName(string name);
        
    }
}
