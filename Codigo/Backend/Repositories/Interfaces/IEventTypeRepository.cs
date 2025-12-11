using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IEventTypeRepository
    {
        
        Task<List<EventType>> GetAllEventTypes();
        Task<EventType?> GetEventTypeById(Guid id);

        
        Task<EventType> CreateEventType(EventType eventType);
        Task<EventType> UpdateEventType(EventType eventType);
        Task<bool> DeleteEventType(Guid id); 


        Task<bool> ExistsEventType(Guid id);
        Task<EventType?> GetEventTypeByName(string name);
        
    }
}
