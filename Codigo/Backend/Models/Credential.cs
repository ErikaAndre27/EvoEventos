using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Credential: Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUser { get; set; }
        public string EmailIdentifier { get; set; }
        public string DocumentIdentifier { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public User User { get; set; }
    }
}
