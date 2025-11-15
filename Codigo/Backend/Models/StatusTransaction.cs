using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusTransaction : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        // Colección opcional para futuras relaciones (ej. Transactions)
        public ICollection<object>? Transactions { get; set; } = new List<object>();
    }
}