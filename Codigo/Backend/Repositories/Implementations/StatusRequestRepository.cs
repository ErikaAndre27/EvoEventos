using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class StatusRequestRepository : IStatusRequestRepository
    {
        private readonly EvoeventosContext _context;
        public StatusRequestRepository(EvoeventosContext context) 
        {
            _context = context;
        }
        public async Task<StatusRequest> CreateStatusRequest(StatusRequest statusRequest)
        {
            var existing = await _context.StatusRequests
                .FirstOrDefaultAsync(s => s.Name.ToLower() == statusRequest.Name.ToLower()); //ayuda a pasar todo a minuscula para evitar que la palabra ingresada así sea la misma pero escrita de diferentes maneras no se cree teniendo ya la predeterminada 

            if (existing != null)
                throw new InvalidOperationException($"Ya existe un status con el nombre '{statusRequest.Name}'");

            // Establecer fechas
            statusRequest.CreatedAt = DateTime.UtcNow;
            statusRequest.UpdatedAt = null;

            _context.StatusRequests.Add(statusRequest);
            await _context.SaveChangesAsync();

            return statusRequest;
        }

        
        public async Task<StatusRequest?> GetStatusRequestById(int id)
        {
            return await _context.StatusRequests.FindAsync(id);
        }

        
        public async Task<StatusRequest?> GetStatusRequestByName(string name)
        {
            return await _context.StatusRequests
                .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }
        public async Task<List<StatusRequest>> GetAllStatusRequest()
        {
            return await _context.StatusRequests
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<StatusRequest> UpdateStatusRequest(StatusRequest statusRequest)
        {
            var existingStatus = await _context.StatusRequests.FindAsync(statusRequest.Id);
            if (existingStatus == null)  //VERIFCAR Al Existemcia
            {
                throw new KeyNotFoundException($"No se encontró el StatusRequest con ID {statusRequest.Id}");
            }

            
            if (existingStatus.Name != statusRequest.Name)
            {
                bool nameExists = await _context.StatusRequests
                    .AnyAsync(s => s.Id != statusRequest.Id &&
                                  s.Name.ToLower() == statusRequest.Name.ToLower());

                if (nameExists)
                {
                    throw new InvalidOperationException($"Ya existe un status con el nombre '{statusRequest.Name}'");
                }
            }

           
            existingStatus.Name = statusRequest.Name;
            existingStatus.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return existingStatus;
        }

        public async Task<bool> DeleteStatusRequest(Guid id)
        {
            
            var statusRequest = await _context.StatusRequests.FindAsync(id);
            if (statusRequest == null)
            {
                return false; 
            }

            
            Guid statusRequestGuid = statusRequest.Id; //  la propiedad GUID que tenga

                                                        
            bool isBeingUsed = await _context.Requests // Verificar si algún Request está usando ESTE GUID
                .AnyAsync(r => r.IdStatusRequest == statusRequestGuid);

            if (isBeingUsed)
            {
                return false; // No se puede eliminar porque está en uso
            }

            
            statusRequest.UpdatedAt = DateTime.UtcNow; // Soft delete no elimina de la bd solo lo oculta ñro (marcar UpdatedAt)
            await _context.SaveChangesAsync();

            return true;
        }
    }
    }
