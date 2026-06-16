using System.ComponentModel.DataAnnotations;

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


        public Reservation Reservation { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public StatusTransaction StatusTransaction { get; set; } = null!;
        public User User { get; set; } = null!;
        public Guid ReservationId { get; internal set; }
    }
}