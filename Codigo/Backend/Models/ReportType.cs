using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class ReportType : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Report>? Reports { get; set; } = new List<Report>();
    }
}