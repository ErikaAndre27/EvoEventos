using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations

{
    public class RequestRepository : IRequestRepository
    {
        private readonly EvoeventosContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IStatusRequestRepository _statusRequestRepository;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IServiceRepository _serviceRepository;


        public RequestRepository(EvoeventosContext context, IUserRepository userRepository, IStatusRequestRepository statusRequest, IEventTypeRepository eventTypeRepository, IServiceRepository serviceRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _statusRequestRepository = statusRequest;
            _eventTypeRepository = eventTypeRepository;
            _serviceRepository = serviceRepository;

        }

        public async Task<List<Request>> GetAllRequests()
        {
            return await _context.Requests
                 .Include(r => r.User)
                 .Include(r => r.StatusRequest)
                 .Include(r => r.EventType)
                 .Include(r => r.RequestDetails)
                     .ThenInclude(d => d.Service)
                 .OrderByDescending(r => r.CreatedAt)
                 .ToListAsync();
        }
        public async Task<Request> GetRequestById(Guid Id)
        {
            return await _context.Requests
                .Include(r => r.User)
                .Include(r => r.StatusRequest)
                .Include(r => r.EventType)
                .Include(r => r.RequestDetails)
                    .ThenInclude(d => d.Service)
                .FirstOrDefaultAsync(r => r.Id == Id);
        }
        public async Task<bool> CreateRequest(CreateRequestDto RequestDto)
        {
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    
                    var user = await _userRepository.GetUserById(RequestDto.HandledBy); // validart que el user exista
                    if (user == null)
                        throw new Exception($"El usuario con ID {RequestDto.HandledBy} no existe");

                   
                    var defaultStatus = await _context.StatusRequests  // 2. BUSCAR StatusRequest Pendienteee  
                    .FirstOrDefaultAsync(s => s.Name == "Pendiente");// Esto evita necesitar un método especial en el repositorio


                    Guid? statusId = defaultStatus?.Id; // Si no existe el estado, usar el perimero o dejarlo null

                    // 4. Crear el Request principal
                    var request = new Request
                    {
                        Id = Guid.NewGuid(),
                        FullName = RequestDto.FullName,
                        Phone = RequestDto.Phone,
                        Email = RequestDto.Email,
                        EventDate = RequestDto.EventDate,
                        EventAttendees = RequestDto.EventAttendees,
                        EventLocation = RequestDto.EventLocation,
                        HandledBy = RequestDto.HandledBy,
                        IdStatusRequest = statusId, 
                        IdEventType = RequestDto.IdEventType,
                        Message = RequestDto.Message
                    };

                    await _context.Requests.AddAsync(request);

                    
                    if (RequestDto.IdServices != null && RequestDto.IdServices.Any()) //Validar y crear el RequestDetails
                    {
                        foreach (var serviceId in RequestDto.IdServices)
                        {
                            // Validar que el Service existe
                            var service = await _serviceRepository.GetService(serviceId);
                            if (service == null)
                                throw new Exception($"El servicio con ID {serviceId} no existe");

                            var requestDetail = new RequestDetail
                            {
                                Id = Guid.NewGuid(),
                                IdRequest = request.Id,
                                IdService = serviceId
                            };

                            await _context.RequestDetails.AddAsync(requestDetail);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true; // Solo retorna true si todo salió biend
                }
                catch 
                {
                    return false;
                }
            }
        }

        public async Task<Request> UpdateRequest(Guid id, UpdateRequestDto updateDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Buscar el request existente con sus detalles
                var existingRequest = await _context.Requests
                    .Include(r => r.RequestDetails)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (existingRequest == null)
                    throw new Exception($"Request con ID {id} no encontrado");

                // Actualizar propiedades básicas
                existingRequest.FullName = updateDto.FullName;
                existingRequest.Phone = updateDto.Phone;
                existingRequest.Email = updateDto.Email;
                existingRequest.EventDate = updateDto.EventDate;
                existingRequest.EventAttendees = updateDto.EventAttendees;
                existingRequest.EventLocation = updateDto.EventLocation;
                existingRequest.Message = updateDto.Message;
                existingRequest.UpdatedAt = DateTime.UtcNow;

                // Actualizar FKs si se proporcionan
                if (updateDto.IdStatusRequest.HasValue)
                {
                    // Validar que el StatusRequest existe
                    var status = await _statusRequestRepository.GetStatusRequestById(updateDto.IdStatusRequest.Value);
                    if (status == null)
                        throw new Exception($"StatusRequest con ID {updateDto.IdStatusRequest} no existe");

                    existingRequest.IdStatusRequest = updateDto.IdStatusRequest.Value;
                }

                if (updateDto.IdEventType.HasValue)
                {
                    // Validar que el EventType existe
                    var eventType = await _eventTypeRepository.GetEventTypeById(updateDto.IdEventType.Value);
                    if (eventType == null)
                        throw new Exception($"EventType con ID {updateDto.IdEventType} no existe");

                    existingRequest.IdEventType = updateDto.IdEventType.Value;
                }

                // Actualizar servicios si se proporcionan
                if (updateDto.Services != null)
                {
                    // Eliminar detalles existentes
                    if (existingRequest.RequestDetails.Any())
                    {
                        _context.RequestDetails.RemoveRange(existingRequest.RequestDetails);
                    }

                    // Agregar nuevos detalles
                    foreach (var serviceId in updateDto.Services)
                    {
                        // Validar que el Service existe
                        var service = await _serviceRepository.GetService(serviceId);
                        if (service == null)
                            throw new Exception($"Servicio con ID {serviceId} no existe");

                        var requestDetail = new RequestDetail
                        {
                            Id = Guid.NewGuid(),
                            IdRequest = existingRequest.Id,
                            IdService = serviceId
                        };

                        await _context.RequestDetails.AddAsync(requestDetail);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return await GetRequestById(existingRequest.Id);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Error al actualizar request: {ex.Message}");
            }
        }
        public async Task<Request> UpdateRequest(Request UpdateRequest)
        {
            var existingRequest = await _context.Requests
            .FirstOrDefaultAsync(r => r.Id == UpdateRequest.Id);

            if (existingRequest == null)
            {
                throw new Exception($"No se encontró el request con ID {UpdateRequest.Id}");
            }

            // Actualizar todas las propiedades del request existente
            _context.Entry(existingRequest).CurrentValues.SetValues(UpdateRequest);

            await _context.SaveChangesAsync();
            return existingRequest;
        }
        public async Task<bool> DeleteRequest(Guid Id)
        {
            var request = await _context.Requests.FindAsync(Id);

            if (request == null)
                return false;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
