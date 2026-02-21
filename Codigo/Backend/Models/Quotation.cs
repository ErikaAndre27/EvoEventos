using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string EventLocation { get; set; }
        public string EventCity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public Guid IdStatusQuotation { get; set; }
        public bool IsQuotationAccepted { get; set; }
        public string Notes { get; set; }

        [ForeignKey("IdRequest")] // Indica 
        public Request? Request { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        [ForeignKey("IdEventType")]
        public EventType EventType { get; set; }

        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }

        public Reservation? Reservation { get; set; }

        [ForeignKey("IdStatusQuotation")]
        public StatusQuotation StatusQuotation { get; set; }

        public ICollection<QuotationDetail>? Details { get; set; } = new List<QuotationDetail>();


        // Se agrega [ForeignKey] para indicar explícitamente la columna FK en la BD.
        // Sin esto, EF asume que la columna se llama "ClaseId" (ej: CustomerId),
        // pero en la BD siguen la convención "IdClase" (ej: IdCustomer), causando un error.
    }
}