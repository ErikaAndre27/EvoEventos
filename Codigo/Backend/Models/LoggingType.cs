using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class LoggingType: Auditory
    {
        [Key]
        [Column("IdLogginType")] // Se hace para que el Programa busque el nombre de la tabla y auq epor Id, no encuentra
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Credential>? Credentials { get; set; } = new List<Credential>();
    }
}
