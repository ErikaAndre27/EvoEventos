using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Log : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? IdUser { get; set; }
        public Guid? IdActionType { get; set; }
        public Guid? IdTargetObject { get; set; }
        public string Description { get; set; }   // detalle del evento (antes/después opcional)
        public string ReferenceId { get; set; }   // id del registro afectado (string para flexibilidad)

        public User User { get; set; }
        public ActionType ActionType { get; set; }
        public TargetObject TargetObject { get; set; }

        // Navegación inversa: detalles del log
        public ICollection<LogDetail>? LogDetails { get; set; } = new List<LogDetail>();
    }
}