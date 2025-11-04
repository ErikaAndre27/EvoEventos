using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class LoggingType
    {
        [Key]
        [Column("IdLogginType")] // Se hace para que el Programa busque el nombre de la tabla y auq epor Id, no encuentra
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Credential>? Credentials { get; set; } = new List<Credential>();
    }
}
