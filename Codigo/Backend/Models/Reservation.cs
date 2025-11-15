using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Reservation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? IdQuotation { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid? IdStatusReservation { get; set; }
        public string ReservationCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }

        public Quotation Quotation { get; set; }
        public Customer Customer { get; set; }
        public StatusReservation StatusReservation { get; set; }
        public ICollection<ReservationService>? ReservationServices { get; set; } = new List<ReservationService>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}