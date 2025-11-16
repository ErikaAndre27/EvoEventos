using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusReservation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}