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
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

        public Quotation Quotation { get; set; }
        public Service Service { get; set; }
    }
}