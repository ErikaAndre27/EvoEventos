using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Quotation : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Consecutive {  get; set; }
        public Guid? IdRequest { get; set; }
        public Guid IdEventType { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdUser { get; set; }
        public DateOnly EventDate {  get; set; }
        public decimal EventDurationHours { get; set; }
        public string EventLocation { get; set; }
        public string EventCity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }

        public Guid IdStatusQuotation { get; set; }
        public bool IsQuotationAccepted { get; set; }
        public string Notes { get; set; }


        public Request Request { get; set; }
        public User User { get; set; }
        public EventType EventType { get; set; }
        public Customer Customer { get; set; }
        public Reservation Reservation { get; set; }
        public StatusQuotation StatusQuotation { get; set; }
        public ICollection<QuotationDetail>? Details { get; set; } = new List<QuotationDetail>();
    }
}