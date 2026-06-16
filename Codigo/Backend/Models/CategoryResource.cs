using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class CategoryResource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Resource>? Resources { get; set; } = new List<Resource>();
    }
}