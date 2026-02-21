using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Reservation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdCustomer { get; set; }
        public Guid IdQuotation { get; set; }
        public Guid? IdStatusReservation { get; set; }
        public Guid? IdStatusPayment { get; set; }
        public int ReservationCode { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int GuestsCount { get; set; }
        public string Notes { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? TotalPaid { get; set; }

        [ForeignKey("IdQuotation")] // Indica que la propiedad IdQuotation es la clave foránea que se relaciona con la entidad Quotation
        public Quotation Quotation { get; set; }

        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }

        [ForeignKey("IdStatusReservation")]
        public StatusReservation? StatusReservation { get; set; }

        [ForeignKey("IdStatusPayment")]
        public StatusPayment? StatusPayment { get; set; }

        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}