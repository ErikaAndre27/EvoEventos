using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class LogDetail : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdLog { get; set; }
        public string AffectedField { get; set; } = string.Empty;   // nombre de campo modificado
        public string PreviousValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;

        public Log Log { get; set; } = null!;
    }
}