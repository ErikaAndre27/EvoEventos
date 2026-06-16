using System.ComponentModel.DataAnnotations;

namespace BackEvoEventos.Models
{
    public class DocumentType : Auditory
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
