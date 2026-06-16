using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class CategoryService : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Service>? Services { get; set; } = new List<Service>();
    }
}