using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Request : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUser { get; set; }           // quien solicita
        public Guid? IdStatusRequest { get; set; }
        public Guid? IdEventType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RequestedAt { get; set; }

        public User User { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public EventType EventType { get; set; }

        // Navegación inversa: detalles de la solicitud
        public ICollection<RequestDetail>? Details { get; set; } = new List<RequestDetail>();
    }
}