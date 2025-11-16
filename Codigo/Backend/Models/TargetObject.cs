using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class TargetObject : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TableName { get; set; }           // ej. "Customer", "Service"
        public string Detail {  get; set; }
        public ICollection<Log>? Logs { get; set; } = new List<Log>();
    }
}