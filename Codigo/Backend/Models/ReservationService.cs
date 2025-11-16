using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class ReservationService : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdReservation { get; set; }
        public Guid IdService { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;

        public Reservation? Reservation { get; set; }
        public Service? Service { get; set; }
    }
}