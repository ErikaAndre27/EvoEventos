using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class QuotationDetail : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdQuotation { get; set; }
        public Guid IdService { get; set; }
        public int Quantity { get; set; }
        public int DurationHours { get; set; }
        public decimal SubTotal { get; set; }
        public string Notes { get; set; } = string.Empty;

        public Quotation Quotation { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}