using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Report : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid IdReportType { get; set; }
        public Guid IdUser { get; set; }
        public DateOnly RangeStartDate { get; set; }
        public DateOnly RangeEndDate { get; set; }
        public ReportType? ReportType { get; set; }
        public User? User { get; set; }
    }
}