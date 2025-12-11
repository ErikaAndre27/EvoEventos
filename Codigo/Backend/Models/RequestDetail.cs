using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class RequestDetail : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdRequest { get; set; }
        public Guid IdService { get; set; }

        public Request Request { get; set; }
        public Service Service { get; set; }
    }
}