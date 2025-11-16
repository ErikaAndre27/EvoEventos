using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class PaymentMethod : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}