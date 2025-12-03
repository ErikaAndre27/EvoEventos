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

        public RequestRepository(EvoeventosContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAllRequests()
        {
            return await _context.Requests
                .Include(x => x.RequestDetail)
                .ToListAsync();
        }
        public async Task<bool> CreateRequest(CreateRequestDto RequestDto)
        {
            try
            {

                var Request = new Request
                {
                    FullName = RequestDto.FullName,
                    Phone = RequestDto.Phone,
                    Email = RequestDto.Email,
                    EventDate = RequestDto.EventDate,
                    EventAttendees = RequestDto.EventAttendees,
                    EventLocation = RequestDto.EventLocation,
                    Message = RequestDto.Message,
                    IdEventType = RequestDto.IdEventType,
                };
                await _context.Requests.AddAsync(Request);



                foreach (var IdService in RequestDto.IdServices) // Asocia los servicios que el cliente pidió con la solicitud
                {
                    var NewDetail = new RequestDetail 
                    {
                        IdRequest = Request.Id,
                        IdService = IdService,

                    };
                    await _context.RequestDetails.AddAsync(NewDetail);// Ayuda
                }
           
               
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());

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
        public async Task<Request>GetRequestById(Guid Id)
        {
            return await _context.Requests.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
