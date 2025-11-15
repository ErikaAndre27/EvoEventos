using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class LogDetail : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdLog { get; set; }
        public string PropertyName { get; set; }   // nombre de campo modificado
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public Log Log { get; set; }
    }
}