    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata;

    namespace BackEvoEventos.Models
{
    public class User : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public Guid IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid IdRole { get; set; }

        [ForeignKey("IdDocumentType")] // Indica explícitamente que la FK es "IdDocumentType", no "DocumentTypeId" como asume EF por convención.
        public DocumentType DocumentType { get; set; }

        [ForeignKey("IdRole")]
        public Role Role { get; set; }
        public ICollection<Credential> Credentials { get; set; }
        public ICollection<Report>? Reports { get; set; } = new List<Report>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
        public ICollection<Log>? Logs { get; set; } = new List<Log>();
        public ICollection<Request>? Requests { get; set; } = new List<Request>();
    }
}
