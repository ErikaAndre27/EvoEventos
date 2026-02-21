using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class Customer: Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public Guid IdCustomerType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        [ForeignKey("IdDocumentType")]
        public DocumentType DocumentType { get; set; }

        [ForeignKey("IdCustomerType")]
        public CustomerType CustomerType { get; set; }

        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();


    }
}
