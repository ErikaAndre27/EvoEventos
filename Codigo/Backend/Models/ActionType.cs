using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class ActionType : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Log>? Logs { get; set; } = new List<Log>();
    }
}