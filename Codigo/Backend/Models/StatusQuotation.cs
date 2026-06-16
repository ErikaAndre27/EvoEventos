using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusQuotation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
    }
}