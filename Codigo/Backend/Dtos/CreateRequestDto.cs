using BackEvoEventos.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BackEvoEventos.Dtos
{
    public class CreateRequestDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; }
        public string Message { get; set; }
        public Guid? IdStatusRequest { get; set; }
        public Guid HandledBy { get; set; }
        public Guid? IdEventType { get; set; }

        public List<Guid> IdServices { get; set; } = new List<Guid>();
    }
}
