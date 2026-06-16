using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class StatusRequest : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public ICollection<Request>? Requests { get; set; } = new List<Request>();
    }
}
