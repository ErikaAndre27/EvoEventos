using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Payment : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdReservation { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public Guid? IdStatusPayment { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Reservation Reservation { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusPayment StatusPayment { get; set; }
    }
}