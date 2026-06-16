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
        public string Names { get; set; } = string.Empty;
        public string Surnames { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid IdDocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid IdRole { get; set; }

        public DocumentType DocumentType { get; set; } = null!;
        public Role Role { get; set; } = null!;
        public ICollection<Credential> Credentials { get; set; } = new List<Credential>();
        public ICollection<Report>? Reports { get; set; } = new List<Report>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public ICollection<Quotation>? Quotations { get; set; } = new List<Quotation>();
        public ICollection<Log>? Logs { get; set; } = new List<Log>();
        public ICollection<Request>? Requests { get; set; } = new List<Request>();
    }
}
