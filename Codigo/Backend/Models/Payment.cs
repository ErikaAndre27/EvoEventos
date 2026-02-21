using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Payment : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public string? PaymentReference { get; set; }
        public Guid IdTransactionStatus { get; set; }
        public Guid RegisteredBy { get; set; }
        public Guid IdReservation { get; set; }
        public string? Notes { get; set; }


        public Reservation Reservation { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusTransaction StatusTransaction { get; set; }
        public User User { get; set; }

        //public Guid ReservationId { get; internal set; }
    }
}