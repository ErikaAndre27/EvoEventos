using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class ServiceResource : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdService { get; set; }
        public Guid IdResource { get; set; }
        public int QuantityRequired { get; set; }
        public bool IsMandatory { get; set; }
        public string UsageNotes { get; set; }
        public bool ExternalProvider { get; set; }

        public Service Service { get; set; }
        public Resource Resource { get; set; }
    }
}