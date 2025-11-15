using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class TargetObject : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }           // ej. "Customer", "Service"
        public string TableName { get; set; }      // opcional para mapeo directo

        public ICollection<Log>? Logs { get; set; } = new List<Log>();
    }
}