using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Customer
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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DocumentType DocumentType { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
