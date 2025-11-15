using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class LoggingType: Auditory
    {
        [Key]
        [Column] 
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Credential>? Credentials { get; set; } = new List<Credential>();
    }
}
