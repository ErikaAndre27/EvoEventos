using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class PricingUnit : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Service>? Services { get; set; } = new List<Service>();
    }
}