using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class LoggingType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Credential> Credentials { get; set; }
    }
}
