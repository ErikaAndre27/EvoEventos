using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Resource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? IdCategoryResource { get; set; }

        public CategoryResource CategoryResource { get; set; }
        public ICollection<ServiceResource>? ServiceResources { get; set; } = new List<ServiceResource>();
    }
}