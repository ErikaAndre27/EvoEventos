using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("IdService")]
        public Service Service { get; set; }

        [ForeignKey("IdResource")]
        public Resource Resource { get; set; }
    }
}