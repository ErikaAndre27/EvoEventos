using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Request : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; } = string.Empty;
        public Guid HandledBy { get; set; }
        public Guid? IdStatusRequest { get; set; }
        public Guid? IdEventType { get; set; }
        public string Message { get; set; } = string.Empty;


        public User User { get; set; } = null!;
        public StatusRequest StatusRequest { get; set; } = null!;
        public EventType EventType { get; set; } = null!;

        public ICollection<RequestDetail>? RequestDetails { get; set; } = new List<RequestDetail>();
    }
}