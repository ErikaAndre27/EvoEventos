using System.ComponentModel.DataAnnotations;

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
        public string EventName { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int GuestsCount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal? TotalPaid { get; set; }

        public Quotation Quotation { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public StatusReservation? StatusReservation { get; set; }
        public StatusPayment? StatusPayment { get; set; }


        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}