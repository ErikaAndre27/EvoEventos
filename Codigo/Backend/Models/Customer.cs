using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Customer : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdDocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public Guid IdCustomerType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; } = null!;
        public CustomerType CustomerType { get; set; } = null!;
        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}
