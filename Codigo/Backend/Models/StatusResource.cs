using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusResource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Resource>? Resources { get; set; } = new List<Resource>();
    }
}