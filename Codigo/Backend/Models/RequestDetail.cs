using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class RequestDetail : Auditory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdRequest { get; set; }
        public Guid? IdService { get; set; }
        public Guid? IdResource { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal? UnitPrice { get; set; }
        public string Notes { get; set; }

        public Request Request { get; set; }
        public Service Service { get; set; }
        public Resource Resource { get; set; }
    }
}