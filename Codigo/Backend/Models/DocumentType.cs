using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class DocumentType: Auditory
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
