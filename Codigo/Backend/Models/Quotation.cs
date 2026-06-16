using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Quotation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Consecutive { get; set; }
        public Guid? IdRequest { get; set; }
        public Guid IdEventType { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdUser { get; set; }
        public DateOnly EventDate { get; set; }
        public decimal EventDurationHours { get; set; }
        public string EventLocation { get; set; } = string.Empty;
        public string EventCity { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }

        public Guid IdStatusQuotation { get; set; }
        public bool IsQuotationAccepted { get; set; }
        public string Notes { get; set; } = string.Empty;


        public Request Request { get; set; } = null!;
        public User User { get; set; } = null!;
        public EventType EventType { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public Reservation Reservation { get; set; } = null!;
        public StatusQuotation StatusQuotation { get; set; } = null!;
        public ICollection<QuotationDetail>? Details { get; set; } = new List<QuotationDetail>();
    }
}