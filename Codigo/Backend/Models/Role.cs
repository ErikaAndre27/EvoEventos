using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class Role: Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ICollection<User>? Users { get; set; } = new List<User>(); // QUITAR EL SIGNO ? Y NEW LIST<USER>() SI DA PROBLEMAS
    }

}
