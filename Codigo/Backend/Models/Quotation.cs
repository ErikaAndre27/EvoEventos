using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Quotation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdCustomer { get; set; }
        public Guid? IdStatusQuotation { get; set; }
        public DateTime EventDate { get; set; }
        public int Guests { get; set; }
        public decimal Total { get; set; }

        public Customer Customer { get; set; }
        public StatusQuotation StatusQuotation { get; set; }
        public ICollection<QuotationDetail>? Details { get; set; } = new List<QuotationDetail>();
    }
}