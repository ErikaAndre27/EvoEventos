using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Log : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? IdTargetObject { get; set; }
        public Guid? IdActionType { get; set; }
        public Guid? IdUser { get; set; }
        public User User { get; set; } = null!;
        public ActionType ActionType { get; set; } = null!;
        public TargetObject TargetObject { get; set; } = null!;
        public ICollection<LogDetail>? LogDetails { get; set; } = new List<LogDetail>();
    }
}