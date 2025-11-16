using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class EventType : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public ICollection<Request>? Requests { get; set; } = new List<Request>();
        public ICollection<Quotation>? Quotation { get; set; } = new List<Quotation>();
    }
}