using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class DocumentType
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
