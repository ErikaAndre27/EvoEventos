using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly EvoeventosContext _context;
        public EventTypeRepository(EvoeventosContext context)
        {
            _context = context;
        }

        // 1. Para frontend (dropdowns)
        public Task<List<EventType>> GetAllEventTypes()
        {
            return _context.EventTypes
                .OrderBy(et => et.Name)
                .ToListAsync();
        }

        public Task<EventType?> GetEventTypeById(Guid id)
        {
            return _context.EventTypes.FindAsync(id).AsTask();
        }

        // 2. Para admin/asesor (mantenimiento)
        public async Task<EventType> CreateEventType(EventType eventType)
        {
            // Validar nombre único (case-insensitive)
            var exists = await _context.EventTypes
                .AnyAsync(et => et.Name.ToLower() == eventType.Name.ToLower());

            if (exists)
            {
                throw new InvalidOperationException($"Ya existe un tipo de evento con el nombre '{eventType.Name}'");
            }

            // Establecer fechas
            eventType.CreatedAt = DateTime.UtcNow;
            eventType.UpdatedAt = null;

            _context.EventTypes.Add(eventType);
            await _context.SaveChangesAsync();

            return eventType;
        }

        public async Task<EventType> UpdateEventType(EventType eventType)
        {
            // Verificar que existe
            var existing = await _context.EventTypes.FindAsync(eventType.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Tipo de evento con ID {eventType.Id} no encontrado");
            }

            // Validar que el nuevo nombre no colisione con otro
            if (existing.Name != eventType.Name)
            {
                var duplicate = await _context.EventTypes
                    .Where(et => et.Id != eventType.Id)
                    .FirstOrDefaultAsync(et => et.Name.ToLower() == eventType.Name.ToLower());

                if (duplicate != null)
                {
                    throw new InvalidOperationException($"Ya existe otro tipo de evento con el nombre '{eventType.Name}'");
                }
            }

            // Actualizar propiedades
            existing.Name = eventType.Name;
            existing.Abbreviation = eventType.Abbreviation;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.EventTypes.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteEventType(Guid id)
        {
            // Buscar el tipo de evento
            var eventType = await _context.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return false; // No existe
            }

            // Validar que NO esté siendo usado por Requests
            var isUsedInRequests = await _context.Requests
                .AnyAsync(r => r.IdEventType == id);

            if (isUsedInRequests)
            {
                return false; // No se puede eliminar porque está en uso
            }

            // Validar que NO esté siendo usado por Quotations
            var isUsedInQuotations = await _context.Quotations
                .AnyAsync(q => q.IdEventType == id);

            if (isUsedInQuotations)
            {
                return false; // No se puede eliminar porque está en uso
            }

            // SOFT DELETE: Marcar UpdatedAt como fecha de "eliminación"
            eventType.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true; // Eliminación exitosa
        }

        // 3. Utilidades
        public Task<bool> ExistsEventType(Guid id)
        {
            return _context.EventTypes.AnyAsync(et => et.Id == id);
        }

        public Task<EventType?> GetEventTypeByName(string name)
        {
            return _context.EventTypes
                .FirstOrDefaultAsync(et => et.Name.ToLower() == name.ToLower());
        }

        // 4. Seed/Inicialización (con bool return como pediste)
        public async Task<bool> SeedDefaultEventTypesAsync()
        {
            try
            {
                var defaultEventTypes = new List<EventType>
                {
                    new EventType { Name = "Cumpleaños" },
                    new EventType { Name = "Boda" },
                    new EventType { Name = "Evento Corporativo" },
                    new EventType { Name = "Graduación" },
                    new EventType { Name = "Aniversario" },
                    new EventType { Name = "Fiesta Temática" },
                    new EventType { Name = "Otros" }
                };

                bool anyCreated = false;

                foreach (var eventType in defaultEventTypes)
                {
                    var exists = await _context.EventTypes
                        .AnyAsync(et => et.Name.ToLower() == eventType.Name.ToLower());

                    if (!exists)
                    {
                        eventType.CreatedAt = DateTime.UtcNow;
                        _context.EventTypes.Add(eventType);
                        anyCreated = true;
                    }
                }

                if (anyCreated)
                {
                    await _context.SaveChangesAsync();
                }

                return anyCreated;
            }
            catch
            {
                return false;
            }


        }

    }
}
