using BackEvoEventos.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BackEvoEventos.Dtos
{
    public class CreateRequestDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Guid? IdStatusRequest { get; set; }
        public Guid HandledBy { get; set; }
        public Guid? IdEventType { get; set; }

        public List<Guid> IdServices { get; set; } = new List<Guid>();
    }
}
