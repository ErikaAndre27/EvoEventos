using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Credential
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUser { get; set; }
        public Guid IdLoggingType { get; set; }
        public string identifier { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public User User { get; set; }
        public LoggingType LoggingType{ get; set; }
    }
}
