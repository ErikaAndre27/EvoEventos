using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Request : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; }
        public Guid HandledBy { get; set; }          
        public Guid? IdStatusRequest { get; set; }
        public Guid? IdEventType { get; set; }
        public string Message { get; set; }
        

        public User User { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public EventType EventType { get; set; }

        public ICollection<RequestDetail>? Details { get; set; } = new List<RequestDetail>();
        public object RequestDetail { get; internal set; }
    }
}