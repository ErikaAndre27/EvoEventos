using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEvoEventos.Models
{
    public class CustomerType: Auditory
    {
        [Key]
        [Column ("IdCustomerType")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();

    }
}
