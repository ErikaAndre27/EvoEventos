using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusQuotation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
    }
}