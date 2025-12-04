using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusQuotationRepository : IStatusQuotationRepository
    {
        private readonly EvoeventosContext _context;
        public StatusQuotationRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public Task<List<StatusQuotation>> GetAllStatusQuotation()
        {
            return _context.StatusQuotations
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public Task<StatusQuotation?> GetStatusQuotationById(Guid id)
        {
            return _context.StatusQuotations.FindAsync(id).AsTask();
        }
        public Task<StatusQuotation?> GetStatusQuotationByName(string name)
        {
            return _context.StatusQuotations
                .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }
        public async Task<StatusQuotation> UpdateStatusQuotation(StatusQuotation statusQuotation)
        {
            
            var existing = await _context.StatusQuotations.FindAsync(statusQuotation.Id); // Verificar que existe
            if (existing == null)
            {
                throw new KeyNotFoundException($"StatusQuotation con ID {statusQuotation.Id} no encontrado");
            }

            
            if (existing.Name != statusQuotation.Name) // Validar que el nuevo nombre no choque con otro
            {
                var duplicate = await _context.StatusQuotations
                    .Where(s => s.Id != statusQuotation.Id)
                    .FirstOrDefaultAsync(s => s.Name.ToLower() == statusQuotation.Name.ToLower());

                if (duplicate != null)
                {
                    throw new InvalidOperationException($"Ya existe otro estado con el nombre '{statusQuotation.Name}'");
                }
            }
            existing.Name = statusQuotation.Name;
            existing.Description = statusQuotation.Description;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.StatusQuotations.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }
        public async Task<bool> InitializeDefaultResponseStatuses() //llamar a todos los tipos de estados.-.
        {
            try
            {
                var defaultStatuses = new List<StatusQuotation>
                {
                    new StatusQuotation { Name = "pendiente", Description = "Esperando respuesta del cliente" },
                    new StatusQuotation { Name = "en revisión", Description = "Cliente está revisando la cotización enviada" },
                    new StatusQuotation { Name = "aprobada", Description = "Cliente aprobó la cotización" },
                    new StatusQuotation { Name = "rechazada", Description = "Cliente rechazó la cotización" },
                    new StatusQuotation { Name = "expirada", Description = "La cotización pasó su fecha de validez sin respuesta" },
                    new StatusQuotation { Name = "cancelada", Description = "Cotización cancelada por asesor o administrador" }
                };

                bool anyCreated = false;

                foreach (var status in defaultStatuses)
                {
                    var exists = await _context.StatusQuotations
                        .AnyAsync(s => s.Name.ToLower() == status.Name.ToLower());

                    if (!exists)
                    {
                        status.CreatedAt = DateTime.UtcNow;
                        _context.StatusQuotations.Add(status);
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

