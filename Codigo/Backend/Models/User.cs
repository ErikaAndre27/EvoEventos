using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
namespace BackEvoEventos.Models
{
    public class User
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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DocumentType DocumentType { get; set; }
        public Role Role {  get; set; }
    }
}
