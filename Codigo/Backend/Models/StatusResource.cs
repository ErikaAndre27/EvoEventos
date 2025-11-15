using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusResource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        // Colección opcional para relacionar con Resource si lo deseas posteriormente
        public ICollection<object>? Resources { get; set; } = new List<object>();
    }
}